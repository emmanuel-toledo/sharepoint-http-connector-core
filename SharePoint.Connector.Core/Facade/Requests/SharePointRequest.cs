using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePoint.Connector.Core.Facade.Requests
{
    public interface ISharePointRequest
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }

    public class SharePointRequest : ISharePointRequest
    {
        private readonly HttpClient _client;

        public SharePointRequest(IHttpClientFactory clientFactory)
            => _client = clientFactory.CreateClient("SharePointServiceClient");

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            var responseHttp = await _client.SendAsync(request);
            return responseHttp;
        }
    }
}
