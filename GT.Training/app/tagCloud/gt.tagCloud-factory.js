(function initialiseTagCloudFactory() {

    angular.module('gt.app').factory('tagCloudFactory', ['$http', factory]);

    function factory($http) {

        var self = this;

        self.getUserTagCloud = function () {
            return $http.get('/Promos/GetUserTagCloud');
        };

        self.getNewsArticleTagCloud = function () {
            return $http.get('/Promos/GetNewsArticleTagCloud?newsArticlePointerID=' + gt.pageContext.currentAssetPointerID);
        };

        return self;

    };

})();