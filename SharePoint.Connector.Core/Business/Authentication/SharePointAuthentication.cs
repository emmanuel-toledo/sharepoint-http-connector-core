using Newtonsoft.Json.Linq;

namespace SharePoint.Connector.Core.Business.Authentication
{
    /// <summary>
    /// This interface define SharePoint Authentication method.
    /// </summary>
    internal interface ISharePointAuthentication
    {
        Task<string> GetAccessToken(KeyValuePair<string, string>[] content);
    }

    /// <summary>
    /// This class implements SharePoint Authentication method.
    /// </summary>
    internal class SharePointAuthentication : ISharePointAuthentication
    {
        private readonly IHttpClientFactory _clientFactory;

        public SharePointAuthentication(IHttpClientFactory clientFactory)
            => _clientFactory = clientFactory;

        /// <summary>
        /// Function to get access token to SharePoint site.
        /// </summary>
        /// <param name="content">Configurations to get access token.</param>
        /// <returns>Bearer access token.</returns>
        public async Task<string> GetAccessToken(KeyValuePair<string, string>[] content)
        {
            try
            {
                var client = _clientFactory.CreateClient("SharePointAuthClient");
                var responseHttp = await client.PostAsync("tokens/oAuth/2", new FormUrlEncodedContent(content));
                if (!responseHttp.IsSuccessStatusCode)
                    throw new Exception();
                    // TODO:
                    //await responseHttp.ValidateException();
                var response = JObject.Parse(await responseHttp.Content.ReadAsStringAsync());
                return response.Value<string>("access_token") ?? string.Empty;
            }
            catch
            {
                throw;
            }
        }
    }
}
