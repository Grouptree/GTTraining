(function initialiseLoginFormController() {

    angular.module('gt.app').controller('LoginFormController', ['loginFormFactory', '$timeout', controller]);

    function controller(loginFormFactory, $timeout) {

        var self = this;

        self.login = function () {

            loginFormFactory.login(self.username, self.password).then(function (result) {

                self.attemptedLogin = true;
                self.loginResult = result.data;

                if (self.loginResult.successful) {                                      
                    window.location.href = self.loginResult.redirectURL;                    
                }

            });

        };

    };

})();