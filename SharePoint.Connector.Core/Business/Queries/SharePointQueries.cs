using SharePoint.Connector.Core.Business.Configurations;
using SharePoint.Connector.Core.Facade.Queries;
using SharePoint.Connector.Core.Microsoft.Extensions;
using SharePoint.Connector.Core.Models;

namespace SharePoint.Connector.Core.Business.Queries
{
    /// <summary>
    /// Implementation class for queries requests.
    /// </summary>
    public class SharePointQueries : ISharePointQueries
    {
        private readonly ISharePointConfiguration _configuration;

        private readonly IExistsResource _existsResource;

        private readonly ILibraryDocuments _libraryDocuments;

        private readonly ISiteUsage _siteUsage;

        private readonly IRecycledBinResource _recycledBinResource;

        public SharePointQueries(
            ISharePointConfiguration configuration, 
            IExistsResource existsResource, 
            ILibraryDocuments libraryDocuments, 
            ISiteUsage siteUsage,
            IRecycledBinResource recycledBinResource
        )
        {
            _configuration = configuration;
            _existsResource = existsResource;
            _libraryDocuments = libraryDocuments;
            _siteUsage = siteUsage;
            _recycledBinResource = recycledBinResource;
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
                var configuration = _configuration.Configurations.FirstOrDefault();
                if (configuration is null)
                    throw new NullReferenceException("SharePoint site configuration were not defined.");
                var serverRelativeURL = configuration.GetRelativeURL();
                if (string.IsNullOrEmpty(serverRelativeURL))
                    throw new NotSupportedException("SharePoint site URL is not correctly defined for this service.");
                return await _existsResource.ExistsResourceAsync($"/{serverRelativeURL}/{relativeURL}");
            } catch
            {
                throw;
            }
        }

        /// <summary>
        /// Function to validate if exists a file in Sharepoint using relative URL and resource name.
        /// </summary>
        /// <param name="relativeURL">Resource's relative url.</param>
        /// <param name="resourceName">File name to validate.</param>
        /// <returns>File existence.</returns>
        public async Task<bool> ExistsResourceAsync(string relativeURL, string resourceName)
        {
            try
            {
                var configuration = _configuration.Configurations.FirstOrDefault();
                if (configuration is null)
                    throw new NullReferenceException("SharePoint site configuration were not defined.");
                var serverRelativeURL = configuration.GetRelativeURL();
                if (string.IsNullOrEmpty(serverRelativeURL))
                    throw new NotSupportedException("SharePoint site URL is not correctly defined for this service.");
                return await _existsResource.ExistsResourceAsync($"/{ serverRelativeURL }/{ relativeURL }/{ resourceName }");
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Function to get Library Documents collection.
        /// </summary>
        /// <returns>Library Documents collection.</returns>
        public async Task<ICollection<SPLibraryDocuments>> LibraryDocumentsAsync()
            => await _libraryDocuments.LibraryDocumentsAsync();

        /// <summary>
        /// Function to get the usage information of a SharePoint site.
        /// </summary>
        /// <returns>Site Usage model.</returns>
        public async Task<SPSiteUsage?> SiteUsageAsync()
            => await _siteUsage.SiteUsageAsync();

        /// <summary>
        /// Function to get a resource from recycled bin using an unique identifier.
        /// </summary>
        /// <param name="resourceId">Recycled bin resource unique identifier.</param>
        /// <returns>Recycled bin resource object.</returns>
        public async Task<SPRecycledResource?> RecycledBinResourceAsync(Guid resourceId)
            => await _recycledBinResource.RecycledBinResourceAsync(resourceId);
    }
}
