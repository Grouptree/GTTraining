(function initialiseCommentsFactory() {

    angular.module('gt.app').factory('commentsFactory', ['$http', factory]);

    function factory($http) {

        var self = this;

        self.getCommentsForCurrentAsset = function () {
            return $http.get('/Comments/GetCommentsForAsset?currentAssetPointerID=' + gt.pageContext.currentAssetPointerID);
        };

        self.addCommentToCurrentAsset = function (commentText) {
            return $http.post('/Comments/AddCommentToAsset', { currentAssetPointerID: gt.pageContext.currentAssetPointerID, commentText: commentText });
        };

        self.deleteComment = function (commentPointerID) {
            return $http.delete('/Comments/DeleteComment?commentPointerID=' + commentPointerID);
        };

        return self;

    };

})();