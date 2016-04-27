using Grouptree.Core;
using Grouptree.Core.Security;
using GT.Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT.Training.BL
{
    public class UserTagViewsBL
    {
        public static List<TagViews> GetUserTagViews()
        {
            Asset currentUserAsset = UserAuthenticationHelper.GetCurrentUserAsset();

            if (currentUserAsset == null)
                return new List<TagViews>();

            Dictionary<string, string> userTagViews = currentUserAsset.GetDictionaryProperty(Constants.Users.TagViews);
            
            return Convert(userTagViews ?? new Dictionary<string, string>()).OrderByDescending(userTagView => userTagView.NumberOfViews).ToList();
        }

        public static IEnumerable<TagViews> Convert(Dictionary<string, string> userTagViews)
        {            
            foreach(string tag in userTagViews.Keys)
            {
                int views = 0;
                int.TryParse(userTagViews[tag], out views);

                yield return new TagViews
                {
                    Tag = tag,
                    NumberOfViews = views
                };                       
            }            
        }

        public static void UpdateCurrentUserTagViews(string assetPointerIDToRetrieveTagsFrom)
        {
            Asset asset = API_Core.Gets.GetByPID(assetPointerIDToRetrieveTagsFrom);

            if (asset == null)
                return;

            IEnumerable<string> tags = API_Core.Tagging.GetAssetsTags(asset).Select(tag => tag.Name);

            if (!tags.Any())
                return;

            UserWrapper currentUserWrapper = UserAuthenticationHelper.GetCurrentUser();

            if (currentUserWrapper == null)
                return;

            Asset currentUserAsset = currentUserWrapper.Asset;

            Dictionary<string, string> userTagViews = currentUserAsset.GetDictionaryProperty(Constants.Users.TagViews);
            userTagViews = userTagViews ?? new Dictionary<string, string>();

            foreach(string tag in tags)
            {
                int viewCount = 0;

                if(userTagViews.ContainsKey(tag))
                {
                    int.TryParse(userTagViews[tag], out viewCount);                    
                }

                viewCount += 1;
                userTagViews[tag] = viewCount.ToString();
            }

            currentUserAsset.SetDictionaryProperty(Constants.Users.TagViews, userTagViews);
            API_Core.Saving.SaveWithoutVersioning(currentUserAsset);
        }   



    }
}
