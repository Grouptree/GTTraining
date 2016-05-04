using Grouptree.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT.Training.Core
{
    public class HierarchyTutorial
    {
        /// <summary>
        /// Creates a hiearchical structure of assets
        ///         Root
        ///      A1  A2  A3
        ///   A4   A5
        ///         A6
        /// </summary>     
        public static void CreateHierarchyStructure()
        {
            Grouptree.Core.API_Core.Deleting.DatabaseCleanUp.ClearDatabase();

            var root = API_Core.Gets.GetRoot();

            Asset a1 = API_Core.Create.CreateNewAsset(root.PointerID, "A1", "TYPE", "SUBTYPE").Publish();
            Asset a2 = API_Core.Create.CreateNewAsset(root.PointerID, "A2", "TYPE", "SUBTYPE").Publish();
            Asset a3 = API_Core.Create.CreateNewAsset(root.PointerID, "A3", "TYPE", "SUBTYPE").Publish();

            Asset a4 = API_Core.Create.CreateNewAsset(a1.PointerID, "A4", "TYPE", "SUBTYPE").Publish();
            Asset a5 = API_Core.Create.CreateNewAsset(a1.PointerID, "A5", "TYPE", "SUBTYPE").Publish();
            Asset a6 = API_Core.Create.CreateNewAsset(a5.PointerID, "A6", "TYPE", "SUBTYPE").Publish();
        }

        /// <summary>
        /// Retrieves the descendants of the root node in a flat structure
        /// </summary>     
        /// <returns>A string representation of all the root's descendants</returns>
        public static string RetrieveAssetDescendants()
        {
            Grouptree.Core.API_Core.Deleting.DatabaseCleanUp.ClearDatabase();

            var root = API_Core.Gets.GetRoot();

            Asset a1 = API_Core.Create.CreateNewAsset(root.PointerID, "A1", "TYPE", "SUBTYPE").Publish();
            Asset a2 = API_Core.Create.CreateNewAsset(root.PointerID, "A2", "TYPE", "SUBTYPE").Publish();
            Asset a3 = API_Core.Create.CreateNewAsset(root.PointerID, "A3", "TYPE", "SUBTYPE").Publish();

            Asset a4 = API_Core.Create.CreateNewAsset(a1.PointerID, "A4", "TYPE", "SUBTYPE").Publish();
            Asset a5 = API_Core.Create.CreateNewAsset(a1.PointerID, "A5", "TYPE", "SUBTYPE").Publish();
            Asset a6 = API_Core.Create.CreateNewAsset(a5.PointerID, "A6", "TYPE", "SUBTYPE").Publish();

            // Retrieves the root descendants in a list
            List<Asset> rootDescendants = root.GetDescendants().ToList();

            return AssetResultHelper.GetAllProperties(rootDescendants);
        }

        /// <summary>
        /// Retrieves the ancestors of the bottom most node in a flat structure
        /// </summary>     
        /// <returns>A string representation of all the a6's ancestors</returns>
        public static string RetrieveAssetAncestors()
        {
            Grouptree.Core.API_Core.Deleting.DatabaseCleanUp.ClearDatabase();

            var root = API_Core.Gets.GetRoot();

            Asset a1 = API_Core.Create.CreateNewAsset(root.PointerID, "A1", "TYPE", "SUBTYPE").Publish();
            Asset a2 = API_Core.Create.CreateNewAsset(root.PointerID, "A2", "TYPE", "SUBTYPE").Publish();
            Asset a3 = API_Core.Create.CreateNewAsset(root.PointerID, "A3", "TYPE", "SUBTYPE").Publish();

            Asset a4 = API_Core.Create.CreateNewAsset(a1.PointerID, "A4", "TYPE", "SUBTYPE").Publish();
            Asset a5 = API_Core.Create.CreateNewAsset(a1.PointerID, "A5", "TYPE", "SUBTYPE").Publish();
            Asset a6 = API_Core.Create.CreateNewAsset(a5.PointerID, "A6", "TYPE", "SUBTYPE").Publish();

            // Retrieves the list of ancestors for the A6 assest (bottom most node)
            List<Asset> a6Ancestors = a6.GetAncestors().ToList();

            return AssetResultHelper.GetAllProperties(a6Ancestors);
        }       

        public static string RetrieveTree()
        {
            Grouptree.Core.API_Core.Deleting.DatabaseCleanUp.ClearDatabase();

            var root = API_Core.Gets.GetRoot();

            Asset a1 = API_Core.Create.CreateNewAsset(root.PointerID, "A1", "TYPE", "SUBTYPE").Publish();
            Asset a2 = API_Core.Create.CreateNewAsset(root.PointerID, "A2", "TYPE", "SUBTYPE").Publish();
            Asset a3 = API_Core.Create.CreateNewAsset(root.PointerID, "A3", "TYPE", "SUBTYPE").Publish();

            Asset a4 = API_Core.Create.CreateNewAsset(a1.PointerID, "A4", "TYPE", "SUBTYPE").Publish();
            Asset a5 = API_Core.Create.CreateNewAsset(a1.PointerID, "A5", "TYPE", "SUBTYPE").Publish();
            Asset a6 = API_Core.Create.CreateNewAsset(a5.PointerID, "A6", "TYPE", "SUBTYPE").Publish();

            return AssetResultHelper.GetChildrenAsString(root);
        }

    }
}
