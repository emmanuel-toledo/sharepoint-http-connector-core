using SharePoint.Connector.Core.Business.Configurations;
using SharePoint.Connector.Core.Facade.Commands;
using SharePoint.Connector.Core.Microsoft.Extensions;
using static SharePoint.Connector.Core.Business.Infrastructure.Helpers;

namespace SharePoint.Connector.Core.Business.Commands
{
    /// <summary>
    /// This class implements the methods that are used as a command in a SharePoint site.
    /// </summary>
    public class SharePointCommands : ISharePointCommands
    {
        private readonly ISharePointConfiguration _configuration;

        private readonly IDeleteResource _deleteResource;

        private readonly IMoveToRecycledBin _moveToRecycledBin;

        private readonly IRestoreFromRecycledBin _restoreFromRecycledBin;

        public SharePointCommands(
            ISharePointConfiguration configuration, 
            IDeleteResource deleteResource,
            IMoveToRecycledBin moveToRecycledBin,
            IRestoreFromRecycledBin restoreFromRecycledBin
        )
        {
            _configuration = configuration;
            _deleteResource = deleteResource;
            _moveToRecycledBin = moveToRecycledBin;
            _restoreFromRecycledBin = restoreFromRecycledBin;
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
                var configuration = _configuration.Configurations.FirstOrDefault();
                if (configuration is null)
                    throw new NullReferenceException("SharePoint site configuration were not defined.");
                var serverRelativeURL = configuration.GetRelativeURL();
                if (string.IsNullOrEmpty(serverRelativeURL))
                    throw new NotSupportedException("SharePoint site URL is not correctly defined for this service.");
                return await _deleteResource.DeleteResourceAsync($"/{serverRelativeURL}/{relativeURL}", resourceType);
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
                var configuration = _configuration.Configurations.FirstOrDefault();
                if (configuration is null)
                    throw new NullReferenceException("SharePoint site configuration were not defined.");
                var serverRelativeURL = configuration.GetRelativeURL();
                if (string.IsNullOrEmpty(serverRelativeURL))
                    throw new NotSupportedException("SharePoint site URL is not correctly defined for this service.");
                return await _deleteResource.DeleteResourceAsync($"/{serverRelativeURL}/{relativeURL}/{resourceName}", resourceType);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// This function move a resource to the Recycled Bin of a site.
        /// </summary>
        /// <param name="endpoint">Resource path location.</param>
        /// <returns>Recycled resource unique identifier.</returns>
        public async Task<Guid> MoveToRecycledBinAsync(string endpoint)
        {
            var configuration = _configuration.Configurations.FirstOrDefault();
            if (configuration is null)
                throw new NullReferenceException("SharePoint site configuration were not defined.");
            var serverRelativeURL = configuration.GetRelativeURL();
            if (string.IsNullOrEmpty(serverRelativeURL))
                throw new NotSupportedException("SharePoint site URL is not correctly defined for this service.");
            return await _moveToRecycledBin.MoveToRecycledBinAsync($"{ serverRelativeURL }/{ endpoint }");
        }

        /// <summary>
        /// This function restore a resource from the Recycled Bin of a site.
        /// </summary>
        /// <param name="resourceId">Recycled Bin resource unique identifier.</param>
        /// <returns>Recycled resource restored flag.</returns>
        public async Task<bool> RestoreFromRecycledBinAsync(Guid resourceId)
            => await RestoreFromRecycledBinAsync(resourceId);
    }
}
