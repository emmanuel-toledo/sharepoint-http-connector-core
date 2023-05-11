using SharePoint.Connector.Core.Business.Commands;
using SharePoint.Connector.Core.Business.Queries;
using SharePoint.Connector.Core.Facade.Queries;
using SharePoint.Connector.Core.Models;
using SharePoint.Connector.Core.Persistences;
using System.Windows.Input;
using static SharePoint.Connector.Core.Business.Infrastructure.Helpers;

namespace SharePoint.Connector.Core
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
            => await _queries.ExistsResourceAsync(relativeURL, resourceName);

        /// <summary>
        /// Function to get Library Documents collection.
        /// </summary>
        /// <returns>Library Documents collection.</returns>
        public async Task<ICollection<SPLibraryDocuments>> LibraryDocumentsAsync()
            => await _queries.LibraryDocumentsAsync();

        /// <summary>
        /// Function to get the usage information of a SharePoint site.
        /// </summary>
        /// <returns>Site Usage model.</returns>
        public async Task<SPSiteUsage?> SiteUsageAsync() 
            => await _queries.SiteUsageAsync();

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
        
        public Task<SPFolder?> CreateFolderAsync(string folderName)
        {
            throw new NotImplementedException();
        }

        public Task<SPFolder?> CreateFolderAsync(string serverRelativeUrl, string folderName)
        {
            throw new NotImplementedException();
        }

        public Task<SPFile?> GetFileAsync(string serverRelativeURL)
        {
            throw new NotImplementedException();
        }

        public Task<SPFile?> GetFileAsync(string serverRelativeURL, string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]?> GetFileContentAsync(string serverRelativeURL)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]?> GetFileContentAsync(string serverRelativeURL, string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<SPRecycledResource?> GetRecycleBinResourceByIdAsync(Guid resourceId)
        {
            throw new NotImplementedException();
        }

        public Task<SPRecycledResource?> MoveToRecycledBinAsync(string serverRelativeURL)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> RestoreRecycleBinResourceByIdAsync(Guid resourceId)
        {
            throw new NotImplementedException();
        }

        public Task<SPFile?> UploadFileAsync(string fileName, byte[] content)
        {
            throw new NotImplementedException();
        }

        public Task<SPFile?> UploadFileAsync(string serverRelativeUrl, string fileName, byte[] content)
        {
            throw new NotImplementedException();
        }
    }
}
