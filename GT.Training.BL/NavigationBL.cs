using Grouptree.Core;
using Grouptree.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT.Training.BL
{
    public class NavigationBL
    {    
        public static IEnumerable<Asset> RetrieveSecurityTrimmedLandingPagesInRoot()
        {           
            var root = GetSiteRootFolder();

            if (root == null)
            {
                return Enumerable.Empty<Asset>();
            }

            bool isAuthenticated = UserAuthenticationHelper.IsUserAuthenticated();

            return SecurityTrimmingHelper.SecurityTrim(root.GetChildrenOfSubType(Constants.SubTypes.Landing));
        }

        public static List<Asset> GetCurrentBreadcrumbs()
        {
            IEnumerable<Asset> allCurrentNodeAncestors = API_Razor.CurrentAsset().GetAncestors();

            if (!allCurrentNodeAncestors.Any())
                return allCurrentNodeAncestors.ToList();

            // breadcrumbs are made up of all ancestors up to the root folder (this should not be included) 
            // items are reversed so that they are displayed in the correct order starting from the top most node first
            return allCurrentNodeAncestors.TakeWhile(asset => !(asset.Type.Equals(Constants.Types.AppFolder) && asset.SubType.Equals(Constants.SubTypes.WebsiteFolder))).Reverse().ToList();
        }

        public static Asset GetClosestLandingPage()
        {
            Asset currentAsset = API_Razor.CurrentAsset();

            if(currentAsset.SubType.Equals(Constants.SubTypes.Landing)) {
                return currentAsset;
            }

            // get the closest parent landing page
            return currentAsset.GetAncestors().FirstOrDefault(ancestor => ancestor.SubType.Equals(Constants.SubTypes.Landing));
        }

        public static List<Asset> GetSideNavChildren(Asset parent)
        {
            return parent.GetChildren().Where(asset => asset.SubType.Equals(Constants.SubTypes.Landing) || asset.SubType.Equals(Constants.SubTypes.Page)).ToList();
        }

        private static Asset GetSiteRootFolder()
        {
            return Grouptree.Core.API_Core.Gets.GetByTypeAndSubType(Constants.Types.AppFolder, Constants.SubTypes.WebsiteFolder).FirstOrDefault();
        }        

    }
}
