using CoreSharp.AspNetCore.Extensions;
using CoreSharp.Blazor.JavaScriptWrappers.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace WebApp.Extensions
{
    /// <summary>
    /// <see cref="IServiceCollection"/> extensions.
    /// </summary>
    internal static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddAppCors(this IServiceCollection services, IConfiguration configuration)
            => services.AddCors(configuration);

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
