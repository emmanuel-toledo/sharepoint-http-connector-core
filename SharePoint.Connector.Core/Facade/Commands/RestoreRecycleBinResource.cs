using SharePoint.Connector.Core.Facade.Requests;

namespace SharePoint.Connector.Core.Facade.Commands
{
    /// <summary>
    /// This interface defines Restore Recycle Bin method.
    /// </summary>
    public interface IRestoreRecycleBinResource
    {
        /// <summary>
        /// This function restore a resource from the Recycle Bin of a site.
        /// </summary>
        /// <param name="resourceId">Recycle Bin resource unique identifier.</param>
        /// <returns>Recycle resource restored flag.</returns>
        Task<bool> SendAsync(Guid resourceId);
    }

    /// <summary>
    /// This class implements Restore Recycle Bin method.
    /// </summary>
    public class RestoreRecycleBinResource : IRestoreRecycleBinResource
    {
        private readonly ISharePointRequest _sharepoint;

        public RestoreRecycleBinResource(ISharePointRequest sharepoint)
            => _sharepoint = sharepoint;

        /// <summary>
        /// This function restore a resource from the Recycle Bin of a site.
        /// </summary>
        /// <param name="resourceId">Recycle Bin resource unique identifier.</param>
        /// <returns>Recycle resource restored flag.</returns>
        public async Task<bool> SendAsync(Guid resourceId)
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
