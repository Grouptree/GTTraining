using Grouptree.Core;
using Grouptree.Core.Wrappers;
using GT.Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT.Training.BL
{
    public class NewsArticlesBL
    {
        public static List<NewsArticle> GetNewsArticles()
        {
            var root = API_Core.Gets.GetByTypeAndSubType(Constants.Types.NewsIndex, Constants.SubTypes.Landing).FirstOrDefault();

            if (root == null)
                return new List<NewsArticle>();

            return Convert(root.GetChildren().OrderByDescending(asset => asset.GetPropertyAsDateTime(Constants.NewsArticles.ArticleDate))).ToList();
        }

        public static List<NewsArticle> GetRelatedArticles(Asset asset)
        {          
            if(asset == null)
                return new List<NewsArticle>();
            
            // retrieve all news articles which are related by tag
            IEnumerable<Asset> tagRelatedNewsArticles = GetRelatedAssets(asset).Where(assetByTag => assetByTag.Type.Equals(Constants.Types.News) && assetByTag.SubType.Equals(Constants.SubTypes.Article));

            return Convert(tagRelatedNewsArticles.OrderByDescending(newsArticle => newsArticle.GetPropertyAsDateTime(Constants.NewsArticles.ArticleDate))).ToList();
        }

        public static string GetNewsArticleImageURL(Asset asset)
        {
            if (asset == null)
                return string.Empty;

            Asset newsImageAsset = Grouptree.Core.API_Core.Linking.GetLinkedAsset(asset, GT.Training.BL.Constants.AssetLinks.NewsImage);

            if (newsImageAsset == null)
                return string.Empty;

            return "/File.axd?PointerID=" + newsImageAsset.PointerID;
        }

        private static IEnumerable<Asset> GetRelatedAssets(Asset asset)
        {
            var tags = API_Core.Tagging.GetAssetsTags(asset);

            if (tags == null || !tags.Any())
            {
                return Enumerable.Empty<Asset>();
            }

            return API_Core.Tagging.FindAssetsByTags(tags)
                    .Where(assetByTag => assetByTag.Value.PointerID != asset.PointerID).Select(assetsByTag => assetsByTag.Value);
        }

        private static NewsArticle Convert(Asset asset)
        {
            NewsArticle result = new NewsArticle();

            result.Title = asset.Name;
            result.URL = asset.GetNiceURL();

            Asset articleImage = Grouptree.Core.API_Core.Linking.GetLinkedAsset(asset, Constants.AssetLinks.NewsImage);
            
            if(articleImage != null)
            {
                result.ImageURL = "/File.axd?PointerID=" + articleImage.PointerID;
            }

            result.ArticleDate = asset[Constants.NewsArticles.ArticleDate];

            result.Content = System.Text.RegularExpressions.Regex.Replace(asset.GetContent(Constants.NewsArticles.MainPanel), @"<[^>]*>", "", System.Text.RegularExpressions.RegexOptions.None);

            if(!String.IsNullOrWhiteSpace(result.Content))
            {
                result.TrimmedContent = result.Content.Length > 500 ? (result.Content.Substring(0, 500) + "...") : result.Content;
            }

            result.Tags = API_Core.Tagging.GetAssetsTags(asset).Select(tag => tag.Name).ToArray();

            return result;
        }

        public static List<TagViews> GetArticleTagViews(string newsArticlePointerID)
        {
            Asset newsArticle = API_Core.Gets.GetByPID(newsArticlePointerID);

            List<TagViews> result = new List<TagViews>();

            if (newsArticle == null)
                return result;

            List<TagWrapper> articleTags = API_Core.Tagging.GetAssetsTags(newsArticle);

            if (articleTags == null || !articleTags.Any())
                return result;

            foreach(TagWrapper tag in articleTags)
            {
                result.Add(new TagViews
                {
                    Tag = tag.Name,
                    NumberOfViews = GetNumberOfArticlesWithTag(tag.Name, newsArticlePointerID)
                });
            }

            return result;
        }

        private static IEnumerable<NewsArticle> Convert(IEnumerable<Asset> assets)
        {
            foreach(Asset asset in assets)
            {
                yield return Convert(asset);
            }
        }

        public static int GetNumberOfArticlesWithTag(string tag, string excludePointerID = null)
        {
            return API_Core.Gets.GetByTypeAndSubType(Constants.Types.News, Constants.SubTypes.Article)
                .Where(newsArticle => String.IsNullOrWhiteSpace(excludePointerID) || !newsArticle.ParentID.Equals(excludePointerID))
                .Count(article => API_Core.Tagging.GetAssetsTags(article)
                .Any(articleTag => articleTag.Name.Equals(tag, StringComparison.InvariantCulture)));
        }

    }
}
