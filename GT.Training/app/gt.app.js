(function () {

    angular.module('gt.app', ['angular-jqcloud'])
        .filter('to_trusted', ['$sce', function ($sce) {
        return function (text) {
            return $sce.trustAsHtml(text);
        };
    }]);


})();