using Grouptree.Core;
using GT.Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT.Training.BL
{
    public class TwitterFeedsBL
    {
        public static TwitterFeed GetTwitterFeedForAsset(Asset asset)
        {
            if (asset == null)
                return null;

            Asset twitterFeedAsset = asset.GetLinkedAsset(Constants.AssetLinks.TwitterFeed);

            if (twitterFeedAsset == null)
                return null;

            return Convert(twitterFeedAsset);
        }

        public static TwitterFeed Convert(Asset asset)
        {
            TwitterFeed result = new TwitterFeed();

            result.ScreenName = asset[Constants.TwitterFeeds.ScreenName];
            result.TwitterFeedID = asset[Constants.TwitterFeeds.TwitterFeedID];
            result.FeedLink = asset[Constants.TwitterFeeds.FeedLink];

            return result;
        }

    }
}
