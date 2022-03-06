using CoreSharp.CleanStructure.Blazor.Server.Constants;
using CoreSharp.CleanStructure.Blazor.Server.Options;
using CoreSharp.CleanStructure.Blazor.Server.Services;
using CoreSharp.CleanStructure.Blazor.Server.Services.Contracts;
using CoreSharp.CleanStructure.Blazor.Server.SwaggerFilters;
using CoreSharp.CleanStructure.Blazor.Shared.Constants;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CoreSharp.CleanStructure.Blazor.Server.Extensions
{
    /// <summary>
    /// <see cref="IServiceCollection"/> extensions.
    /// </summary>
    internal static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddAppApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
                config.ApiVersionSelector = new CurrentImplementationApiVersionSelector(config);
                config.ApiVersionReader = new HeaderApiVersionReader { HeaderNames = { HeaderNamesX.AcceptVersion } };
            });

            services.AddVersionedApiExplorer(config =>
            {
                config.GroupNameFormat = "'v'VVV";
                config.AssumeDefaultVersionWhenUnspecified = true;
            });

            return services;
        }

        public static IServiceCollection AddAppSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                //Add xml documentation 
                var currentAssembly = Assembly.GetExecutingAssembly().GetName();
                var xmlFileName = $"{currentAssembly.Name}.xml";
                var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                config.IncludeXmlComments(xmlFilePath);

                //Add api version filter
                config.OperationFilter<ApiVersionFilter>();

                //Sort api actions by method 
                config.OrderActionsByHttpMethod();

                services.ConfigureOptions<SwaggerConfigureOptions>();
            });

            services.ConfigureOptions<SwaggerConfigureOptions>();

            return services;
        }

        public static IServiceCollection AddAppLocalServices(this IServiceCollection services)
        {
            _ = services ?? throw new ArgumentNullException(nameof(services));

            services.AddScoped<ICurrentUserService, CurrentUserService>();

            return services;
        }

        public static IServiceCollection AddAppCors(this IServiceCollection services, IConfiguration configuration)
        {
            _ = services ?? throw new ArgumentNullException(nameof(services));
            _ = configuration ?? throw new ArgumentNullException(nameof(configuration));

            void ConfigureOrigins(CorsPolicyBuilder policy)
            {
                var allowedOrigins = configuration.GetSection("Cors:AllowedOrigins")
                                                  .Get<IEnumerable<string>>()
                                                  .Select(o => o.TrimEnd('/'))
                                                  .ToArray();

                if (allowedOrigins.Contains("*"))
                    policy.AllowAnyOrigin();
                else
                    policy.WithOrigins(allowedOrigins);
            }

            void ConfigureMethods(CorsPolicyBuilder policy)
            {
                var allowedMethods = configuration.GetSection("Cors:AllowedMethods")
                                                  .Get<IEnumerable<string>>()
                                                  .Select(m => m.ToUpperInvariant().Trim())
                                                  .ToArray();
                //Validate arguments 
                var validMethods = new Func<string, bool>[] {
                    HttpMethods.IsGet,
                    HttpMethods.IsPost,
                    HttpMethods.IsPut,
                    HttpMethods.IsPatch,
                    HttpMethods.IsDelete,
                    HttpMethods.IsHead,
                    HttpMethods.IsTrace,
                    HttpMethods.IsOptions
                };
                bool IsValidMethod(string method)
                    => method == "*" || validMethods.Any(m => m(method));
                if (Array.Find(allowedMethods, m => !IsValidMethod(m)) is string invalidMethod)
                    throw new ArgumentOutOfRangeException(null, $"Invalid entry at `Cors:AllowedMethods` ({invalidMethod}).");

                if (allowedMethods.Contains("*"))
                    policy.AllowAnyMethod();
                else
                    policy.WithMethods(allowedMethods);
            }

            void ConfigureHeaders(CorsPolicyBuilder policy)
            {
                var allowedHeaders = configuration.GetSection("Cors:AllowedHeaders")
                                                  .Get<string[]>();
                //Headers 
                if (allowedHeaders.Contains("*"))
                    policy.AllowAnyHeader();
                else
                    policy.WithHeaders(allowedHeaders);

                //Exposed headers 
                policy.WithExposedHeaders(HeaderNames.ContentDisposition);
            }

            void ConfigureCorsPolicy(CorsPolicyBuilder policy)
            {
                ConfigureOrigins(policy);
                ConfigureMethods(policy);
                ConfigureHeaders(policy);
            }

            void ConfigureCorsOptions(CorsOptions options)
                => options.AddPolicy(Configuration.CorsPolicyName, ConfigureCorsPolicy);

            services.AddCors(ConfigureCorsOptions);

            return services;
        }
    }
}
