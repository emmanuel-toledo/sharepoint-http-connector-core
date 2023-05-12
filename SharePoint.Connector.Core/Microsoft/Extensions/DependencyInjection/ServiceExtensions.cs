using Microsoft.Extensions.Configuration;
using SharePoint.Connector.Core.Persistences;
using Microsoft.Extensions.DependencyInjection;
using SharePoint.Connector.Core.Models.Configurations;
using SharePoint.Connector.Core.Business.Queries;
using SharePoint.Connector.Core.Business.Commands;

namespace SharePoint.Connector.Core.Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Static class to add the use of this library as new Service using Dependency Injection
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Configure one SharePoint site with a HTTP client.
        /// </summary>
        /// <param name="services">Application service collection.</param>
        /// <param name="configuration">Context configuration connection.</param>
        public static void UseSharePointSite(this IServiceCollection services, SPContextConfiguration configuration, bool throwExceptions = true)
        {
            // Configure HTTP clients.
            services.ConfigureClients(configuration);
            // Configure Global variables as Service.
            services.ConfigureAppSharePointContext(configuration, throwExceptions);
            // Configure Facades services.
            services.ConfigureFacadeQueriesServices();
            services.ConfigureFacadeCommandsServices();
            // Configure HTTP query requests as services.
            services.AddScoped<ISharePointQueries, SharePointQueries>();
            // Configure HTTP command requests as services.
            services.AddScoped<ISharePointCommands, SharePointCommands>();
            // Configure main SharePoint Context service.
            services.AddScoped<ISharePointContext, SharePointContext>();
        }

        /// <summary>
        /// Configure one SharePoint site with a HTTP client.
        /// </summary>
        /// <param name="services">Application service collection.</param>
        /// <param name="configurationSection">Application configuration section.</param>
        public static void UseSharePointSite(this IServiceCollection services, IConfigurationSection configurationSection, bool throwExceptions = true)
        {
            // Bind Configuration Section to model.
            var configuration = new SPContextConfiguration();
            configurationSection.Bind(configuration, opts => opts.BindNonPublicProperties = true);

            // Execute main configuration method.
            services.UseSharePointSite(configuration, throwExceptions);
        }
    }
}
