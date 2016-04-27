using Grouptree.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT.Training.BL
{
    public class SecurityTrimmingHelper
    {
        public static IEnumerable<Asset> SecurityTrim(IEnumerable<Asset> assets)
        {
            bool isAuthenticated = UserAuthenticationHelper.IsUserAuthenticated();

            if(isAuthenticated)
            {
                return assets.Where(asset => !asset.Type.Equals(Constants.Types.Login) && !asset.Name.Equals("User Registration", StringComparison.InvariantCultureIgnoreCase));
            }
            else
            {
                return assets.Where(asset => !RequiresAuthenticatedUserToView(asset));
            }
        }

        public static bool RequiresAuthenticatedUserToView(Asset asset)
        {
            return asset.Type.Equals(Constants.Types.Secure) || IsAncestorOfType(asset, Constants.Types.Secure) || asset.Type.Equals(Constants.Types.Media);
        }

        private static bool IsAncestorOfType(Asset asset, string type)
        {
            return asset.GetAncestors().Any(ancestor => ancestor.Type.Equals(type, StringComparison.InvariantCultureIgnoreCase));            
        }

    }
}
