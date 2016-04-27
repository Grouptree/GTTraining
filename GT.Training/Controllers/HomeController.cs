using Grouptree.Core;
using Grouptree.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GT.Training.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Response.Redirect("/Home");

            return View();
        }           
    }
}