using Grouptree.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT.Training.Core
{
    public class VersioningTutorial
    {      
        /// <summary>
        /// Creates a new version of an asset
        /// </summary>
        /// <returns>A string representation of both asset versions.</returns>
        public static string CreateNewAssetVersion()
        {
            Grouptree.Core.API_Core.Deleting.DatabaseCleanUp.ClearDatabase();
            var root = Grouptree.Core.API_Core.Gets.GetRoot();
            var asset = API_Core.Create.CreateNewAsset(root.ParentID, "AssetName", "TYPE", "SUBTYPE");
            asset = asset.Publish();

            // Creates a new draft version of the asset and publishes it            
            var newAssetVersion = asset.CreateDraft();
            newAssetVersion.Publish();

            return AssetResultHelper.GetAllProperties(new List<Asset>
                {
                    asset,
                    newAssetVersion
                });
        }

        /// <summary>
        /// Retrieves all the versions for an asset (this includes both archived and published versions)
        /// </summary>
        /// <returns>A string representation of all the asset versions.</returns>
        public static string RetrieveAllAssetVersions()
        {
            Grouptree.Core.API_Core.Deleting.DatabaseCleanUp.ClearDatabase();
            var root = Grouptree.Core.API_Core.Gets.GetRoot();
            var asset = API_Core.Create.CreateNewAsset(root.ParentID, "AssetName", "TYPE", "SUBTYPE");
            asset["Version"] = "Version 1";
            asset = asset.Publish();

            // Create a new version           
            asset = asset.CreateDraft();
            asset["Version"] = "Version 2";
            asset.Publish();

            // Create a new version           
            asset = asset.CreateDraft();
            asset["Version"] = "Version 3";
            asset.Publish();

            // Retrieves all the asset versions
            List<Asset> assetVersions = API_Core.Versions.GetAllVersions(asset).ToList();

            return AssetResultHelper.GetAllProperties(assetVersions);         
        }

        /// <summary>
        /// Retrieves all the archived versions of an asset (does not retrieve currently live asset)
        /// </summary>
        /// <returns>A string representation of all the arvhived asset versions.</returns>
        public static string RetrieveAllAssetArchivedVersions()
        {
            Grouptree.Core.API_Core.Deleting.DatabaseCleanUp.ClearDatabase();
            var root = Grouptree.Core.API_Core.Gets.GetRoot();
            var asset = API_Core.Create.CreateNewAsset(root.ParentID, "AssetName", "TYPE", "SUBTYPE");
            asset["Version"] = "Version 1";
            asset = asset.Publish();

            // Create a new version           
            asset = asset.CreateDraft();
            asset["Version"] = "Version 2";
            asset.Publish();

            // Create a new version           
            asset = asset.CreateDraft();
            asset["Version"] = "Version 3";
            asset.Publish();

            // Retrieves all the asset versions
            List<Asset> archivedAssetVersions = API_Core.Versions.GetArchivedVersions(asset).ToList();

            return AssetResultHelper.GetAllProperties(archivedAssetVersions);
        }

        /// <summary>
        /// Retrieves an asset by its version ID
        /// Any asset can be retrieved by its version ID (an archived asset will also be retrieved)
        /// </summary>
        /// <returns>A string representation of the retrieved asset.</returns>
        public static string RetrieveSpecificAssetVersionByVersionID()
        {
            Grouptree.Core.API_Core.Deleting.DatabaseCleanUp.ClearDatabase();
            var root = Grouptree.Core.API_Core.Gets.GetRoot();
            var assetV1 = API_Core.Create.CreateNewAsset(root.ParentID, "AssetName", "TYPE", "SUBTYPE");
            assetV1["Version"] = "Version 1";
            assetV1 = assetV1.Publish();

            // Create a new version           
            var assetV2 = assetV1.CreateDraft();
            assetV2["Version"] = "Version 2";
            assetV2.Publish();

            // Create a new version           
            var assetV3 = assetV2.CreateDraft();
            assetV3["Version"] = "Version 3";
            assetV3.Publish();

            // Retrieve an asset by its specific version ID
            Asset firstAssetVersion = API_Core.Gets.GetByVID(assetV1.VersionID);

            return AssetResultHelper.GetAllProperties(firstAssetVersion);
        }
    }
}
