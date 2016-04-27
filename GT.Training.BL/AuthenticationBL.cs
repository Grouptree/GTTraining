using Grouptree.Core;
using Grouptree.Core.Security;
using Grouptree.Web;
using GT.Training.BL.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT.Training.BL
{
    public class AuthenticationBL
    {
        public static Asset GetLoginPage()
        {
            return API_Core.Gets.GetByType(Constants.Types.Login).FirstOrDefault();
        }

        public static string GetLoginPageURL()
        {
            Asset loginPage = GetLoginPage();

            if (loginPage == null)
                return string.Empty;

            return loginPage.GetNiceURL();
        }

        public static string GetSecureLandingPageURL()
        {
            Asset secureLandingPageAsset = API_Core.Gets.GetByType(Constants.Types.Secure).FirstOrDefault();

            return secureLandingPageAsset == null ? string.Empty : secureLandingPageAsset.GetNiceURL();
        }

        public static bool IsUserAllowedView(Asset asset)
        {
            Asset currentAsset = asset ?? API_Razor.CurrentAsset();

            if (currentAsset == null)
                return true;

            return UserWrapper.IsAuthenticated || !SecurityTrimmingHelper.RequiresAuthenticatedUserToView(currentAsset);            
        }

        public static bool Register(string email, string password, string firstName, string lastName)
        {
            Asset usersFolder = API_Core.Gets.GetByTypeAndSubType(Types.Security, SubTypes.UserFolder).FirstOrDefault();

            UserWrapper newUser = API_Core.Security.CreateUser(usersFolder.PointerID, email, password, firstName, lastName, email, Enums.UserType.USER, true);
            newUser = newUser.Publish();
            
            if(!String.IsNullOrWhiteSpace(newUser.PointerID))
            {
                return true;
            }

            return false;
        }
        

    }
}
