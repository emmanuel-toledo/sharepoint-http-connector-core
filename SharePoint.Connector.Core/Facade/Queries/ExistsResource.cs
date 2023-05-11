using Newtonsoft.Json.Linq;
using SharePoint.Connector.Core.Facade.Requests;

namespace SharePoint.Connector.Core.Facade.Queries
{
    /// <summary>
    /// This is a Facade interface to execute function to validate if a resource exists.
    /// </summary>
    public interface IExistsResource
    {
        /// <summary>
        /// Function to validate if a Resource exists in a specific path.
        /// It can be a Folder or File.
        /// </summary>
        /// <param name="endpoint">Relative resource path location.</param>
        /// <returns>Exists resource flag.</returns>
        Task<bool> ExistsResourceAsync(string endpoint);
    }

    /// <summary>
    /// This is a Facade class to execute function to validate if a resource exists.
    /// </summary>
    public class ExistsResource : IExistsResource
    {
        private readonly ISharePointRequest _sharepoint;

        public ExistsResource(ISharePointRequest sharepoint)
            => _sharepoint = sharepoint;

        /// <summary>
        /// Function to validate if a Resource exists in a specific path.
        /// It can be a Folder or File.
        /// </summary>
        /// <param name="url">Relative resource path location.</param>
        /// <returns>Exists resource flag.</returns>
        public async Task<bool> ExistsResourceAsync(string endpoint)
        {
            try
            {
                // Configure method and endpoint request.
                var request = new HttpRequestMessage(HttpMethod.Get, $"_api/web/GetFolderByServerRelativeUrl('{endpoint}')/exists");
                // Configure required headers.
                request.Headers.Add("Accept", "application/json;odata=nometadata");
                // Request information to SharePoint API.
                var responseHttp = await _sharepoint.SendAsync(request);
                var response = JObject.Parse(await responseHttp.Content.ReadAsStringAsync());
                return response.Value<bool>("value");
            }
            catch
            {
                throw;
            }
        }
    }
}
