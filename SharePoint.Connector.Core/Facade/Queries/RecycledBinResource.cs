using Newtonsoft.Json.Linq;
using SharePoint.Connector.Core.Models;
using SharePoint.Connector.Core.Facade.Requests;

namespace SharePoint.Connector.Core.Facade.Queries
{
    /// <summary>
    /// This interface define get recycled bin resource method.
    /// </summary>
    public interface IRecycledBinResource
    {
        /// <summary>
        /// Function to get a resource from recycled bin using an unique identifier.
        /// </summary>
        /// <param name="resourceId">Recycled bin resource unique identifier.</param>
        /// <returns>Recycled bin resource object.</returns>
        Task<SPRecycledResource?> RecycledBinResourceAsync(Guid resourceId);
    }

    /// <summary>
    /// This class implements get recycled bin resource method.
    /// </summary>
    public class RecycledBinResource : IRecycledBinResource
    {
        private readonly ISharePointRequest _sharepoint;

        public RecycledBinResource(ISharePointRequest sharepoint)
            => _sharepoint = sharepoint;

        /// <summary>
        /// Function to get a resource from recycled bin using an unique identifier.
        /// </summary>
        /// <param name="resourceId">Recycled bin resource unique identifier.</param>
        /// <returns>Recycled bin resource object.</returns>
        public async Task<SPRecycledResource?> RecycledBinResourceAsync(Guid resourceId)
        {
            try
            {
                // Configure method and endpoint request.
                var request = new HttpRequestMessage(HttpMethod.Get, $"_api/web/recyclebin('{ resourceId }')");
                // Configure required headers.
                request.Headers.Add("Accept", "application/json;odata=nometadata");
                // Request information to SharePoint API.
                var responseHttp = await _sharepoint.SendAsync(request);
                var dto = JObject.Parse(await responseHttp.Content.ReadAsStringAsync()).ToObject<SPRecycledResource>() ?? null;
                return dto;
            }
            catch
            {
                throw;
            }
        }
    }
}
