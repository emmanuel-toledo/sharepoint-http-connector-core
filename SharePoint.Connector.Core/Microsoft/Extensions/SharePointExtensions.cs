using SharePoint.Connector.Core.Models.Configurations;

namespace SharePoint.Connector.Core.Microsoft.Extensions
{
    /// <summary>
    /// This class contains the main functions to work with different actions of SharePoint.Connector.Core library.
    /// </summary>
    public static class SharePointExtensions
    {
        /// <summary>
        /// This function convert directly a byte array to Base64 string.
        /// </summary>
        /// <param name="data">Content of file.</param>
        /// <returns>Base64 string.</returns>
        public static string ToBase64(this byte[]? data)
        {
            if (data is null || data.Length == 0)
                return string.Empty;
            return Convert.ToBase64String(data);
        }

        /// <summary>
        /// Function to get Relative URL from a SharePoint site URL.
        /// </summary>
        /// <param name="configuration">Single SharePoint context configuration</param>
        /// <returns>Relative URL.</returns>
        public static string GetRelativeURL(this ContextConfiguration configuration)
        {
            string relativeURL = string.Join("/", configuration.SharePointSiteURL.Split("/").Skip(3).ToArray());
            if(relativeURL.Substring(relativeURL.Length - 1) == "/")
                return relativeURL.Remove(relativeURL.Length - 1, 1);
            return relativeURL;
        }
    }
}
