using SharePoint.Http.Connector.Core.Models;
using SharePoint.Http.Connector.Core.Persistences;
using SharePoint.Http.Connector.Core.Business.Queries;
using SharePoint.Http.Connector.Core.Business.Commands;
using static SharePoint.Http.Connector.Core.Business.Infrastructure.Helpers;

namespace SharePoint.Http.Connector.Core
{
    public class SharePointContext : ISharePointContext
    {
        private readonly ISharePointQueries _queries;

        private readonly ISharePointCommands _commands;

        public SharePointContext(ISharePointQueries queries, ISharePointCommands commands)
        {
            _queries = queries;
            _commands = commands;
        }

        /// <summary>
        /// Function to validate if exists a folder in Sharepoint site.
        /// </summary>
        /// <param name="relativeURL">Resource's relative url.</param>
        /// <returns>Folder existence.</returns>
        public async Task<bool> ExistsResourceAsync(string relativeURL)
            => await _queries.ExistsResourceAsync(relativeURL);

        /// <summary>
        /// Function to validate if exists a file in Sharepoint using relative URL and resource name.
        /// </summary>
        /// <param name="relativeURL">Resource's relative url.</param>
        /// <param name="resourceName">File name to validate.</param>
        /// <returns>File existence.</returns>
        public async Task<bool> ExistsResourceAsync(string relativeURL, string resourceName)
            => await _queries.ExistsResourceAsync($"{ relativeURL }/{ resourceName }");

        /// <summary>
        /// Function to get Library Documents collection.
        /// </summary>
        /// <returns>Library Documents collection.</returns>
        public async Task<ICollection<SPLibraryDocuments>> GetLibraryDocumentsAsync()
            => await _queries.GetLibraryDocumentsAsync();

        /// <summary>
        /// Function to get the usage information of a SharePoint site.
        /// </summary>
        /// <returns>Site Usage model.</returns>
        public async Task<SPSiteUsage?> GetSiteUsageAsync() 
            => await _queries.GetSiteUsageAsync();

        /// <summary>
        /// Fuction to retrive information of a resource that is in recycle bin using an unique identifier.
        /// </summary>
        /// <param name="resourceId">Resource unique identifier.</param>
        /// <returns>Recycle bin resource information.</returns>
        public async Task<SPRecycleResource?> GetRecycleBinResourceByIdAsync(Guid resourceId)
            => await _queries.GetRecycleBinResourceByIdAsync(resourceId);

        /// <summary>
        /// Function to download file content using relative path location and file name.
        /// </summary>
        /// <param name="relativeURL">Relative resource path location.</param>
        /// <param name="resourceName">Resource name.</param>
        /// <returns>File byte array content.</returns>
        public async Task<byte[]?> GetFileContentAsync(string relativeURL, string resourceName)
            => await _queries.GetFileContentAsync(relativeURL, resourceName);

        /// <summary>
        /// Function to get file information using relative path location and file name.
        /// </summary>
        /// <param name="relativeURL">Relative resource path location.</param>
        /// <param name="resourceName">Resource name.</param>
        /// <returns>File byte array content.</returns>
        public async Task<SPFile?> GetFileAsync(string relativeURL, string resourceName)
            => await _queries.GetFileAsync(relativeURL, resourceName);

        /// <summary>
        /// Function to get files information from a relative url location.
        /// </summary>
        /// <param name="relativeURL">Relative resource path location.</param>
        /// <returns>File byte array content.</returns>
        public async Task<ICollection<SPFile>> GetFilesAsync(string relativeURL)
            => await _queries.GetFilesAsync(relativeURL);

        /// <summary>
        /// Function to delete a folder resource from a specific path.
        /// </summary>
        /// <param name="relativeURL">Folder resource's relative url.</param>
        /// <returns>Deleted resource from Sharepoint.</returns>
        public async Task<bool> DeleteFolderAsync(string relativeURL)
            => await _commands.DeleteResourceAsync(relativeURL, ResourceType.Folder);

        /// <summary>
        /// Function to delete a file from a specific path and file name.
        /// </summary>
        /// <param name="relativeURL">Resource's relative url.</param>
        /// <returns>Deleted file from Sharepoint.</returns>
        public async Task<bool> DeleteFileAsync(string relativeURL)
            => await _commands.DeleteResourceAsync(relativeURL, ResourceType.File);

        /// <summary>
        /// Function to delete a file from a specific path and file name.
        /// </summary>
        /// <param name="relativeURL">Resource's relative url.</param>
        /// <param name="resourceName">File name to delete.</param>
        /// <returns>Deleted file from Sharepoint.</returns>
        public async Task<bool> DeleteFileAsync(string relativeURL, string resourceName)
            => await _commands.DeleteResourceAsync(relativeURL, resourceName, ResourceType.File);

        /// <summary>
        /// Function to move a site's resource to the Recycle bin.
        /// It can be a File or a Folder.
        /// </summary>
        /// <param name="relativeURL">Resource's relative url.</param>
        /// <returns>Recycled bin resource unique identifier.</returns>
        public async Task<Guid> MoveResourceToRecycleBinAsync(string relativeURL)
            => await _commands.MoveResourceToRecycleBinAsync(relativeURL);

        /// <summary>
        /// Fuction to restore a resource that is in recycle bin folder using an unique identifier.
        /// </summary>
        /// <param name="resourceId">Resource unique identifier.</param>
        /// <returns>Resource restored.</returns>
        public async Task<bool> RestoreRecycleBinResourceByIdAsync(Guid resourceId)
            => await _commands.RestoreRecycleBinResourceByIdAsync(resourceId);

        /// <summary>
        /// Function to create a new folder in SharePoint.
        /// </summary>
        /// <param name="relativeURL">Folder relative URL location.</param>
        /// <returns>SharePoint folder object.</returns>
        public async Task<SPFolder?> CreateFolderAsync(string relativeURL)
            => await _commands.CreateFolderAsync(relativeURL);

        /// <summary>
        /// Function to create a new folder in SharePoint.
        /// </summary>
        /// <param name="relativeURL">Folder relative URL location.</param>
        /// <param name="resourceName">Folder name.</param>
        /// <returns>SharePoint folder object.</returns>
        public async Task<SPFolder?> CreateFolderAsync(string relativeURL, string resourceName)
            => await _commands.CreateFolderAsync($"{ relativeURL }/{ resourceName }");

        /// <summary>
        /// This method upload a file in a SharePoint site.
        /// </summary>
        /// <param name="relativeURL">Resource's relative path location.</param>
        /// <param name="resourceName">Resource's name.</param>
        /// <param name="content">Resource's content.</param>
        /// <returns>SharePoint file object.</returns>
        public async Task<SPFile?> UploadFileAsync(string relativeURL, string resourceName, byte[] content)
            => await _commands.UploadFileAsync(relativeURL, resourceName, content);
    }
}
