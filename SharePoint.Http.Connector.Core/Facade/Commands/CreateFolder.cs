using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharePoint.Http.Connector.Core.Facade.Requests;
using SharePoint.Http.Connector.Core.Models;

namespace SharePoint.Http.Connector.Core.Facade.Commands
{
    /// <summary>
    /// This interface defines Create Folder method.
    /// </summary>
    public interface ICreateFolder
    {
        /// <summary>
        /// Function to create a new folder in SharePoint.
        /// </summary>
        /// <param name="relativeURL">Folder relative URL location.</param>
        /// <returns>SharePoint folder object.</returns>
        Task<SPFolder?> SendAsync(string relativeURL);
    }

    /// <summary>
    /// This class implements Create Folder method.
    /// </summary>
    public class CreateFolder : ICreateFolder
    {
        private readonly ISharePointRequest _sharepoint;

        public CreateFolder(ISharePointRequest sharepoint)
            => _sharepoint = sharepoint;

        /// <summary>
        /// Function to create a new folder in SharePoint.
        /// </summary>
        /// <param name="relativeURL">Folder relative URL location.</param>
        /// <returns>SharePoint folder object.</returns>
        public async Task<SPFolder?> SendAsync(string relativeURL)
        {
            try
            {
                // Configure method and endpoint request.
                var request = new HttpRequestMessage(HttpMethod.Post, $"_api/web/folders");
                request.Content = new StringContent(JsonConvert.SerializeObject(new { ServerRelativeUrl = $"{ relativeURL }" }), Encoding.UTF8, "application/json");
                // Configure required headers.
                request.Headers.Add("Accept", "application/json;odata=nometadata");
                // Request information to SharePoint API.
                var responseHttp = await _sharepoint.SendAsync(request);
                if (!responseHttp.IsSuccessStatusCode)
                    return null;
                // Get Recycle bin resource unique identifier.
                var response = JObject.Parse(await responseHttp.Content.ReadAsStringAsync());
                return response.ToObject<SPFolder?>();
            } 
            catch
            {
                throw;
            }
        }
    }
}
