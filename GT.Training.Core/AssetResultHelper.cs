using Grouptree.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT.Training.Core
{
    public class AssetResultHelper
    {
        public static string GetAllProperties(Asset asset)
        {
            if (asset == null)
                return "Asset is null";

            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(FormatLine("Version ID", asset.VersionID));
            stringBuilder.AppendLine(FormatLine("Name", asset.Name));
            stringBuilder.AppendLine(FormatLine("Pointer ID", asset.PointerID));
            stringBuilder.AppendLine(FormatLine("Parent ID", asset.ParentID));
            stringBuilder.AppendLine(FormatLine("Live", asset.Live.ToString(CultureInfo.InvariantCulture)));
            stringBuilder.AppendLine(FormatLine("Die", asset.Die.ToString(CultureInfo.InvariantCulture)));
           // stringBuilder.AppendLine(FormatLine("createdBy", asset.CreateUser.FullName));
           // stringBuilder.AppendLine(FormatLine("modifiedBy", asset.ModifyUser.FullName));
            stringBuilder.AppendLine(FormatLine("Branch ID", asset.BranchID));
            stringBuilder.AppendLine(FormatLine("Type", asset.Type));
            stringBuilder.AppendLine(FormatLine("Sub Type", asset.SubType));
            stringBuilder.AppendLine(FormatLine("Status", asset.Status.ToString()));
            stringBuilder.AppendLine(FormatLine("Position", asset.Position == null ? string.Empty : asset.Position.ToString()));
            stringBuilder.AppendLine(FormatLine("CreateDate", asset.CreateDate.ToString(CultureInfo.InvariantCulture)));
            stringBuilder.AppendLine(FormatLine("Modified Date", asset.ModDate.ToString(CultureInfo.InvariantCulture)));
            stringBuilder.AppendLine(FormatLine("Save Count", asset.SaveCount.ToString()));
            stringBuilder.AppendLine(FormatLine("Reason Type", asset.ReasonType));
            stringBuilder.AppendLine(FormatLine("Base Version ID", asset.BaseVID));

            if (asset.StringProperties != null)
                foreach (var stringProperty in asset.StringProperties)
                {
                    stringBuilder.AppendLine(FormatLine(stringProperty.Key, stringProperty.Value));
                }

            if (asset.NumericProperties != null)
                foreach (var numericProperty in asset.NumericProperties)
                {
                    stringBuilder.AppendLine(FormatLine(numericProperty.Key, numericProperty.Value.ToString(CultureInfo.InvariantCulture)));
                }

            if (asset.DateProperties != null)
                foreach (var dateProperty in asset.DateProperties)
                {
                    stringBuilder.AppendLine(FormatLine(dateProperty.Key, dateProperty.Value.ToString(CultureInfo.InvariantCulture)));
                }

            if (asset.Contents != null)
                foreach (var content in asset.Contents)
                {
                    stringBuilder.AppendLine(FormatLine(content.Key, content.Value));
                }            

            return stringBuilder.ToString();
        }

        public static string GetAllProperties(List<Asset> assets)
        {
            StringBuilder sb = new StringBuilder();

            foreach(Asset asset in assets)
            {
                string assetProperties = GetAllProperties(asset);

                sb.AppendLine();
                sb.AppendLine(assetProperties);
            }

            return sb.ToString();
        }        

        public static string GetChildrenAsString(Asset topNodeAsset, int deep = 0)
        {
            if(topNodeAsset == null)
            {
                return string.Empty;
            }

            StringBuilder result = new StringBuilder();

            result.AppendLine(topNodeAsset.Name);

            List<Asset> children = topNodeAsset.GetChildren().ToList();

            if (children.Any())
            {
                result.AppendLine("Children: ".PadLeft(deep));

                foreach (Asset childAsset in children)
                {
                    result.AppendLine(GetChildrenAsString(childAsset, (deep += 1)).PadLeft(deep));
                }
            }

            return result.ToString();
        }

        private static string FormatLine(string key, string value)
        {
            return String.Format("{0}: <strong>{1}</strong><br/>", key, value);
        }
    }
}