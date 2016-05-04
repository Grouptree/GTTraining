using Grouptree.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT.Training.Core
{
    public class CustomPropertiesTutorial
    {
        /// <summary>
        /// Sets a custom string property on an asset
        /// </summary>
        /// <returns>A string representation of the asset</returns>
        public static string SetCustomStringProperty()
        {
            Grouptree.Core.API_Core.Deleting.DatabaseCleanUp.ClearDatabase();

            var root = Grouptree.Core.API_Core.Gets.GetRoot();

            // When the "CreateNewAsset" method is called, the asset is created in memory
            var asset = API_Core.Create.CreateNewAsset(root.ParentID, "AssetName", "TYPE", "SUBTYPE");

            asset.SetPropertyAsString("CustomProperty", "I don't like cricket!");         

            // creates the asset in the database and publishes it
            asset = asset.Publish();

            return AssetResultHelper.GetAllProperties(asset);
        }

        /// <summary>
        /// Sets a custom string property on an asset using the shorthand method
        /// </summary>
        /// <returns>A string representation of the asset</returns>
        public static string SetCustomStringPropertyShorthand()
        {
            Grouptree.Core.API_Core.Deleting.DatabaseCleanUp.ClearDatabase();

            var root = Grouptree.Core.API_Core.Gets.GetRoot();

            // When the "CreateNewAsset" method is called, the asset is created in memory
            var asset = API_Core.Create.CreateNewAsset(root.ParentID, "AssetName", "TYPE", "SUBTYPE");

            // A string property can be set using the shorthand method (indexers)
            asset["CustomProperty"] = "I don't like cricket!";           

            // creates the asset in the database and publishes it
            asset = asset.Publish();

            return AssetResultHelper.GetAllProperties(asset);
        }

        /// <summary>
        /// Updates an asset's custom property value
        /// </summary>
        /// <returns>A string representation of the asset</returns>
        public static string UpdatingAssetProperty()
        {
            Grouptree.Core.API_Core.Deleting.DatabaseCleanUp.ClearDatabase();

            var root = Grouptree.Core.API_Core.Gets.GetRoot();

            // When the "CreateNewAsset" method is called, the asset is created in memory
            var asset = API_Core.Create.CreateNewAsset(root.ParentID, "AssetName", "TYPE", "SUBTYPE");

            // A string property can be set using the shorthand method (indexers)
            asset["CustomProperty"] = "I don't like cricket!";

            // creates the asset in the database and publishes it
            asset = asset.Publish();

            // creates a draft version of the asset
            Asset assetInDraft = asset.CreateDraft();

            // updates the property created above 
            assetInDraft["CustomProperty"] = "I love it!";
            
            assetInDraft.Publish();

            return AssetResultHelper.GetAllProperties(new List<Asset>
            {
                asset,
                assetInDraft
            });
        }

        /// <summary>
        /// Sets a custom date time property on an asset
        /// </summary>
        /// <returns>A string representation of the asset</returns>
        public static string SetCustomDateTimeProperty()
        {
            Grouptree.Core.API_Core.Deleting.DatabaseCleanUp.ClearDatabase();

            var root = Grouptree.Core.API_Core.Gets.GetRoot();

            // When the "CreateNewAsset" method is called, the asset is created in memory
            var asset = API_Core.Create.CreateNewAsset(root.ParentID, "AssetName", "TYPE", "SUBTYPE");

            asset.SetPropertyAsDateTime("CustomDateTimeProperty", DateTime.Now);            

            // creates the asset in the database and publishes it
            asset = asset.Publish();

            return AssetResultHelper.GetAllProperties(asset);
        }

        /// <summary>
        /// Updates an asset's custom date time property value
        /// </summary>
        /// <returns>A string representation of the asset</returns>
        public static string UpdatingAssetDateTimeProperty()
        {
            Grouptree.Core.API_Core.Deleting.DatabaseCleanUp.ClearDatabase();

            var root = Grouptree.Core.API_Core.Gets.GetRoot();

            // When the "CreateNewAsset" method is called, the asset is created in memory
            var asset = API_Core.Create.CreateNewAsset(root.ParentID, "AssetName", "TYPE", "SUBTYPE");

            asset.SetPropertyAsDateTime("CustomDateTimeProperty", DateTime.Now);

            // creates the asset in the database and publishes it
            asset = asset.Publish();

            // creates a draft version of the asset
            Asset assetInDraft = asset.CreateDraft();

            // updates the property created above 
            assetInDraft.SetPropertyAsDateTime("CustomDateTimeProperty", DateTime.Now.AddYears(1));

            assetInDraft.Publish();

            return AssetResultHelper.GetAllProperties(new List<Asset>
                {
                    asset,
                    assetInDraft
                });
        }

        /// <summary>
        /// Sets a custom numeric property on an asset
        /// A numeric property accepts a float as the value
        /// </summary>
        /// <returns>A string representation of the asset</returns>
        public static string SetCustomNumericProperty()
        {
            Grouptree.Core.API_Core.Deleting.DatabaseCleanUp.ClearDatabase();

            var root = Grouptree.Core.API_Core.Gets.GetRoot();

            // When the "CreateNewAsset" method is called, the asset is created in memory
            var asset = API_Core.Create.CreateNewAsset(root.ParentID, "AssetName", "TYPE", "SUBTYPE");

            asset.SetPropertyAsNumeric("CustomNumericProperty", 123.123);

            // creates the asset in the database and publishes it
            asset = asset.Publish();

            return AssetResultHelper.GetAllProperties(asset);
        }

        /// <summary>
        /// Updates an asset's custom numeric property value
        /// </summary>
        /// <returns>A string representation of the asset</returns>
        public static string UpdatingAssetNumericProperty()
        {
            Grouptree.Core.API_Core.Deleting.DatabaseCleanUp.ClearDatabase();

            var root = Grouptree.Core.API_Core.Gets.GetRoot();

            // When the "CreateNewAsset" method is called, the asset is created in memory
            var asset = API_Core.Create.CreateNewAsset(root.ParentID, "AssetName", "TYPE", "SUBTYPE");

            asset.SetPropertyAsNumeric("CustomNumericProperty", 123.123);

            // creates the asset in the database and publishes it
            asset = asset.Publish();

            // creates a draft version of the asset
            Asset assetInDraft = asset.CreateDraft();

            // updates the property created above 
            assetInDraft.SetPropertyAsNumeric("CustomNumericProperty", 456.456);

            assetInDraft.Publish();

            return AssetResultHelper.GetAllProperties(new List<Asset>
                {
                    asset,
                    assetInDraft
                });
        }

        /// <summary>
        /// Creates a custom dictionary property on the asset        
        /// </summary>
        /// <returns>The custom dictionary. (Dictionary<string, string>)</returns>
        public static Dictionary<string, string> SetCustomDictionaryProperty()
        {
            Grouptree.Core.API_Core.Deleting.DatabaseCleanUp.ClearDatabase();

            var root = Grouptree.Core.API_Core.Gets.GetRoot();

            // When the "CreateNewAsset" method is called, the asset is created in memory
            var asset = API_Core.Create.CreateNewAsset(root.ParentID, "AssetName", "TYPE", "SUBTYPE");

            Dictionary<string, string> customPropertyValues = new Dictionary<string,string>();
            customPropertyValues.Add("Key1", "Value1");
            customPropertyValues.Add("Key2", "Value2");

            asset.SetPropertyAsDictionary("CustomDictionaryProperty", customPropertyValues);

            // creates the asset in the database and publishes it
            asset = asset.Publish();

            // in order to retrieve the custom dictionary properties, 'GetDictionaryProperty' is used
            Dictionary<string, string> retrievedCustomDictionary = asset.GetDictionaryProperty("CustomDictionaryProperty");

            return retrievedCustomDictionary;
        }

    }
}
