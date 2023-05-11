using Newtonsoft.Json.Linq;
using SharePoint.Connector.Core.Facade.Requests;
using SharePoint.Connector.Core.Models;

namespace SharePoint.Connector.Core.Facade.Queries
{
    /// <summary>
    /// This interface contains the logic to get SharePoint site usage.
    /// </summary>
    public interface ISiteUsage
    {
        /// <summary>
        /// Function to get the usage information of a SharePoint site.
        /// </summary>
        /// <returns>Site Usage model.</returns>
        Task<SPSiteUsage?> SiteUsageAsync();
    }

    /// <summary>
    /// This class contains the logic to get SharePoint site usage.
    /// </summary>
    public class SiteUsage : ISiteUsage
    {
        private readonly ISharePointRequest _sharepoint;

        public SiteUsage(ISharePointRequest sharepoint)
            => _sharepoint = sharepoint;

        /// <summary>
        /// Function to get the usage information of a SharePoint site.
        /// </summary>
        /// <returns>Site Usage model.</returns>
        public async Task<SPSiteUsage?> SiteUsageAsync()
        {
            try
            {
                // Configure method and endpoint request.
                var request = new HttpRequestMessage(HttpMethod.Get, $"_api/site/usage");
                // Configure required headers.
                request.Headers.Add("Accept", "application/json;odata=nometadata");
                // Request information to SharePoint API.
                var responseHttp = await _sharepoint.SendAsync(request);
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
