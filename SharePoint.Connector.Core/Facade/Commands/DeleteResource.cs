using SharePoint.Connector.Core.Facade.Requests;
using static SharePoint.Connector.Core.Business.Infrastructure.Helpers;

namespace SharePoint.Connector.Core.Facade.Commands
{
    /// <summary>
    /// This interface define the Delete Resource method.
    /// </summary>
    public interface IDeleteResource
    {
        /// <summary>
        /// Function to delete a SharePoint Resouce using RelativeURL.
        /// </summary>
        /// <param name="endpoint">Resource path location.</param>
        /// <param name="resourceType">Resource type</param>
        /// <returns>Success deleted</returns>
        Task<bool> DeleteResourceAsync(string endpoint, ResourceType resourceType);
    }

    /// <summary>
    /// This class implements the Delete Resource method.
    /// </summary>
    public class DeleteResource : IDeleteResource
    {
        private readonly ISharePointRequest _sharepoint;

        public DeleteResource(ISharePointRequest sharepoint)
            => _sharepoint = sharepoint;

        /// <summary>
        /// Function to delete a SharePoint Resouce using RelativeURL.
        /// </summary>
        /// <param name="endpoint">Resource path location.</param>
        /// <param name="resourceType">Resource type</param>
        /// <returns>Success deleted</returns>
        public async Task<bool> DeleteResourceAsync(string endpoint, ResourceType resourceType)
        {
            try
            {
                // Validate selected resource type.
                var url = string.Empty;
                url = resourceType switch
                {
                    ResourceType.Folder => $"_api/web/GetFolderByServerRelativeUrl('{endpoint}')",
                    ResourceType.File => $"_api/web/GetFileByServerRelativeUrl('{endpoint}')",
                    _ => throw new ArgumentException("Resource type was not specified"),
                };
                // Configure method and endpoint request.
                var request = new HttpRequestMessage(HttpMethod.Delete, url);
                // Configure required headers.
                request.Headers.Add("X-RequestDigest", "SHAREPOINT_FORM_DIGEST");
                request.Headers.Add("IF-MATCH", "*");
                request.Headers.Add("X-HTTP-Method", "DELETE");
                // Request information to SharePoint API.
                var responseHttp = await _sharepoint.SendAsync(request);
                return responseHttp.IsSuccessStatusCode;
            }
            catch
            {
                throw;
            }
        }
    }
}
