using Newtonsoft.Json.Linq;
using SharePoint.Http.Connector.Core.Facade.Requests;

namespace SharePoint.Http.Connector.Core.Facade.Commands
{
    /// <summary>
    /// This interface defines Move Recycle Bin method.
    /// </summary>
    public interface IMoveToRecycleBin
    {
        /// <summary>
        /// This function move a resource to the Recycle Bin of a site.
        /// </summary>
        /// <param name="relativeURL">Resource's relative URL.</param>
        /// <returns>Recycle resource unique identifier.</returns>
        Task<Guid> SendAsync(string relativeURL);
    }

    /// <summary>
    /// This class implements Move Recycle Bin method.
    /// </summary>
    public class MoveToRecycleBin : IMoveToRecycleBin
    {
        private readonly ISharePointRequest _sharepoint;

        public MoveToRecycleBin(ISharePointRequest sharepoint)
            => _sharepoint = sharepoint;

        /// <summary>
        /// This function move a resource to the Recycle Bin of a site.
        /// </summary>
        /// <param name="relativeURL">Resource's relative URL.</param>
        /// <returns>Recycle resource unique identifier.</returns>
        public async Task<Guid> SendAsync(string relativeURL)
        {
            try
            {
                // Configure method and endpoint request.
                var request = new HttpRequestMessage(HttpMethod.Post, $"_api/web/GetFolderByServerRelativeUrl('{ relativeURL }')/recycle");
                request.Content = null;
                // Configure required headers.
                request.Headers.Add("Accept", "application/json;odata=nometadata");
                // Request information to SharePoint API.
                var responseHttp = await _sharepoint.SendAsync(request);
                if (!responseHttp.IsSuccessStatusCode)
                    return Guid.Empty;
                // Get Recycle bin resource unique identifier.
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
