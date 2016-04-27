using Grouptree.Core;
using Grouptree.Core.Documents;
using Grouptree.Metadata;
using GT.Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT.Training.BL
{
    public class DocumentsBL
    {
        public static List<Document> GetDocuments()
        {
            Asset documentsFolder = API_Core.Gets.GetByTypeAndSubType(Constants.Types.AppSecureFolder, Constants.SubTypes.DocumentFolder).FirstOrDefault();

            if (documentsFolder == null)
                return new List<Document>();

            return Convert(documentsFolder.GetChildren()).ToList();
        }

        private static Document Convert(Asset asset)
        {
            DocumentWrapper documentWrapper = DocumentWrapper.Get(asset);

            Document result = new Document();
            result.Title = documentWrapper.Name;
            result.Link = documentWrapper.Href;
            result.IconClass = GetIcon(documentWrapper.Href);       
            return result;
        }

        private static string GetIcon(string fileName)
        {
            if (fileName.EndsWith(".xlsx", StringComparison.InvariantCultureIgnoreCase))
            {
                return "fa-file-excel-o";
            }

            if (fileName.EndsWith(".zip", StringComparison.InvariantCultureIgnoreCase))
            {
                return "fa-file-zip-o";
            }

            if(fileName.EndsWith(".docx", StringComparison.InvariantCultureIgnoreCase))
            {
                return "fa-file-word-o";
            }

            return "fa-file";

        }

        private static IEnumerable<Document> Convert(IEnumerable<Asset> assets)
        {
            foreach(Asset asset in assets)
            {
                yield return Convert(asset);
            }
        }

    }
}
