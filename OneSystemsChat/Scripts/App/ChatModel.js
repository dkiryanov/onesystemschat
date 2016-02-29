function ChatModel(data) {
    var self = this;

    //--------------------- PROPERTIES ---------------------------

    self.Messages = ko.observableArray(data.Messages);
    self.CurrentUserLogin = ko.observable(data.CurrentUserLogin);
    self.CurrentUserId = ko.observable(data.CurrentUserId);
    self.Content = ko.observable();
    self.RecipientId = ko.observable();
    self.ActiveUsers = ko.observableArray([]);
    self.RecipientLogin = ko.observable();
    self.tmpMessages = ko.observableArray([]);
    self.tmpActiveUsers = ko.observableArray([]);
    
    //---------------------- METHODS --------------------------
    
    //Sets the connection to the Question Hub
    self.hub = $.connection.chatHub;

    //Starts the Hub
    self.hubStart = function (login, userId) {
        $.connection.hub.start().done(function () {
            self.hub.server.connected(login, userId);
        });
    };
    
    self.hubStart(self.CurrentUserLogin(), self.CurrentUserId());

    self.GetDateFormatted = function(message) {
        return moment(message.Date).format("MMM Do h:mm:ss a");
    };

    self.GetPublicMessages = function() {
        self.RecipientId(-1);
        self.RecipientLogin("");
        
        $.ajax({
            type: "POST",
            url: "/Chat/GetPublicMessages/",
            success: function(messages) {
                self.Messages(messages);
            }
        });
    };
    
    self.SendMessage = function () {
        var message = {
            Content: self.Content(),
            RecipientId: self.RecipientId()
        };

        $.ajax({
            method: "POST",
            data: ko.toJS(message),
            url: "/Chat/AddMessage/",

            success: function (responseData) {
                if (responseData) {
                    self.hub.server.send(responseData.Login, responseData.Content, responseData.Date);
                    
                    if (responseData.RecipientId) {
                        self.hub.server.sendNotificationToUser(self.CurrentUserId(), self.RecipientId());
                    }
                    
                    self.updateMessages(responseData);
                }
            }
        });
    };

    self.GetChatHeaderText = function() {
        if (self.RecipientId()) {
            return "Private chat with " + self.RecipientLogin();
        } else {
            return "Public chat";
        }
    };
    
    self.GetUserMessages = function (user) {
        self.RecipientId(user.UserId);
        self.RecipientLogin(user.Login);
        
        $.ajax({
            url: "/Chat/GetMessagesForPrivateConversation/",
            type: "POST",
            data: ko.toJS({ UserId: self.CurrentUserId(), RecipientId: user.UserId }),

            success: function (response) {
                self.Messages(response.Messages);
            }
        });
    };
    
    self.updateMessages = function (message) {
        if (message.RecipientId != null && message.RecipientId === self.CurrentUserId()) {
            return;
        } else {
            self.tmpMessages(self.Messages());
            self.tmpMessages().push(message);
            self.Messages([]);
            self.Messages(self.tmpMessages());
        }
    };
    

    //---------- HUBS ---------------
    
    self.hub.client.updateNotifications = function (senderId, recipientId) {
        if (self.CurrentUserId() === recipientId) {

            self.tmpActiveUsers(self.ActiveUsers());
            
            for (var i = 0; i < self.tmpActiveUsers().length; i++) {
                if (self.tmpActiveUsers()[i].UserId === senderId) {
                    self.tmpActiveUsers()[i].HasMessage = true;
                }
            }
            
            self.ActiveUsers([]);
            self.ActiveUsers(self.tmpActiveUsers());
        }
    };

    //OnConnected property, gets all active users' logins for the current moment
    self.hub.client.getActiveUsers = function (users) {
        self.ActiveUsers(users);
    };
    
    self.hub.client.onNewUserConnected = function (user) {
        self.tmpActiveUsers(self.ActiveUsers());
        self.tmpActiveUsers().push(user);
        self.ActiveUsers(self.tmpActiveUsers());
    };

    self.hub.client.addMessage = function(login, message, messageDate) {
        self.updateMessages({ "Login": login, "Content": message, "Date": messageDate });
    };

    self.hub.client.onUserDisconnected = function (users) {
        self.ActiveUsers([]);
        
        for (var i = 0; i < users.length; i++) {
            if (self.CurrentUserId() != users[i].UserId) {
                self.ActiveUsers().push(users[i]);
            }
        }
    };
}