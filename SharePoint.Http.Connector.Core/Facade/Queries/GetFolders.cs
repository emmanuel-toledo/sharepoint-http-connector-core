using Newtonsoft.Json.Linq;
using SharePoint.Http.Connector.Core.Models;
using SharePoint.Http.Connector.Core.Facade.Requests;

namespace SharePoint.Http.Connector.Core.Facade.Queries
{
    /// <summary>
    /// This interface defines the method to get folders information from path.
    /// </summary>
    public interface IGetFolders
    {
        /// <summary>
        /// Function to get folders information from a relative url location.
        /// </summary>
        /// <param name="relativeURL">Relative resource path location.</param>
        /// <returns>List of folders.</returns>
        Task<ICollection<SPFolder>> SendAsync(string relativeURL);
    }

    /// <summary>
    /// This class implements the method to get folders information.
    /// </summary>
    public class GetFolders : IGetFolders
    {
        private readonly ISharePointRequest _sharepoint;

        public GetFolders(ISharePointRequest sharepoint)
            => _sharepoint = sharepoint;

        /// <summary>
        /// Function to get folders information from a relative url location.
        /// </summary>
        /// <param name="relativeURL">Relative resource path location.</param>
        /// <returns>List of folders.</returns>
        public async Task<ICollection<SPFolder>> SendAsync(string relativeURL)
        {
            try
            {
                var dto = new List<SPFolder>();
                // Configure method and endpoint request.
                var request = new HttpRequestMessage(HttpMethod.Get, $"_api/web/GetFolderByServerRelativeUrl('{relativeURL}')/folders");
                // Configure required headers.
                request.Headers.Add("Accept", "application/json;odata=nometadata");
                // Request information to SharePoint API.
                var responseHttp = await _sharepoint.SendAsync(request);
                if (!responseHttp.IsSuccessStatusCode)
                    return dto;
                var response = JObject.Parse(await responseHttp.Content.ReadAsStringAsync());
                foreach (var item in response.Value<JArray>("value")!)
                {
                    var file = item.ToObject<SPFolder>();
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
