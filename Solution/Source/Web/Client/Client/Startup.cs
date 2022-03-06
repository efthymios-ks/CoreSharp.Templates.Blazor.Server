using CoreSharp.CleanStructure.Blazor.Client.Infrastructure.Extensions;
using CoreSharp.Extensions;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace CoreSharp.CleanStructure.Blazor.Client
{
    /// <summary>
    /// Pseudo-startup class.
    /// </summary>
    public static class Startup
    {
        //Methods
        public static void Configure(WebAssemblyHostBuilder builder)
        {
            _ = builder ?? throw new ArgumentNullException(nameof(builder));

            var services = builder.Services;
            var environment = builder.HostEnvironment;
            var configuration = ConfigureProviders(builder);

            ConfigureServices(services, configuration);
            ConfigureEnvironment(environment);
        }

        private static IConfiguration ConfigureProviders(WebAssemblyHostBuilder builder)
        {
            _ = builder ?? throw new ArgumentNullException(nameof(builder));

            var configuration = builder.Configuration;
            var environment = builder.HostEnvironment.Environment;

            configuration.AddEmbeddedFileConfiguration(options =>
            {
                options.ScanAssembly = Assembly.GetExecutingAssembly();
                options.Environment = environment;
                options.Location = "Resources";
            });

            return configuration.Build();
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            _ = services ?? throw new ArgumentNullException(nameof(services));

            services.AddClientInfrastructure(configuration);
        }

        private static void ConfigureEnvironment(IWebAssemblyHostEnvironment environment)
            => _ = environment ?? throw new ArgumentNullException(nameof(environment));
    }
}
