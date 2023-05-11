using SharePoint.Connector.Core.Facade.Requests;

namespace SharePoint.Connector.Core.Facade.Commands
{
    /// <summary>
    /// This interface define Restore Recycled Bin method.
    /// </summary>
    public interface IRestoreFromRecycledBin
    {
        /// <summary>
        /// This function restore a resource from the Recycled Bin of a site.
        /// </summary>
        /// <param name="resourceId">Recycled Bin resource unique identifier.</param>
        /// <returns>Recycled resource restored flag.</returns>
        Task<bool> RestoreFromRecycledBinAsync(Guid resourceId);
    }

    /// <summary>
    /// This class implements Restore Recycled Bin method.
    /// </summary>
    public class RestoreFromRecycledBin : IRestoreFromRecycledBin
    {
        private readonly ISharePointRequest _sharepoint;

        public RestoreFromRecycledBin(ISharePointRequest sharepoint)
            => _sharepoint = sharepoint;

        /// <summary>
        /// This function restore a resource from the Recycled Bin of a site.
        /// </summary>
        /// <param name="resourceId">Recycled Bin resource unique identifier.</param>
        /// <returns>Recycled resource restored flag.</returns>
        public async Task<bool> RestoreFromRecycledBinAsync(Guid resourceId)
        {
            try
            {
                // Configure method and endpoint request.
                var request = new HttpRequestMessage(HttpMethod.Post, $"_api/web/recyclebin('{ resourceId }')/restore");
                request.Content = null;
                // Configure required headers.
                request.Headers.Add("Accept", "application/json;odata=nometadata");
                // Request information to SharePoint API.
                var responseHttp = await _sharepoint.SendAsync(request);
                return responseHttp.IsSuccessStatusCode;
            }
            catch 
            {
                throw;
            }
        }
    }
}
