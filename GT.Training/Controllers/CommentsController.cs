using Grouptree.Core;
using Grouptree.Core.Security;
using GT.Training.BL;
using GT.Training.Helpers;
using GT.Training.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GT.Training.Controllers
{
    public class CommentsController : Controller
    {     
        [HttpGet]
        public string GetCommentsForAsset(string currentAssetPointerID)
        {            
            if(!CommentsBL.AssetAllowsComments(currentAssetPointerID))
            {
                return CamelCaseSerializer.Serialize(new
                    {
                        allowsComments = false
                    });
            }
            else
            {
                List<Comment> comments = CommentsBL.GetCommentsForAsset(currentAssetPointerID);

                return CamelCaseSerializer.Serialize(new
                    {
                        allowsComments = true,
                        comments = comments
                    });             
            }                        
        }

        [HttpPost]         
        public string AddCommentToAsset(string currentAssetPointerID, string commentText)
        {
            if (!UserWrapper.IsAuthenticated)
                return string.Empty;

            Comment newComment = CommentsBL.AddComment(currentAssetPointerID, commentText);

            if (newComment == null)
                return null;

            return CamelCaseSerializer.Serialize(newComment);
        }

        [HttpDelete]
        public string DeleteComment(string commentPointerID)
        {            
            Asset commentAsset = API_Core.Gets.GetByPID(commentPointerID);

            bool result = false;

            if (commentAsset.CreateUser.UserID.Equals(UserWrapper.GetCurrent().UserID))
            {
                result = API_Core.Archiving.ArchiveAsset(commentAsset);                
            }

            return CamelCaseSerializer.Serialize(result);            
        }
	}
}