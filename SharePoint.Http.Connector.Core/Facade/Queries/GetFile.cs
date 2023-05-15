using Newtonsoft.Json.Linq;
using SharePoint.Http.Connector.Core.Models;
using SharePoint.Http.Connector.Core.Facade.Requests;

namespace SharePoint.Http.Connector.Core.Facade.Queries
{
    /// <summary>
    /// This interface defines the method to get file information.
    /// </summary>
    public interface IGetFile
    {
        /// <summary>
        /// Function to get file information using relative path location and file name.
        /// </summary>
        /// <param name="relativeURL">Relative resource path location.</param>
        /// <param name="resourceName">Resource name.</param>
        /// <returns>File byte array content.</returns>
        Task<SPFile?> SendAsync(string relativeURL, string resourceName);
    }

    /// <summary>
    /// This class implements the method to get file information.
    /// </summary>
    public class GetFile : IGetFile
    {
        private readonly ISharePointRequest _sharepoint;

        public GetFile(ISharePointRequest sharepoint)
            => _sharepoint = sharepoint;

        /// <summary>
        /// Function to get file information using relative path location and file name.
        /// </summary>
        /// <param name="relativeURL">Relative resource path location.</param>
        /// <param name="resourceName">Resource name.</param>
        /// <returns>File byte array content.</returns>
        public async Task<SPFile?> SendAsync(string relativeURL, string resourceName)
        {
            try
            {
                // Configure method and endpoint request.
                var request = new HttpRequestMessage(HttpMethod.Get, $"_api/web/GetFolderByServerRelativeUrl('{relativeURL}')/files('{resourceName}')");
                // Configure required headers.
                request.Headers.Add("Accept", "application/json;odata=nometadata");
                // Request information to SharePoint API.
                var responseHttp = await _sharepoint.SendAsync(request);
                if (!responseHttp.IsSuccessStatusCode)
                    return null;
                var response = JObject.Parse(await responseHttp.Content.ReadAsStringAsync());
                return response.ToObject<SPFile?>() ?? null;
            }
            catch
            {
                throw;
            }
        }
    }
}
