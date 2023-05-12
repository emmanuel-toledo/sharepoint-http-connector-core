using SharePoint.Connector.Core.Models;
using SharePoint.Connector.Core.Facade.Queries;
using SharePoint.Connector.Core.Business.Configurations;

namespace SharePoint.Connector.Core.Business.Queries
{
    /// <summary>
    /// Implementation class for queries requests.
    /// </summary>
    public class SharePointQueries : ISharePointQueries
    {
        private readonly ISharePointConfiguration _configuration;

        private readonly IExistsResource _existsResource;

        private readonly IGetLibraryDocuments _getLibraryDocuments;

        private readonly IGetSiteUsage _getSiteUsage;

        private readonly IGetRecycleBinResourceById _getRecycleBinResourceById;

        private readonly IGetFileContent _getFileContent;

        private readonly IGetFile _getFile;

        private readonly IGetFiles _getFiles;

        public SharePointQueries(
            ISharePointConfiguration configuration, 
            IExistsResource existsResource,
            IGetLibraryDocuments getLibraryDocuments, 
            IGetSiteUsage getSiteUsage,
            IGetRecycleBinResourceById getRecycleBinResourceById,
            IGetFileContent getFileContent,
            IGetFile getFile,
            IGetFiles getFiles
        )
        {
            _configuration = configuration;
            _existsResource = existsResource;
            _getLibraryDocuments = getLibraryDocuments;
            _getSiteUsage = getSiteUsage;
            _getRecycleBinResourceById = getRecycleBinResourceById;
            _getFileContent = getFileContent;
            _getFile = getFile;
            _getFiles = getFiles;
        }

        /// <summary>
        /// Function to validate if exists a folder in Sharepoint site.
        /// </summary>
        /// <param name="relativeURL">Resource's relative url.</param>
        /// <returns>Folder existence.</returns>
        public async Task<bool> ExistsResourceAsync(string relativeURL)
        {
            try
            {
                var serverRelativeURL = _configuration.GetServerRelativeURL();
                return await _existsResource.SendAsync($"/{serverRelativeURL}/{relativeURL}");
            } catch
            {
                throw;
            }
        }

        /// <summary>
        /// Function to get Library Documents collection.
        /// </summary>
        /// <returns>Library Documents collection.</returns>
        public async Task<ICollection<SPLibraryDocuments>> GetLibraryDocumentsAsync()
            => await _getLibraryDocuments.SendAsync();

        /// <summary>
        /// Function to get the usage information of a SharePoint site.
        /// </summary>
        /// <returns>Site Usage model.</returns>
        public async Task<SPSiteUsage?> GetSiteUsageAsync()
            => await _getSiteUsage.SendAsync();

        /// <summary>
        /// Function to get a resource from Recycle bin using an unique identifier.
        /// </summary>
        /// <param name="resourceId">Recycle bin resource unique identifier.</param>
        /// <returns>Recycle bin resource object.</returns>
        public async Task<SPRecycleResource?> GetRecycleBinResourceByIdAsync(Guid resourceId)
            => await _getRecycleBinResourceById.SendAsync(resourceId);

        /// <summary>
        /// Function to download file content using relative path location and file name.
        /// </summary>
        /// <param name="relativeURL">Relative resource path location.</param>
        /// <param name="resourceName">Resource name.</param>
        /// <returns>File byte array content.</returns>
        public async Task<byte[]?> GetFileContentAsync(string relativeURL, string resourceName)
        {
            try
            {
                var serverRelativeURL = _configuration.GetServerRelativeURL();
                return await _getFileContent.SendAsync($"/{serverRelativeURL}/{relativeURL}", resourceName);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Function to get file information using relative path location and file name.
        /// </summary>
        /// <param name="relativeURL">Relative resource path location.</param>
        /// <param name="resourceName">Resource name.</param>
        /// <returns>File byte array content.</returns>
        public async Task<SPFile?> GetFileAsync(string relativeURL, string resourceName)
        {
            try
            {
                var serverRelativeURL = _configuration.GetServerRelativeURL();
                return await _getFile.SendAsync($"/{serverRelativeURL}/{relativeURL}", resourceName);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Function to get files information from a relative url location.
        /// </summary>
        /// <param name="relativeURL">Relative resource path location.</param>
        /// <returns>File byte array content.</returns>
        public async Task<ICollection<SPFile>> GetFilesAsync(string relativeURL)
        {
            try
            {
                var serverRelativeURL = _configuration.GetServerRelativeURL();
                return await _getFiles.SendAsync($"/{serverRelativeURL}/{relativeURL}");
            }
            catch
            {
                throw;
            }
        }
    }
}
