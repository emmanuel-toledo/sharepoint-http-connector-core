using Microsoft.Extensions.DependencyInjection;
using SharePoint.Connector.Core.Models.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePoint.Connector.Core.Microsoft.Extensions
{
    public static class ServiceExtensions
    {
        internal static void CreateClients(this IServiceCollection service, ContextConfiguration configuration)
        {
            service.AddHttpClient("authentication", client =>
            {
                client.BaseAddress = new Uri(configuration.AuthenticationUrl);
                //var content = new[]
                //{
                //    new KeyValuePair<string, string>("resource", configuration.Resource),
                //    new KeyValuePair<string, string>("client_id", configuration.ClientId),
                //    new KeyValuePair<string, string>("client_secret", configuration.ClientSecret),
                //    new KeyValuePair<string, string>("grant_type", configuration.GrantType),
                //};
            });
        }
    }
}
