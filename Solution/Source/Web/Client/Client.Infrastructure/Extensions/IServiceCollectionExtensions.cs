using CoreSharp.CleanStructure.Blazor.Client.Infrastructure.Constants;
using CoreSharp.CleanStructure.Blazor.Client.Infrastructure.JavaScriptWrappers.Abstracts;
using CoreSharp.CleanStructure.Blazor.Client.Infrastructure.Services;
using CoreSharp.CleanStructure.Blazor.Client.Infrastructure.Services.Abstracts;
using CoreSharp.CleanStructure.Blazor.Client.Infrastructure.Services.Contracts;
using CoreSharp.CleanStructure.Blazor.Shared.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;

namespace CoreSharp.CleanStructure.Blazor.Client.Infrastructure.Extensions
{
    /// <summary>
    /// <see cref="IServiceCollection"/> extensions.
    /// </summary>
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddClientInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            _ = services ?? throw new ArgumentNullException(nameof(services));
            _ = configuration ?? throw new ArgumentNullException(nameof(configuration));

            services.AddAppApiClient(configuration);
            services.AddScoped<IAppContextService, AppContextService>();
            services.AddApiEndpoints();
            services.AddJavaScriptWrappers();

            return services;
        }

        private static IServiceCollection AddAppApiClient(this IServiceCollection services, IConfiguration configuration)
        {
            _ = services ?? throw new ArgumentNullException(nameof(services));
            _ = configuration ?? throw new ArgumentNullException(nameof(configuration));

            //Get server endpoint 
            const string key = "Endpoints:AppServer";
            var serverEndpoint = configuration.GetValue<string>(key);
            if (string.IsNullOrWhiteSpace(serverEndpoint))
                throw new ConfigurationKeyNotFoundException(key);

            //Format 
            if (serverEndpoint.EndsWith('/'))
                serverEndpoint = serverEndpoint.TrimEnd('/');
            var apiEndpoint = $"{serverEndpoint}/api/";

            //Configure 
            void ConfigureClient(HttpClient client)
                => client.BaseAddress = new Uri(apiEndpoint);

            //Register 
            services.AddHttpClient(Configuration.AppApiHttpClientName, ConfigureClient);

            return services;
        }

        private static IServiceCollection AddApiEndpoints(this IServiceCollection services)
        {
            _ = services ?? throw new ArgumentNullException(nameof(services));

            var apiEndpoints = Assembly.GetExecutingAssembly()
                                       .GetExportedTypes()
                                       .Where(t => t.IsClass && !t.IsAbstract && t.BaseType == typeof(ApiEndpointBase));
            foreach (var apiEndpoint in apiEndpoints)
                services.AddScoped(apiEndpoint);

            return services;
        }

        private static IServiceCollection AddJavaScriptWrappers(this IServiceCollection services)
        {
            _ = services ?? throw new ArgumentNullException(nameof(services));

            var jsWrappers = Assembly.GetExecutingAssembly()
                                     .GetExportedTypes()
                                     .Where(t => t.IsClass && !t.IsAbstract && t.BaseType == typeof(JsWrapperBase));
            foreach (var jsWrapper in jsWrappers)
                services.AddTransient(jsWrapper);

            return services;
        }
    }
}
