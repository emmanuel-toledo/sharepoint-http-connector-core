using SharePoint.Connector.Core.Models;

namespace SharePoint.Connector.Core.Business.Queries
{
    /// <summary>
    /// Interface for queries requests.
    /// </summary>
    public interface ISharePointQueries
    {
        /// <summary>
        /// Function to validate if exists a folder in Sharepoint site.
        /// </summary>
        /// <param name="relativeURL">Resource's relative url.</param>
        /// <returns>Folder existence.</returns>
        Task<bool> ExistsResourceAsync(string relativeURL);

        /// <summary>
        /// Function to validate if exists a file in Sharepoint using relative URL and resource name.
        /// </summary>
        /// <param name="relativeURL">Resource's relative url.</param>
        /// <param name="resourceName">File name to validate.</param>
        /// <returns>File existence.</returns>
        Task<bool> ExistsResourceAsync(string relativeURL, string resourceName);

        /// <summary>
        /// Function to get the list of Library Documents in a SharePoint site.
        /// </summary>
        /// <returns>Library Documents collection.</returns>
        Task<ICollection<SPLibraryDocuments>> LibraryDocumentsAsync();

        /// <summary>
        /// Function to get the usage information of a SharePoint site.
        /// </summary>
        /// <returns>Site Usage model.</returns>
        Task<SPSiteUsage?> SiteUsageAsync();

        /// <summary>
        /// Function to get a resource from recycled bin using an unique identifier.
        /// </summary>
        /// <param name="resourceId">Recycled bin resource unique identifier.</param>
        /// <returns>Recycled bin resource object.</returns>
        Task<SPRecycledResource?> RecycledBinResourceAsync(Guid resourceId);
    }
}
