using Newtonsoft.Json.Linq;
using SharePoint.Connector.Core.Models;
using SharePoint.Connector.Core.Facade.Requests;

namespace SharePoint.Connector.Core.Facade.Queries
{
    /// <summary>
    /// This interface contains the logic to get list of Library Documents that a SharePoint site has.
    /// </summary>
    public interface ILibraryDocuments
    {
        /// <summary>
        /// Function to get Library Documents collection.
        /// </summary>
        /// <returns>Library Documents collection.</returns>
        Task<ICollection<SPLibraryDocuments>> LibraryDocumentsAsync();
    }

    /// <summary>
    /// This class contains the logic to get list of Library Documents that a SharePoint site has.
    /// </summary>
    public class LibraryDocuments : ILibraryDocuments
    {
        private readonly ISharePointRequest _sharepoint;

        public LibraryDocuments(ISharePointRequest sharepoint)
            => _sharepoint = sharepoint;

        /// <summary>
        /// Function to get Library Documents collection.
        /// </summary>
        /// <returns>Library Documents collection.</returns>
        public async Task<ICollection<SPLibraryDocuments>> LibraryDocumentsAsync()
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
