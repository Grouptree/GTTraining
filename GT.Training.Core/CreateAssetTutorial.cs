using Grouptree.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT.Training.Core
{
    public class CreateAssetTutorial
    {
        /// <summary>
        /// Creates an asset as an orphan in draft state
        /// </summary>
        /// <returns>A string representation of the asset.</returns>
        public static string CreateAnOrphanAssetInDraft()
        {
            Grouptree.Core.API_Core.Deleting.DatabaseCleanUp.ClearDatabase();

            Asset asset = API_Core.Create.CreateNewAsset(string.Empty, "AssetName", "TYPE", "SUBTYPE");
            asset = asset.Save();

            return AssetResultHelper.GetAllProperties(asset);
        }

        /// <summary>
        /// Creates an asset in draft state under the root asset
        /// </summary>
        /// <returns>A string representation of the asset.</returns>
        public static string CreateAssetInDraft()
        {
            Grouptree.Core.API_Core.Deleting.DatabaseCleanUp.ClearDatabase();

            var root = Grouptree.Core.API_Core.Gets.GetRoot();

            // When the "CreateNewAsset" method is called, the asset is created in memory
            var asset = API_Core.Create.CreateNewAsset(root.ParentID, "AssetName", "TYPE", "SUBTYPE");

            // saves the asset to the database (in 'Draft') state
            asset = asset.Save();

            return AssetResultHelper.GetAllProperties(asset);
        }

        /// <summary>
        /// Creates an asset under the root asset and publishes it
        /// </summary>
        /// <returns>A string representation of the asset.</returns>
        public static string CreateAssetAndPublishIt()
        {            
            Grouptree.Core.API_Core.Deleting.DatabaseCleanUp.ClearDatabase();
                       
            var root = Grouptree.Core.API_Core.Gets.GetRoot();

            // When the "CreateNewAsset" method is called, the asset is created in memory
            var asset = API_Core.Create.CreateNewAsset(root.ParentID, "AssetName", "TYPE", "SUBTYPE");

            // creates the asset in the database and publishes it
            asset = asset.Publish();

            return AssetResultHelper.GetAllProperties(asset);
        }       

    }
}
