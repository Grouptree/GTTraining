(function initialiseSearchResultsFactory() {

    angular.module('gt.app').factory('searchResultsFactory', ['$http', factory]);

    function factory($http) {

        var self = this;

        self.getSearchResults = function (searchText) {
            return $http.get('/Search/Search?searchString=' + searchText);
        };

        self.getSearchQueryString = function () {            
            return gt.pageContext.qs('searchText');
        };

        return self;

    };

})();