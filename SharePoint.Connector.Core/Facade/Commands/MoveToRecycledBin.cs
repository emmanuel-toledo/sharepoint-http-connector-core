using Newtonsoft.Json.Linq;
using SharePoint.Connector.Core.Facade.Requests;

namespace SharePoint.Connector.Core.Facade.Commands
{
    /// <summary>
    /// This interface define Move Recycled Bin method.
    /// </summary>
    public interface IMoveToRecycledBin
    {
        /// <summary>
        /// This function move a resource to the Recycled Bin of a site.
        /// </summary>
        /// <param name="endpoint">Resource path location.</param>
        /// <returns>Recycled resource unique identifier.</returns>
        Task<Guid> MoveToRecycledBinAsync(string endpoint);
    }

    /// <summary>
    /// This class implements Move Recycled Bin method.
    /// </summary>
    public class MoveToRecycledBin : IMoveToRecycledBin
    {
        private readonly ISharePointRequest _sharepoint;

        public MoveToRecycledBin(ISharePointRequest sharepoint)
            => _sharepoint = sharepoint;

        /// <summary>
        /// This function move a resource to the Recycled Bin of a site.
        /// </summary>
        /// <param name="endpoint">Resource path location.</param>
        /// <returns>Recycled resource unique identifier.</returns>
        public async Task<Guid> MoveToRecycledBinAsync(string endpoint)
        {
            try
            {
                // Configure method and endpoint request.
                var request = new HttpRequestMessage(HttpMethod.Post, $"_api/web/GetFolderByServerRelativeUrl('{ endpoint }')/recycle");
                request.Content = null;
                // Configure required headers.
                request.Headers.Add("Accept", "application/json;odata=nometadata");
                // Request information to SharePoint API.
                var responseHttp = await _sharepoint.SendAsync(request);
                // Get recycled bin resource unique identifier.
                var response = JObject.Parse(await responseHttp.Content.ReadAsStringAsync());
                return response.Value<string>("value") != string.Empty ? new Guid(response.Value<string>("value")!) : Guid.Empty;
            }
            catch
            {
                throw;
            }
        }
    }
}
