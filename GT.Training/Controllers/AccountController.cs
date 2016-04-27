using Grouptree.Core;
using Grouptree.Core.Security;
using GT.Training.BL;
using GT.Training.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GT.Training.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public string Login(string username, string password)
        {
            dynamic authenticationResult = new {
                                               message = "Successfully logged in",
                                               redirectURL = ""
                                           };

            if(UserAuthenticationHelper.Login(username, password))
            {
                return CamelCaseSerializer.Serialize(new
                {
                    message = "Successfully logged in.",
                    redirectURL = AuthenticationBL.GetSecureLandingPageURL(),
                    successful = true
                });                             
            }
            else
            {
                return CamelCaseSerializer.Serialize(new
                {
                    message = "Failed to login.",                    
                    successful = false
                });                       
            }       
        }

        [HttpGet]
        public void Logout()
        {
            UserAuthenticationHelper.Logout();
            Response.Redirect(AuthenticationBL.GetLoginPageURL());
        }
       
        [HttpPost]
        public string Register(string email, string password, string firstName, string lastName)
        {
            if(AuthenticationBL.Register(email, password, firstName, lastName))
            {
                return CamelCaseSerializer.Serialize(new
                {
                    message = "Successfully registered.",
                    redirectURL = AuthenticationBL.GetLoginPageURL(),
                    successful = true
                });
            }
            else
            {
                return CamelCaseSerializer.Serialize(new
                {         
                    successful = false
                });
            }
        }

    }
}