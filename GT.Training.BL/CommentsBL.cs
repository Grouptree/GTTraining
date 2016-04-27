using Grouptree.Core;
using Grouptree.Core.Security;
using Grouptree.Web;
using GT.Training.BL.Constants;
using GT.Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT.Training.BL
{
    public class CommentsBL
    {
        public static Comment AddComment(string assetPointerID, string commentText)
        {            
            Asset commentParentAsset = API_Core.Gets.GetByPID(assetPointerID);
            Asset currentUserAsset = UserWrapper.GetCurrent().Asset;

            if(commentParentAsset == null || currentUserAsset == null)
                return null;

            string commentName = currentUserAsset.Name + " on " + DateTime.Now.ToUniversalTime().ToShortDateString();                       
            
            Asset newComment = API_Core.Create.CreateNewAsset(commentParentAsset, commentName, Types.News, SubTypes.Comment);
            newComment[Comments.CommentText] = commentText;         
            newComment = newComment.Publish();        

            return Convert(newComment);
        }

        public static bool AssetAllowsComments(string assetPointerID)
        {
            Asset asset = API_Core.Gets.GetByPID(assetPointerID);

            if(asset == null)
                return false;

            int allowsComments = 0;            
            int.TryParse(asset[Constants.Comments.AllowsComments], out allowsComments);

            return allowsComments == 1;
        }

        public static List<Comment> GetCommentsForAsset(string assetPointerID)
        {
            Asset commentsParentAsset = API_Core.Gets.GetByPID(assetPointerID);

            if (commentsParentAsset == null)
                return new List<Comment>();

            return Convert(commentsParentAsset.GetChildrenOfSubType(SubTypes.Comment).OrderByDescending(comment=> comment.CreateDate)).ToList();
        }

        public static Comment Convert(Asset asset)
        {
            Comment result = new Comment();

            result.PointerID = asset.PointerID;
            result.Name = asset.CreateUser.FullName + " on " + asset.CreateDate.ToShortDateString();
            result.Text = asset[Comments.CommentText];                        
            
            result.User = asset.CreateUser.Name;
            result.UserID = asset.CreateUser.UserIDasString;

            result.TimeAdded = asset.CreateDate;

            return result;
        }

        public static IEnumerable<Comment> Convert(IEnumerable<Asset> assets)
        {
            foreach(Asset asset in assets)
            {
                yield return Convert(asset);
            }
        }

    }
}
