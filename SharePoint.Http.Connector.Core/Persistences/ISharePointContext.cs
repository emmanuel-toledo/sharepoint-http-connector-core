using SharePoint.Http.Connector.Core.Models;

namespace SharePoint.Http.Connector.Core.Persistences
{
    /// <summary>
    /// This interface contains all the main methods to be used in Sharepoint Data Connector.
    /// </summary>
    public interface ISharePointContext
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
        /// Function to get Library Documents collection.
        /// </summary>
        /// <returns>Library Documents collection.</returns>
        Task<ICollection<SPLibraryDocuments>> GetLibraryDocumentsAsync();

        /// <summary>
        /// Function to get the usage information of a SharePoint site.
        /// </summary>
        /// <returns>Site Usage model.</returns>
        Task<SPSiteUsage?> GetSiteUsageAsync();

        /// <summary>
        /// Fuction to retrive information of a resource that is in recycle bin using an unique identifier.
        /// </summary>
        /// <param name="resourceId">Resource unique identifier.</param>
        /// <returns>Recycle bin resource information.</returns>
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

        /// <summary>
        /// Function to delete a folder resource from a specific path.
        /// </summary>
        /// <param name="relativeURL">Folder resource's relative url.</param>
        /// <returns>Deleted resource from Sharepoint.</returns>
        Task<bool> DeleteFolderAsync(string relativeURL);

        /// <summary>
        /// Function to delete a file from a specific path and file name.
        /// </summary>
        /// <param name="relativeURL">Resource's relative url.</param>
        /// <returns>Deleted file from Sharepoint.</returns>
        Task<bool> DeleteFileAsync(string relativeURL);

        /// <summary>
        /// Function to delete a file from a specific path and file name.
        /// </summary>
        /// <param name="relativeURL">Resource's relative url.</param>
        /// <param name="resourceName">Resource name.</param>
        /// <returns>Deleted file from Sharepoint.</returns>
        Task<bool> DeleteFileAsync(string relativeURL, string resourceName);

        /// <summary>
        /// Function to move a site's resource to the Recycle bin.
        /// It can be a File or a Folder.
        /// </summary>
        /// <param name="relativeURL">Resource's relative url.</param>
        /// <returns>Recycled bin resource unique identifier.</returns>
        Task<Guid> MoveResourceToRecycleBinAsync(string relativeURL);

        /// <summary>
        /// Fuction to restore a resource that is in recycle bin folder using an unique identifier.
        /// </summary>
        /// <param name="resourceId">Resource unique identifier.</param>
        /// <returns>Resource restored.</returns>
        Task<bool> RestoreRecycleBinResourceByIdAsync(Guid resourceId);

        /// <summary>
        /// Function to create a new folder in SharePoint.
        /// </summary>
        /// <param name="relativeURL">Folder relative URL location.</param>
        /// <returns>SharePoint folder object.</returns>
        Task<SPFolder?> CreateFolderAsync(string relativeURL);

        /// <summary>
        /// Function to create a new folder in SharePoint.
        /// </summary>
        /// <param name="relativeURL">Folder relative URL location.</param>
        /// <param name="resourceName">Folder name.</param>
        /// <returns>SharePoint folder object.</returns>
        Task<SPFolder?> CreateFolderAsync(string relativeURL, string resourceName);

        /// <summary>
        /// This method upload a file in a SharePoint site.
        /// </summary>
        /// <param name="relativeURL">Resource's relative path location.</param>
        /// <param name="resourceName">Resource's name.</param>
        /// <param name="content">Resource's content.</param>
        /// <returns>SharePoint file object.</returns>
        Task<SPFile?> UploadFileAsync(string relativeURL, string resourceName, byte[] content);
    }
}
