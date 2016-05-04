using Grouptree.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT.Training.Core
{
    public class ArchivingTutorial
    {
        /// <summary>
        /// Creates a new asset and archives it 
        /// Once an asset is archived, it cannot be retrieved by its pointer ID
        /// </summary>
        /// <returns>Since the asset is archived, no asset is returned (null).</returns>
        public static string ArchiveAsset()
        {
            Grouptree.Core.API_Core.Deleting.DatabaseCleanUp.ClearDatabase();

            var root = Grouptree.Core.API_Core.Gets.GetRoot();

            // When the "CreateNewAsset" method is called, the asset is created in memory
            var asset = API_Core.Create.CreateNewAsset(root.ParentID, "AssetName", "TYPE", "SUBTYPE");

            // creates the asset in the database and publishes it
            asset = asset.Publish();

            // Archive the asset
            API_Core.Archiving.ArchiveAsset(asset);                      

            // Attempt to retrieve the asset by its pointer ID
            // The asset should not be retrieved because it has been archived
            Asset archivedAsset = API_Core.Gets.GetByPID(asset.PointerID);

            return AssetResultHelper.GetAllProperties(archivedAsset);
        }

        /// <summary>
        /// Creates a new asset and archives it 
        /// Once an asset is archived, it cannot be retrieved by its pointer ID, however it is still possible to retrieve it by its version ID
        /// </summary>
        /// <returns>A string representation of the archived asset.</returns>
        public static string RetrievingArchivedAssetsByVersionID()
        {
            Grouptree.Core.API_Core.Deleting.DatabaseCleanUp.ClearDatabase();

            var root = Grouptree.Core.API_Core.Gets.GetRoot();

            // When the "CreateNewAsset" method is called, the asset is created in memory
            var asset = API_Core.Create.CreateNewAsset(root.ParentID, "AssetName", "TYPE", "SUBTYPE");

            // creates the asset in the database and publishes it
            asset = asset.Publish();

            // Archive the asset
            API_Core.Archiving.ArchiveAsset(asset);            

            // Retrieve the asset by its version ID
            Asset archivedAsset = API_Core.Gets.GetByVID(asset.VersionID);

            return AssetResultHelper.GetAllProperties(archivedAsset);
        } 
    }
}
