using Grouptree.Core;
using GT.Training.BL.Constants;
using GT.Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT.Training.BL
{
    public class PromosBL
    {
        public static List<Promo> GetPromosForAsset(Asset asset)
        {
            return Convert(asset.GetLinkedAssets(Constants.AssetLinks.PromoLinks)).ToList();
        }

        public static List<Promo> GetPromosForAsset(string assetPointerID)
        {
            return GetPromosForAsset(API_Core.Gets.GetByPID(assetPointerID));
        }

        public static Promo GetPromoForCurrentUser(string assetPointerID)
        {
            List<Promo> promos = GetPromosForAsset(assetPointerID);

            if (!promos.Any())
                return null;

            TagViews mostVisitedTag = UserTagViewsBL.GetUserTagViews().FirstOrDefault();

            if(mostVisitedTag == null)            
                return promos.FirstOrDefault();

            // Retrieve the first promo which has the user's most visited tag or default to the first promo
            return promos.FirstOrDefault(promo => promo.Tags.Any(promoTag => promoTag.Equals(mostVisitedTag.Tag, StringComparison.InvariantCultureIgnoreCase))) ?? promos.FirstOrDefault();
        }

        public static Promo Convert(Asset asset)
        {
            Promo result = new Promo();

            result.Name = asset.Name;
            result.Copy = asset[CustomProperties.Promos.Copy];
            result.URL = asset[CustomProperties.Promos.URL];
            result.ImageURL = asset.GetLinkedAsset(AssetLinks.PromoLinkImage).GetNiceURL();
            result.Tags = API_Core.Tagging.GetAssetsTags(asset).Select(tag => tag.Name).ToList();

            return result;
        }

        public static IEnumerable<Promo> Convert(IEnumerable<Asset> assets)
        {
            foreach(Asset asset in assets)
            {
                yield return Convert(asset);
            }
        }       

    }
}
