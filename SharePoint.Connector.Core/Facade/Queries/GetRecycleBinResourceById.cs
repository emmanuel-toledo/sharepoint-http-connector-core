using Newtonsoft.Json.Linq;
using SharePoint.Connector.Core.Models;
using SharePoint.Connector.Core.Facade.Requests;

namespace SharePoint.Connector.Core.Facade.Queries
{
    /// <summary>
    /// This interface defines get Recycle bin resource method.
    /// </summary>
    public interface IGetRecycleBinResourceById
    {
        /// <summary>
        /// Function to get a resource from Recycle bin using an unique identifier.
        /// </summary>
        /// <param name="resourceId">Recycle bin resource unique identifier.</param>
        /// <returns>Recycle bin resource object.</returns>
        Task<SPRecycleResource?> SendAsync(Guid resourceId);
    }

    /// <summary>
    /// This class implements get Recycle bin resource method.
    /// </summary>
    public class GetRecycleBinResourceById : IGetRecycleBinResourceById
    {
        private readonly ISharePointRequest _sharepoint;

        public GetRecycleBinResourceById(ISharePointRequest sharepoint)
            => _sharepoint = sharepoint;

        /// <summary>
        /// Function to get a resource from Recycle bin using an unique identifier.
        /// </summary>
        /// <param name="resourceId">Recycle bin resource unique identifier.</param>
        /// <returns>Recycle bin resource object.</returns>
        public async Task<SPRecycleResource?> SendAsync(Guid resourceId)
        {
            try
            {
                // Configure method and endpoint request.
                var request = new HttpRequestMessage(HttpMethod.Get, $"_api/web/recyclebin('{ resourceId }')");
                // Configure required headers.
                request.Headers.Add("Accept", "application/json;odata=nometadata");
                // Request information to SharePoint API.
                var responseHttp = await _sharepoint.SendAsync(request);
                if (!responseHttp.IsSuccessStatusCode)
                    return null;
                var dto = JObject.Parse(await responseHttp.Content.ReadAsStringAsync()).ToObject<SPRecycleResource>() ?? null;
                return dto;
            }
            catch
            {
                throw;
            }
        }
    }
}
