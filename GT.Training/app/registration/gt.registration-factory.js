(function initialiseRegistrationFactory() {

    angular.module('gt.app').factory('registrationFactory', ['$http', factory])

    function factory($http) {

        var self = this;

        self.register = function (registrationDetails) {

            return $http.post('/Account/Register', {                
                'firstName': registrationDetails.firstName,
                'lastName': registrationDetails.lastName,
                'email': registrationDetails.email,
                'password': registrationDetails.password
            });

        };

        return self;

    };

})();