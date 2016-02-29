function UserLogin() {
    var self = this;

    self.Login = ko.observable();
    self.Password = ko.observable();
    self.ErrorMessage = ko.observable();
    
    self.SubmitLogin = function (model) {
        if (!model) return;
        
        $.ajax({
            url: "/User/Login/",
            type: "POST",
            data: ko.toJS(model),
            success: function(response) {
                if (response && response.IsSuccess) {
                    document.location.href = "/Chat/";
                } else {
                    self.ErrorMessage(response.Message);
                }
            }
        });
    };
}