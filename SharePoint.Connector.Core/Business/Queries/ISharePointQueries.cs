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
        /// Function to get the list of Library Documents in a SharePoint site.
        /// </summary>
        /// <returns>Library Documents collection.</returns>
        Task<ICollection<SPLibraryDocuments>> GetLibraryDocumentsAsync();

        /// <summary>
        /// Function to get the usage information of a SharePoint site.
        /// </summary>
        /// <returns>Site Usage model.</returns>
        Task<SPSiteUsage?> GetSiteUsageAsync();

        /// <summary>
        /// Function to get a resource from Recycle bin using an unique identifier.
        /// </summary>
        /// <param name="resourceId">Recycle bin resource unique identifier.</param>
        /// <returns>Recycle bin resource object.</returns>
        Task<SPRecycleResource?> GetRecycleBinResourceByIdAsync(Guid resourceId);

        /// <summary>
        /// Function to download file content using relative path location and file name.
        /// </summary>
        /// <param name="relativeURL">Relative resource path location.</param>
        /// <param name="resourceName">Resource name.</param>
        /// <returns>File byte array content.</returns>
        Task<byte[]?> GetFileContentAsync(string relativeURL, string resourceName);

        /// <summary>
        /// Function to get file information using relative path location and file name.
        /// </summary>
        /// <param name="relativeURL">Relative resource path location.</param>
        /// <param name="resourceName">Resource name.</param>
        /// <returns>File byte array content.</returns>
        Task<SPFile?> GetFileAsync(string relativeURL, string resourceName);

        /// <summary>
        /// Function to get files information from a relative url location.
        /// </summary>
        /// <param name="relativeURL">Relative resource path location.</param>
        /// <returns>File byte array content.</returns>
        Task<ICollection<SPFile>> GetFilesAsync(string relativeURL);
    }
}
