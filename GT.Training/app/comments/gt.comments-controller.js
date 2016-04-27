(function initialiseCommentsController() {

    angular.module('gt.app').controller('CommentsController', ['commentsFactory', controller]);

    function controller(commentsFactory) {

        var self = this;
        self.isUserLoggedIn = gt.pageContext.isUserLoggedIn;
        self.currentUserID = gt.pageContext.currentUserID;

        self.comments = [];
        self.allowsComments = false;

        self.addComment = function () {

            self.submittingComment = true;

            commentsFactory.addCommentToCurrentAsset(self.newCommentText).then(function (result) {
              
                if (!result.data) {
                    self.submittingComment = false;
                    return;
                }
                
                // Add comment to current list of comments 
                self.comments.splice(0, 0, result.data);                

                // clear comments textbox so that new comment can be added
                self.newCommentText = '';
                self.submittingComment = false;
            });

        };        

        commentsFactory.getCommentsForCurrentAsset().then(function (result) {

            self.allowsComments = result.data.allowsComments;

            if (self.allowsComments)
            {
                self.comments = result.data.comments;
            }
            
        });

        self.deleteComment = function (commentPointerID) {
            commentsFactory.deleteComment(commentPointerID).then(function (result) {
                                
                if (result.data === 'true') {
                    for (var i = 0; i < self.comments.length; i++) {
                        if (self.comments[i].pointerID === commentPointerID) {
                            self.comments.splice(i, 1);
                            break;
                        }
                    }
                }                

            });
        };


    };

})();