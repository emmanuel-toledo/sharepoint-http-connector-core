using SharePoint.Connector.Core.Business.Configurations;
using SharePoint.Connector.Core.Business.Infrastructure.Requests;

namespace SharePoint.Connector.Core.Facade.Requests
{
    /// <summary>
    /// This interface defines the method to call each request to SharePoint.
    /// </summary>
    public interface ISharePointRequest
    {
        /// <summary>
        /// Method to send a request to SharePoint
        /// </summary>
        /// <param name="request">Http request message configuration.</param>
        /// <returns>Http response message.</returns>
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }

    /// <summary>
    /// This class implements the method to call each request to SharePoint.
    /// </summary>
    public class SharePointRequest : ISharePointRequest
    {
        private readonly HttpClient _client;

        private readonly ISharePointConfiguration _configuration;

        public SharePointRequest(IHttpClientFactory clientFactory, ISharePointConfiguration configuration)
        {
            _client = clientFactory.CreateClient("SharePointServiceClient");
            _configuration = configuration;
        }

        /// <summary>
        /// Method to send a request to SharePoint
        /// </summary>
        /// <param name="request">Http request message configuration.</param>
        /// <returns>Http response message.</returns>
        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            var responseHttp = await _client.SendAsync(request);
            if (!responseHttp.IsSuccessStatusCode && _configuration.ThrowExceptions)
                await responseHttp.ValidateException();
            return responseHttp;
        }
    }
}
