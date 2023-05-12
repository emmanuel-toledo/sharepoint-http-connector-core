using System.Net;
using SharePoint.Connector.Core.Facade.Requests;

namespace SharePoint.Connector.Core.Facade.Queries
{
    /// <summary>
    /// This interface defines the method to download file content.
    /// </summary>
    public interface IGetFileContent
    {
        /// <summary>
        /// Function to download file content using relative path location and file name.
        /// </summary>
        /// <param name="relativeURL">Relative resource path location.</param>
        /// <param name="resourceName">Resource name.</param>
        /// <returns>File byte array content.</returns>
        Task<byte[]?> SendAsync(string relativeURL, string resourceName);
    }

    /// <summary>
    /// This class implements the method to download file content.
    /// </summary>
    public class GetFileContent : IGetFileContent
    {
        private readonly ISharePointRequest _sharepoint;

        public GetFileContent(ISharePointRequest sharepoint)
            => _sharepoint = sharepoint;

        /// <summary>
        /// Function to download file content using relative path location and file name.
        /// </summary>
        /// <param name="relativeURL">Relative resource path location.</param>
        /// <param name="resourceName">Resource name.</param>
        /// <returns>File byte array content.</returns>
        public async Task<byte[]?> SendAsync(string relativeURL, string resourceName)
        {
            try
            {
                // Configure method and endpoint request.
                var request = new HttpRequestMessage(HttpMethod.Get, $"_api/web/GetFolderByServerRelativeUrl('{relativeURL}')/files('{ resourceName }')/$value");
                // Configure required headers.
                request.Headers.Add("Accept", "application/octet-stream");
                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("binaryStringRequestBody", "true");
                // Request information to SharePoint API.
                var responseHttp = await _sharepoint.SendAsync(request);
                if (!responseHttp.IsSuccessStatusCode)
                    return null;
                return await responseHttp.Content.ReadAsByteArrayAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
