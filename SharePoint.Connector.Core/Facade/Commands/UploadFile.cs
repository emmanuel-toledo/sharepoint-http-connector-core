using Newtonsoft.Json.Linq;
using SharePoint.Connector.Core.Models;
using SharePoint.Connector.Core.Facade.Requests;

namespace SharePoint.Connector.Core.Facade.Commands
{
    /// <summary>
    /// This interface defines upload file method for SharePoint.
    /// </summary>
    public interface IUploadFile
    {
        /// <summary>
        /// This method upload a file in a SharePoint site.
        /// </summary>
        /// <param name="relativeURL">Resource's relative path location.</param>
        /// <param name="resourceName">Resource's name.</param>
        /// <param name="content">Resource's content.</param>
        /// <returns>SharePoint file object.</returns>
        Task<SPFile?> SendAsync(string relativeURL, string resourceName, byte[] content);
    }

    /// <summary>
    /// This class implements upload file method for SharePoint.
    /// </summary>
    public class UploadFile : IUploadFile
    {
        private readonly ISharePointRequest _sharepoint;

        public UploadFile(ISharePointRequest sharepoint)
            => _sharepoint = sharepoint;

        /// <summary>
        /// This method upload a file in a SharePoint site.
        /// </summary>
        /// <param name="relativeURL">Resource's relative path location.</param>
        /// <param name="resourceName">Resource's name.</param>
        /// <param name="content">Resource's content.</param>
        /// <returns>SharePoint file object.</returns>
        public async Task<SPFile?> SendAsync(string relativeURL, string resourceName, byte[] content)
        {
            try
            {
                // Configure method and endpoint request.
                var request = new HttpRequestMessage(
                    HttpMethod.Post, 
                    $"_api/web/GetFolderByServerRelativeUrl('{ relativeURL }')/Files/add(overwrite=true, url='{ resourceName }')"
                );
                request.Content = new ByteArrayContent(content);
                // Configure required headers.
                request.Headers.Add("Accept", "application/json;odata=nometadata");
                // Request information to SharePoint API.
                var responseHttp = await _sharepoint.SendAsync(request);
                if (!responseHttp.IsSuccessStatusCode)
                    return null;
                // Get Recycle bin resource unique identifier.
                var response = JObject.Parse(await responseHttp.Content.ReadAsStringAsync());
                return response.ToObject<SPFile?>();
            }
            catch 
            {
                throw;
            }
        }
    }
}
