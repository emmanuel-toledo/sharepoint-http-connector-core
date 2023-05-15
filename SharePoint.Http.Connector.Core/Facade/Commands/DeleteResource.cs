using SharePoint.Http.Connector.Core.Facade.Requests;
using static SharePoint.Http.Connector.Core.Business.Infrastructure.Helpers;

namespace SharePoint.Http.Connector.Core.Facade.Commands
{
    /// <summary>
    /// This interface defines the Delete Resource method.
    /// </summary>
    public interface IDeleteResource
    {
        /// <summary>
        /// Function to delete a SharePoint Resouce using RelativeURL.
        /// </summary>
        /// <param name="relativeURL">Resource's relative URL.</param>
        /// <param name="resourceType">Resource type</param>
        /// <returns>Success deleted</returns>
        Task<bool> SendAsync(string relativeURL, ResourceType resourceType);
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
        /// <param name="relativeURL">Resource's relative URL.</param>
        /// <param name="resourceType">Resource type</param>
        /// <returns>Success deleted</returns>
        public async Task<bool> SendAsync(string relativeURL, ResourceType resourceType)
        {
            try
            {
                // Validate selected resource type.
                var url = string.Empty;
                url = resourceType switch
                {
                    ResourceType.Folder => $"_api/web/GetFolderByServerRelativeUrl('{relativeURL}')",
                    ResourceType.File => $"_api/web/GetFileByServerRelativeUrl('{relativeURL}')",
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
