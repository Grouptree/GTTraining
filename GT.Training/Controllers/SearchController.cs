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
    public class SearchController : Controller
    {     
        HashSet<string> resultTypes = new HashSet<string>
        {
            GT.Training.BL.Constants.Types.Site,
            GT.Training.BL.Constants.Types.News,
            GT.Training.BL.Constants.Types.Secure,
            GT.Training.BL.Constants.Types.Media            
        };

        [HttpGet]
        public string Search(string searchString)
        {
            List<SearchResult> searchResults = SearchBL.Search(searchString, resultTypes);            

            return CamelCaseSerializer.Serialize(searchResults);
        }
        
        public string GetCurrentSearchText()
        {
            return Request.QueryString["searchText"];
        }

	}
}