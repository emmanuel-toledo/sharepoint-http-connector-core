using Newtonsoft.Json.Linq;
using SharePoint.Connector.Core.Models;
using SharePoint.Connector.Core.Facade.Requests;

namespace SharePoint.Connector.Core.Facade.Queries
{
    /// <summary>
    /// This interface defines the method to get file information.
    /// </summary>
    public interface IGetFiles
    {
        /// <summary>
        /// Function to get files information from a relative url location.
        /// </summary>
        /// <param name="relativeURL">Relative resource path location.</param>
        /// <returns>File byte array content.</returns>
        Task<ICollection<SPFile>> SendAsync(string relativeURL);
    }

    /// <summary>
    /// This class implements the method to get file information.
    /// </summary>
    public class GetFiles : IGetFiles
    {
        private readonly ISharePointRequest _sharepoint;

        public GetFiles(ISharePointRequest sharepoint)
            => _sharepoint = sharepoint;

        /// <summary>
        /// Function to get files information from a relative url location.
        /// </summary>
        /// <param name="relativeURL">Relative resource path location.</param>
        /// <returns>File byte array content.</returns>
        public async Task<ICollection<SPFile>> SendAsync(string relativeURL)
        {
            try
            {
                var dto = new List<SPFile>();
                // Configure method and endpoint request.
                var request = new HttpRequestMessage(HttpMethod.Get, $"_api/web/GetFolderByServerRelativeUrl('{relativeURL}')/files");
                // Configure required headers.
                request.Headers.Add("Accept", "application/json;odata=nometadata");
                // Request information to SharePoint API.
                var responseHttp = await _sharepoint.SendAsync(request);
                if (!responseHttp.IsSuccessStatusCode)
                    return dto;
                var response = JObject.Parse(await responseHttp.Content.ReadAsStringAsync());
                foreach (var item in response.Value<JArray>("value")!)
                {
                    var file = item.ToObject<SPFile>();
                    if (file != null)
                        dto.Add(file);
                }
                return dto;
            }
            catch
            {
                throw;
            }
        }
    }
}
