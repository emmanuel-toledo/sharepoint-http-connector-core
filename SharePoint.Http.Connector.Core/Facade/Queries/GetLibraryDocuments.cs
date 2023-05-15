using Newtonsoft.Json.Linq;
using SharePoint.Http.Connector.Core.Models;
using SharePoint.Http.Connector.Core.Facade.Requests;

namespace SharePoint.Http.Connector.Core.Facade.Queries
{
    /// <summary>
    /// This interface contains the logic to get list of Library Documents that a SharePoint site has.
    /// </summary>
    public interface IGetLibraryDocuments
    {
        /// <summary>
        /// Function to get Library Documents collection.
        /// </summary>
        /// <returns>Library Documents collection.</returns>
        Task<ICollection<SPLibraryDocuments>> SendAsync();
    }

    /// <summary>
    /// This class contains the logic to get list of Library Documents that a SharePoint site has.
    /// </summary>
    public class GetLibraryDocuments : IGetLibraryDocuments
    {
        private readonly ISharePointRequest _sharepoint;

        public GetLibraryDocuments(ISharePointRequest sharepoint)
            => _sharepoint = sharepoint;

        /// <summary>
        /// Function to get Library Documents collection.
        /// </summary>
        /// <returns>Library Documents collection.</returns>
        public async Task<ICollection<SPLibraryDocuments>> SendAsync()
        {
            try
            {
                var dto = new List<SPLibraryDocuments>();
                // Configure method and endpoint request.
                var request = new HttpRequestMessage(HttpMethod.Get, $"_api/web/folders");
                // Configure required headers.
                request.Headers.Add("Accept", "application/json;odata=nometadata");
                // Request information to SharePoint API.
                var responseHttp = await _sharepoint.SendAsync(request);
                if (!responseHttp.IsSuccessStatusCode)
                    return dto;
                var response = JObject.Parse(await responseHttp.Content.ReadAsStringAsync());
                foreach(var item in response.Value<JArray>("value")!)
                {
                    var library = item.ToObject<SPLibraryDocuments>();
                    if (library != null)
                        dto.Add(library);
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
