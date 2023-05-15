using SharePoint.Http.Connector.Core.Models;
using SharePoint.Http.Connector.Core.Facade.Commands;
using SharePoint.Http.Connector.Core.Business.Configurations;
using static SharePoint.Http.Connector.Core.Business.Infrastructure.Helpers;

namespace SharePoint.Http.Connector.Core.Business.Commands
{
    /// <summary>
    /// This class implements the methods that are used as a command in a SharePoint site.
    /// </summary>
    public class SharePointCommands : ISharePointCommands
    {
        private readonly ISharePointConfiguration _configuration;

        private readonly IDeleteResource _deleteResource;

        private readonly IMoveToRecycleBin _moveToRecycleBin;

        private readonly IRestoreRecycleBinResource _restoreRecycleBinResource;

        private readonly ICreateFolder _createFolder;

        private readonly IUploadFile _uploadFile;

        public SharePointCommands(
            ISharePointConfiguration configuration, 
            IDeleteResource deleteResource,
            IMoveToRecycleBin moveToRecycleBin,
            IRestoreRecycleBinResource restoreRecycleBinResource,
            ICreateFolder createFolder,
            IUploadFile uploadFile
        )
        {
            _configuration = configuration;
            _deleteResource = deleteResource;
            _moveToRecycleBin = moveToRecycleBin;
            _restoreRecycleBinResource = restoreRecycleBinResource;
            _createFolder = createFolder;
            _uploadFile = uploadFile;
        }

        /// <summary>
        /// Function to delete a SharePoint Resouce using RelativeURL.
        /// </summary>
        /// <param name="relativeURL">Resource's relative URL.</param>
        /// <param name="resourceType">Resource type</param>
        /// <returns>Success deleted</returns>
        public async Task<bool> DeleteResourceAsync(string relativeURL, ResourceType resourceType)
        {
            try
            {
                var serverRelativeURL = _configuration.GetServerRelativeURL();
                if (relativeURL.Contains(serverRelativeURL))
                    return await _deleteResource.SendAsync($"{relativeURL}", resourceType);
                return await _deleteResource.SendAsync($"/{serverRelativeURL}/{relativeURL}", resourceType);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Function to delete a SharePoint Resouce using RelativeURL.
        /// </summary>
        /// <param name="relativeURL">Resource's relative URL.</param>
        /// /// <param name="resourceName">Resource's name.</param>
        /// <param name="resourceType">Resource type</param>
        /// <returns>Success deleted</returns>
        public async Task<bool> DeleteResourceAsync(string relativeURL, string resourceName, ResourceType resourceType)
        {
            try
            {
                var serverRelativeURL = _configuration.GetServerRelativeURL();
                if (relativeURL.Contains(serverRelativeURL))
                    return await _deleteResource.SendAsync($"{relativeURL}/{resourceName}", resourceType);
                return await _deleteResource.SendAsync($"/{serverRelativeURL}/{relativeURL}/{resourceName}", resourceType);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// This function move a resource to the Recycle Bin of a site.
        /// </summary>
        /// <param name="relativeURL">Resource's relative URL.</param>
        /// <returns>Recycle resource unique identifier.</returns>
        public async Task<Guid> MoveResourceToRecycleBinAsync(string relativeURL)
        {
            try
            {
                var serverRelativeURL = _configuration.GetServerRelativeURL();
                if (relativeURL.Contains(serverRelativeURL))
                    return await _moveToRecycleBin.SendAsync($"{relativeURL}");
                return await _moveToRecycleBin.SendAsync($"/{serverRelativeURL}/{relativeURL}");
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// This function restore a resource from the Recycle Bin of a site.
        /// </summary>
        /// <param name="resourceId">Recycle Bin resource unique identifier.</param>
        /// <returns>Recycle resource restored flag.</returns>
        public async Task<bool> RestoreRecycleBinResourceByIdAsync(Guid resourceId)
            => await _restoreRecycleBinResource.SendAsync(resourceId);

        /// <summary>
        /// Function to create a new folder in SharePoint.
        /// </summary>
        /// <param name="relativeURL">Folder relative URL location.</param>
        /// <returns>SharePoint folder object.</returns>
        public async Task<SPFolder?> CreateFolderAsync(string relativeURL)
        {
            try
            {
                var serverRelativeURL = _configuration.GetServerRelativeURL();
                if (relativeURL.Contains(serverRelativeURL))
                    return await _createFolder.SendAsync($"{relativeURL}");
                return await _createFolder.SendAsync($"/{serverRelativeURL}/{relativeURL}");
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// This method upload a file in a SharePoint site.
        /// </summary>
        /// <param name="relativeURL">Resource's relative path location.</param>
        /// <param name="resourceName">Resource's name.</param>
        /// <param name="content">Resource's content.</param>
        /// <returns>SharePoint file object.</returns>
        public async Task<SPFile?> UploadFileAsync(string relativeURL, string resourceName, byte[] content)
        {
            try
            {
                var serverRelativeURL = _configuration.GetServerRelativeURL();
                if (relativeURL.Contains(serverRelativeURL))
                    return await _uploadFile.SendAsync($"{relativeURL}", resourceName, content);
                return await _uploadFile.SendAsync($"/{serverRelativeURL}/{relativeURL}", resourceName, content);
            }
            catch
            {
                throw;
            }
        }
    }
}
