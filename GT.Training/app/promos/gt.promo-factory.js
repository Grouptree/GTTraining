(function initialisePromoFactory() {

    angular.module('gt.app').factory('promosFactory', ['$http', factory]);

    function factory($http) {

        var self = this;

        self.getPromosForCurrentAsset = function () {
            return $http.get('/Promos/GetPromoForCurrentUser?currentAssetPointerID=' + gt.pageContext.currentAssetPointerID);
        };       

        return self;
    };

})();