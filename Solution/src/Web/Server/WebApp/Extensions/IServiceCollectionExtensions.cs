using CoreSharp.Blazor.JavaScriptWrappers.Common;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WebApp.Constants;

namespace WebApp.Extensions
{
    /// <summary>
    /// <see cref="IServiceCollection"/> extensions.
    /// </summary>
    internal static class IServiceCollectionExtensions
    {
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

        public static IServiceCollection AddJavaScriptWrappers(this IServiceCollection services)
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
