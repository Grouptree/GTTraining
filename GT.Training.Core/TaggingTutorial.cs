using Grouptree.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT.Training.Core
{
    public class TaggingTutorial
    {
        public static void CreateTag(Asset asset)
        {
            
        }

        //TODO: fix this tutorial
        public static void GetRelatedArticles(Asset asset)
        {
            var tags = API_Core.Tagging.GetAssetsTags(asset);

            var related = API_Core.Tagging.FindAssetsByTags(tags);



        }
    }
}
