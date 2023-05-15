using Microsoft.Extensions.DependencyInjection;
using SharePoint.Http.Connector.Core.Business.Authentication;
using SharePoint.Http.Connector.Core.Business.Configurations;
using SharePoint.Http.Connector.Core.Facade.Commands;
using SharePoint.Http.Connector.Core.Facade.Queries;
using SharePoint.Http.Connector.Core.Facade.Requests;
using SharePoint.Http.Connector.Core.Models.Configurations;

namespace SharePoint.Http.Connector.Core.Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Internal static configuration to create different HTTP Clients.
    /// </summary>
    internal static class InternalServiceExtensions
    {
        /// <summary>
        /// Function to configure HTTP clients to access to SharePoint API. This method create both authentication client and service client.
        /// </summary>
        /// <param name="services">Application service collection.</param>
        /// <param name="configuration">Application context configuration.</param>
        internal static void ConfigureClients(this IServiceCollection services, SPContextConfiguration configuration)
        {
            services.ConfigureAuthenticationClient(configuration);

            services.AddScoped<ISharePointAuthentication, SharePointAuthentication>();

            services.ConfigureServiceClient(configuration, new[]
            {
                new KeyValuePair<string, string>("resource", $"00000003-0000-0ff1-ce00-000000000000/{ configuration.SharePointSiteURL.Split("/")[2] }@{ configuration.TenantId }"),
                new KeyValuePair<string, string>("client_id", configuration.ClientId),
                new KeyValuePair<string, string>("client_secret", configuration.ClientSecret),
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
            });

            services.AddScoped<ISharePointRequest, SharePointRequest>();
        }

        /// <summary>
        /// Function to configure each Service to use with SharePoint API for data queries.
        /// </summary>
        /// <param name="services">Application service collection.</param>
        internal static void ConfigureFacadeQueriesServices(this IServiceCollection services)
        {
            services.AddScoped<IExistsResource, ExistsResource>();
            services.AddScoped<IGetLibraryDocuments, GetLibraryDocuments>();
            services.AddScoped<IGetSiteUsage, GetSiteUsage>();
            services.AddScoped<IGetRecycleBinResourceById, GetRecycleBinResourceById>();
            services.AddScoped<IGetFileContent, GetFileContent>();
            services.AddScoped<IGetFile, GetFile>();
            services.AddScoped<IGetFiles, GetFiles>();
        }

        /// <summary>
        /// Function to configure each Service to use with SharePoint API for data commands.
        /// </summary>
        /// <param name="services">Application service collection.</param>
        internal static void ConfigureFacadeCommandsServices(this IServiceCollection services)
        {
            services.AddScoped<IDeleteResource, DeleteResource>();
            services.AddScoped<IMoveToRecycleBin, MoveToRecycleBin>();
            services.AddScoped<IRestoreRecycleBinResource, RestoreRecycleBinResource>();
            services.AddScoped<ICreateFolder, CreateFolder>();
            services.AddScoped<IUploadFile, UploadFile>();
        }

        /// <summary>
        /// Function to configure Global Variables as Singleton service for only one configuration.
        /// </summary>
        /// <param name="services">Application service collection.</param>
        /// <param name="configuration">Application context configuration.</param>
        internal static void ConfigureAppSharePointContext(this IServiceCollection services, SPContextConfiguration configuration, bool throwExceptions)
        {
            services.AddSingleton<ISharePointConfiguration, SharePointConfiguration>(serviceProvider =>
            {
                var service = new SharePointConfiguration(configuration, throwExceptions);
                return service;
            });
        }

        /// <summary>
        /// Function to configure a HTTP Factory Client for authentication.
        /// </summary>
        /// <param name="services">Application service collection.</param>
        /// <param name="configuration">Application context configuration.</param>
        internal static void ConfigureAuthenticationClient(this IServiceCollection services, SPContextConfiguration configuration)
            => services.AddHttpClient("SharePointAuthClient", client =>
                client.BaseAddress = new Uri($"https://accounts.accesscontrol.windows.net/{configuration.TenantId}/"));

        /// <summary>
        /// Function to configure a HTTP Factory Client for authentication.
        /// </summary>
        /// <param name="services">Application service collection.</param>
        /// <param name="configuration">Application context configuration.</param>
        internal static void ConfigureServiceClient(this IServiceCollection services, SPContextConfiguration configuration, KeyValuePair<string, string>[] content)
            => services.AddHttpClient("SharePointServiceClient", client =>
            {
                // access the DI container.
                var serviceProvider = services.BuildServiceProvider();
                // Find the ISharePointAuthentication service.
                var authClient = serviceProvider.GetService<ISharePointAuthentication>()!;
                // Configure token for each request.
                var token = authClient.GetAccessToken(content).Result;
                // Add authorization if found.
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                client.BaseAddress = new Uri(configuration.SharePointSiteURL);
            });
    }
}
