using Grouptree.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT.Training.BL
{
    public class AssetsHelper
    {
        public static bool AreSame(Asset asset, Asset assetToCompare)
        {
            return asset.PointerID.Equals(assetToCompare.PointerID);
        }

        public static bool IsAncestorOf(Asset asset, Asset ancestorOf)
        {
            IEnumerable<Grouptree.Core.Asset> ancestors = ancestorOf.GetAncestors();

            foreach (Grouptree.Core.Asset anc in ancestors)
            {
                if(AreSame(asset, anc)) {
                    return true;
                }             
            }

            return false;
        }

    }
}
