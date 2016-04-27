(function initialiseLoginFormFactory() {

    angular.module('gt.app').factory('loginFormFactory', ['$http', factory]);

    function factory($http) {

        var self = this;

        self.login = function (username, password) {
            return $http.post('/Account/Login', { 'username': username, 'password': password });
        };

        return self;
    };

})();