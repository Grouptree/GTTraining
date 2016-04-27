using Grouptree.Core;
using Grouptree.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT.Training.BL
{
    public class UserAuthenticationHelper
    {
        public static bool IsUserAuthenticated()
        {
            return Grouptree.Core.Security.UserWrapper.IsAuthenticated;
        }

        public static UserWrapper GetCurrentUser()
        {
            return Grouptree.Core.Security.UserWrapper.GetCurrent();
        }

        public static Asset GetCurrentUserAsset()
        {
            UserWrapper userWrapper = GetCurrentUser();

            if (userWrapper == null)
                return null;

            return userWrapper.Asset;
        }

        public static bool Login(string username, string password)
        {
            return Grouptree.Core.Security.UserWrapper.AuthenticateForms(username, password, true, false);            
        }

        public static void Logout()
        {
            Grouptree.Core.Security.UserWrapper.LogOff();
        }

    }
}
