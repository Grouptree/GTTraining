using Grouptree.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT.Training.Core
{
    public class GetRootTutorial
    {
        /// <summary>
        /// Retrieves the root asset or creates a new one if no root asset exists.
        /// </summary>
        /// <returns></returns>
        public static string GetRoot()
        {          
            Grouptree.Core.API_Core.Deleting.DatabaseCleanUp.ClearDatabase();

            var root = Grouptree.Core.API_Core.Gets.GetRoot();

            return AssetResultHelper.GetAllProperties(root);
        }
    }
}
