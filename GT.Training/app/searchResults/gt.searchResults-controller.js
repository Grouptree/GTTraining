(function initialiseSearchResultsController() {

    angular.module('gt.app').controller('SearchResultsController', ['searchResultsFactory', controller]);

    function controller(searchResultsFactory) {

        var self = this;
        
        self.results = [];
        self.dataLoaded = false;

        var searchText = searchResultsFactory.getSearchQueryString();

        if (searchText) {
            searchResultsFactory.getSearchResults(searchText).then(function (results) {
                self.results = results.data;
                self.dataLoaded = true;
            });
        }

    };

})();