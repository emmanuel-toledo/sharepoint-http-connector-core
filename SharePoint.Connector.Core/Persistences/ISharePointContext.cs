using SharePoint.Connector.Core.Facade.Queries;
using SharePoint.Connector.Core.Models;

namespace SharePoint.Connector.Core.Persistences
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
        Task<ICollection<SPLibraryDocuments>> LibraryDocumentsAsync();

        /// <summary>
        /// Function to get the usage information of a SharePoint site.
        /// </summary>
        /// <returns>Site Usage model.</returns>
        Task<SPSiteUsage?> SiteUsageAsync();

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
        /// <param name="resourceName">File name to delete.</param>
        /// <returns>Deleted file from Sharepoint.</returns>
        Task<bool> DeleteFileAsync(string relativeURL, string resourceName);

        /// <summary>
        /// Function to move a site's resource to the recycled bin.
        /// It can be a File or a Folder.
        /// </summary>
        /// <param name="relativeURL">Resource's relative url.</param>
        /// <returns></returns>
        Task<SPRecycledResource?> MoveToRecycledBinAsync(string relativeURL);

        /// <summary>
        /// Fuction to restore a resource that is in recycle bin folder using an unique identifier.
        /// </summary>
        /// <param name="resourceId">Resource unique identifier.</param>
        /// <returns>Resource restored.</returns>
        Task<bool> RestoreRecycleBinResourceByIdAsync(Guid resourceId);




        /// <summary>
        /// Fuction to retrive information of a resource that is in recycle bin using an unique identifier.
        /// </summary>
        /// <param name="resourceId">Resource unique identifier.</param>
        /// <returns>Recycle bin resource information.</returns>
        Task<SPRecycledResource?> GetRecycleBinResourceByIdAsync(Guid resourceId);

        /// <summary>
        /// Function to get (download) a file content as byte array from a specific path.
        /// </summary>
        /// <param name="serverRelativeURL">Resource's relative url.</param>
        /// <returns>Byte array with file content.</returns>
        Task<byte[]?> GetFileContentAsync(string serverRelativeURL);

        /// <summary>
        /// Function to get (download) a file content as byte array from a specific path.
        /// </summary>
        /// <param name="serverRelativeURL">Resource's relative url.</param>
        /// <param name="fileName">File name to delete.</param>
        /// <returns>Byte array with file content.</returns>
        Task<byte[]?> GetFileContentAsync(string serverRelativeURL, string fileName);

        /// <summary>
        /// Function to get (download) a file from a specific path.
        /// </summary>
        /// <param name="serverRelativeURL">Resource's relative url.</param>
        /// <returns>Byte array with file content.</returns>
        Task<SPFile?> GetFileAsync(string serverRelativeURL);

        /// <summary>
        /// Function to get (download) a file from a specific path.
        /// </summary>
        /// <param name="serverRelativeURL">Resource's relative url.</param>
        /// <param name="fileName">File name to delete.</param>
        /// <returns>Byte array with file content.</returns>
        Task<SPFile?> GetFileAsync(string serverRelativeURL, string fileName);

        /// <summary>
        /// Function to create a folder in the main path of the site.
        /// </summary>
        /// <param name="folderName">Folder name to be created.</param>
        /// <returns>Sharepoint folder information.</returns>
        Task<SPFolder?> CreateFolderAsync(string folderName);

        /// <summary>
        /// Function to create a folder in a specific path of the site.
        /// </summary>
        /// <param name="serverRelativeUrl">Resource's relative url.</param>
        /// <param name="folderName">Folder name to be created.</param>
        /// <returns>Sharepoint folder information.</returns>
        Task<SPFolder?> CreateFolderAsync(string serverRelativeUrl, string folderName);

        /// <summary>
        /// Function to upload a file in the main path of the site.
        /// </summary>
        /// <param name="fileName">File name to delete.</param>
        /// <param name="content">Content file.</param>
        /// <returns>Sharepoint file information.</returns>
        Task<SPFile?> UploadFileAsync(string fileName, byte[] content);
        
        /// <summary>
        /// Function to upload a file for a specific path.
        /// </summary>
        /// <param name="serverRelativeUrl">Resource's relative url.</param>
        /// <param name="fileName">File name to delete.</param>
        /// <param name="content">Content file.</param>
        /// <returns>Sharepoint file information.</returns>
        Task<SPFile?> UploadFileAsync(string serverRelativeUrl, string fileName, byte[] content);
    }
}
