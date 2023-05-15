using Newtonsoft.Json.Linq;
using SharePoint.Http.Connector.Core.Facade.Requests;
using SharePoint.Http.Connector.Core.Models;

namespace SharePoint.Http.Connector.Core.Facade.Queries
{
    /// <summary>
    /// This interface contains the logic to get SharePoint site usage.
    /// </summary>
    public interface IGetSiteUsage
    {
        /// <summary>
        /// Function to get the usage information of a SharePoint site.
        /// </summary>
        /// <returns>Site Usage model.</returns>
        Task<SPSiteUsage?> SendAsync();
    }

    /// <summary>
    /// This class contains the logic to get SharePoint site usage.
    /// </summary>
    public class GetSiteUsage : IGetSiteUsage
    {
        private readonly ISharePointRequest _sharepoint;

        public GetSiteUsage(ISharePointRequest sharepoint)
            => _sharepoint = sharepoint;

        /// <summary>
        /// Function to get the usage information of a SharePoint site.
        /// </summary>
        /// <returns>Site Usage model.</returns>
        public async Task<SPSiteUsage?> SendAsync()
        {
            try
            {
                // Configure method and endpoint request.
                var request = new HttpRequestMessage(HttpMethod.Get, $"_api/site/usage");
                // Configure required headers.
                request.Headers.Add("Accept", "application/json;odata=nometadata");
                // Request information to SharePoint API.
                var responseHttp = await _sharepoint.SendAsync(request);
                if (!responseHttp.IsSuccessStatusCode)
                    return null;
                var dto = JObject.Parse(await responseHttp.Content.ReadAsStringAsync()).ToObject<SPSiteUsage>() ?? null;
                return dto;
            }
            catch
            {
                throw;
            }
        }
    }
}
