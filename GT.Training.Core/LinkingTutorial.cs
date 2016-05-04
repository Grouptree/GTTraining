using Grouptree.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT.Training.Core
{
    public class LinkingTutorial
    {
        /// <summary>
        /// Links two separate assets which are not related
        /// </summary>
        /// <returns>A string representation of the link asset</returns>
        public static string LinkAssets()
        {
            Grouptree.Core.API_Core.Deleting.DatabaseCleanUp.ClearDatabase();

            var root = API_Core.Gets.GetRoot();

            Asset a1 = API_Core.Create.CreateNewAsset(root.PointerID, "A1", "TYPE", "SUBTYPE").Publish();
            Asset a2 = API_Core.Create.CreateNewAsset(root.PointerID, "A2", "TYPE", "SUBTYPE").Publish();
            Asset a3 = API_Core.Create.CreateNewAsset(root.PointerID, "A3", "TYPE", "SUBTYPE").Publish();

            Asset a4 = API_Core.Create.CreateNewAsset(a1.PointerID, "A4", "TYPE", "SUBTYPE").Publish();
            Asset a5 = API_Core.Create.CreateNewAsset(a1.PointerID, "A5", "TYPE", "SUBTYPE").Publish();
            Asset a6 = API_Core.Create.CreateNewAsset(a5.PointerID, "A6", "TYPE", "SUBTYPE").Publish();

            // link two assets (a3 and a5)
            Asset linkAsset = API_Core.Linking.CreateLink(a3, a5, "LinkingTwoAssets");

            return AssetResultHelper.GetAllProperties(linkAsset); //API_Core.Linking.GetLinkedAsset(a3, "LinkingTwoAssets"));
        }

        /// <summary>
        /// Retrieves a link asset
        /// </summary>
        /// <returns>A string representation of the link asset</returns>
        public static string RetrieveLinkedAsset()
        {
            Grouptree.Core.API_Core.Deleting.DatabaseCleanUp.ClearDatabase();

            var root = API_Core.Gets.GetRoot();

            Asset a1 = API_Core.Create.CreateNewAsset(root.PointerID, "A1", "TYPE", "SUBTYPE").Publish();
            Asset a2 = API_Core.Create.CreateNewAsset(root.PointerID, "A2", "TYPE", "SUBTYPE").Publish();
            Asset a3 = API_Core.Create.CreateNewAsset(root.PointerID, "A3", "TYPE", "SUBTYPE").Publish();

            Asset a4 = API_Core.Create.CreateNewAsset(a1.PointerID, "A4", "TYPE", "SUBTYPE").Publish();
            Asset a5 = API_Core.Create.CreateNewAsset(a1.PointerID, "A5", "TYPE", "SUBTYPE").Publish();
            Asset a6 = API_Core.Create.CreateNewAsset(a5.PointerID, "A6", "TYPE", "SUBTYPE").Publish();

            API_Core.Linking.CreateLink(a3, a5, "LinkingTwoAssets");

            Asset linkAsset = API_Core.Linking.GetLinkedAsset(a3, "LinkingTwoAssets");

            return AssetResultHelper.GetAllProperties(linkAsset);
        }

    }
}
