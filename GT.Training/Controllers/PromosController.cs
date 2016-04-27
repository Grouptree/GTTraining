using Grouptree.Core;
using Grouptree.Core.Security;
using Grouptree.Web;
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
    public class PromosController : Controller
    {
        //
        // GET: /Promos/
        public ActionResult Index()
        {
            return View();
        }               

        [HttpPost]
        public void UpdateUserTagViews(string currentAssetPointerID)
        {
            UserTagViewsBL.UpdateCurrentUserTagViews(currentAssetPointerID);
        }

        [HttpGet]
        public string GetPromoForCurrentUser(string currentAssetPointerID)
        {
            Promo promo = PromosBL.GetPromoForCurrentUser(currentAssetPointerID);

            if (promo == null)
                return null;

            return CamelCaseSerializer.Serialize(promo);
        }

        [HttpGet]
        public string GetUserTagCloud()
        {
            if (!UserWrapper.IsAuthenticated)
                return string.Empty;

            List<TagViews> userViews = UserTagViewsBL.GetUserTagViews();

            return CamelCaseSerializer.Serialize(userViews.Select(view => new
                {
                    text = view.Tag,
                    weight = view.NumberOfViews
                }));
        }

        [HttpGet]
        public string GetNewsArticleTagCloud(string newsArticlePointerID)
        {
            List<TagViews> newsArticleTagViews = NewsArticlesBL.GetArticleTagViews(newsArticlePointerID);

            return CamelCaseSerializer.Serialize(newsArticleTagViews.Select(view => new
            {
                text = view.Tag,
                weight = view.NumberOfViews
            }));
        }
      
	}
}