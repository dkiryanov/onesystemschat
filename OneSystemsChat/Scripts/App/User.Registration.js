function UserRegistration () {
    var self = this;
    
    ko.validation.rules['passwordsMatch'] = {
        getValue: function (o) {
            return (typeof o === 'function' ? o() : o);
        },
        validator: function (val, otherField) {
            return val === this.getValue(otherField);
        },
        message: 'Passwords do not match'
    };
    
    ko.validation.registerExtenders();
    
    self.Login = ko.observable("").extend({ required: true, maxlength: 128 });
    self.Password = ko.observable("").extend({ required: true, maxlength: 256 });
    self.ConfirmPassword = ko.observable("").extend({ required: true, maxlength: 256, passwordsMatch: self.Password });
    self.Errors = ko.validation.group(self);
    self.ErrorMessage = ko.observable();
    
    self.IsFieldsFilled = ko.computed(function () {
        return self.Errors().length == 0;
    }, this);
    
    self.SubmitRegistration = function (data) {
        if (!data) return;
        
        $.ajax({
            type: "POST",
            url: "/User/Register/",
            data: ko.toJS(data),
            
            success: function(response) {
                if (response.IsSuccess) {
                    document.location.href = '/Chat/';
                } else {
                    self.ErrorMessage(response.Message);
                }
            }
        });
    };
}