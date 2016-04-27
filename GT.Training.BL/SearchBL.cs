using Grouptree.Core;
using Grouptree.Core.Documents;
using Grouptree.Metadata;
using GT.Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT.Training.BL
{
    public class SearchBL
    {
        public static string GetSearchPageURL()
        {
            Asset searchPage = API_Core.Gets.GetByTypeAndSubType(Constants.Types.Search, Constants.SubTypes.Results).FirstOrDefault();
            
            if(searchPage == null)
                return string.Empty;

            return searchPage.GetNiceURL();
        }

        public static List<SearchResult> Search(string searchString, HashSet<string> types = null)
        {
            IEnumerable<Grouptree.Core.Data.SearchResult> allSearchResult = API_Core.Search.TextSearch(searchString);

            if(allSearchResult == null || !allSearchResult.Any()) {
                return new List<SearchResult>();
            }            

            IEnumerable<Asset> searchResultAssets = allSearchResult.Where(searchResult => searchResult.Asset != null).Select(searchResult => searchResult.Asset);
            
            if(types != null)
            {
                searchResultAssets = searchResultAssets.Where(asset => types.Contains(asset.Type));
            }            

            return Convert(SecurityTrimmingHelper.SecurityTrim(searchResultAssets)).ToList();
        }

        private static SearchResult Convert(Asset asset)
        {
            SearchResult result = new SearchResult();

            result.DisplayText = asset.Name;

            // special treatment for comments
            if (asset.SubType.Equals(Constants.SubTypes.Comment))
            {
                result.URL = API_Core.Gets.GetByPID(asset.ParentID).GetNiceURL();
            }
            else if(asset.SubType.Equals(Constants.SubTypes.Document))
            {
                result.URL = DocumentWrapper.Get(asset).Href;
            }
            else
            {
                result.URL = asset.GetNiceURL();
            }

            result.IconClass = ElementDefinitionWrapper.GetElementDefinitionAsset(asset).Icon;

            return result;
        }

        private static IEnumerable<SearchResult> Convert(IEnumerable<Asset> assets)
        {
            foreach(Asset asset in assets)
            {
                yield return Convert(asset);
            }
        }

    }
}
