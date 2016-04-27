(function initialiseTagCloudController() {

    angular.module('gt.app').controller('TagCloudController', ['tagCloudFactory', controller]);

    function controller(tagCloudFactory) {

        var self = this;
        self.isUserLoggedIn = gt.pageContext.isUserLoggedIn;
        self.words = [];

        if (window.location.href.toLowerCase().indexOf('news') === -1) {
            tagCloudFactory.getUserTagCloud().then(function (result) {
                self.words = result.data;
            });
        }
        else
        {
            tagCloudFactory.getNewsArticleTagCloud().then(function (result) {
                self.words = result.data;
            });
        }

    };

})();