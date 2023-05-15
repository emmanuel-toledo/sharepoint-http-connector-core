using Newtonsoft.Json.Linq;
using Sharepoint.Http.Data.Connector.Business.Infrastructure.Exceptions;

namespace SharePoint.Http.Connector.Core.Business.Infrastructure.Requests
{
    /// <summary>
    /// This class contains extension methods to used in each request to SharePoint using REST API.
    /// </summary>
    internal static class ExceptionExtensions
    {
        /// <summary>
        /// Function to validate the type of error response during a connection with a Sharepoint instance.
        /// </summary>
        /// <param name="httpResponse">Response of connection with sharepoint instance.</param>
        /// <returns></returns>
        /// <exception cref="NotFoundException">Not found resource exception.</exception>
        /// <exception cref="BadRequestException">Bad request exception.</exception>
        /// <exception cref="UnauthorizedException">Unauthorized exception.</exception>
        /// <exception cref="InternalServerException">Internal server error exception.</exception>
        public static async Task ValidateException(this HttpResponseMessage httpResponse)
        {
            var status = httpResponse.StatusCode;
            string responseBody = await httpResponse.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(responseBody))
                httpResponse.EnsureSuccessStatusCode();
            var response = JObject.Parse(responseBody);
            switch (status)
            {
                case System.Net.HttpStatusCode.NotFound:
                    if (!string.IsNullOrEmpty((string)response["error_description"]))
                        throw new NotFoundException((string)response["error_description"]);
                    if ((JObject)response["error"] is not null)
                        throw new NotFoundException((string)response["error"]["message"]["value"]);
                    if ((JObject)response["odata.error"] is not null)
                        throw new NotFoundException((string)response["odata.error"]["message"]["value"]);
                    httpResponse.EnsureSuccessStatusCode();
                    break;
                case System.Net.HttpStatusCode.BadRequest:
                    if (!string.IsNullOrEmpty((string)response["error_description"]))
                        throw new BadRequestException((string)response["error_description"]);
                    if ((JObject)response["error"] is not null)
                        throw new BadRequestException((string)response["error"]["message"]["value"]);
                    if ((JObject)response["odata.error"] is not null)
                        throw new BadRequestException((string)response["odata.error"]["message"]["value"]);
                    httpResponse.EnsureSuccessStatusCode();
                    break;
                case System.Net.HttpStatusCode.Unauthorized:
                    if (!string.IsNullOrEmpty((string)response["error_description"]))
                        throw new UnauthorizedException((string)response["error_description"]);
                    httpResponse.EnsureSuccessStatusCode();
                    break;
                case System.Net.HttpStatusCode.InternalServerError:
                    if ((JObject)response["error"] is not null)
                        throw new InternalServerException((string)response["error"]["message"]["value"]);
                    if ((JObject)response["odata.error"] is not null)
                        throw new InternalServerException((string)response["odata.error"]["message"]["value"]);
                    httpResponse.EnsureSuccessStatusCode();
                    break;
                default:
                    httpResponse.EnsureSuccessStatusCode();
                    break;
            }
        }
    }
}
