using Grouptree.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT.Training.Core
{
    public class GetsTutorial
    {
        /// <summary>
        /// Retrieve all assets by a specific type
        /// </summary>
        /// <returns></returns>
        public static string GetByType()
        {
            // Retrieve all assets by a specific type
            IEnumerable<Asset> assets = API_Core.Gets.GetByType("TYPE");

            return AssetResultHelper.GetAllProperties(assets.ToList());
        }


        public static string GetBySubType()
        {
            IEnumerable<Asset> assets = API_Core.Gets.GetBySubType("SUBTYPE");

            return AssetResultHelper.GetAllProperties(assets.ToList());
        }

    }
}
