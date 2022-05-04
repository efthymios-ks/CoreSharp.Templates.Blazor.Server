using CoreSharp.Blazor.JavaScriptWrappers.Common;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace WebApp.UI.Extensions
{
    /// <summary>
    /// <see cref="IServiceCollection"/> extensions.
    /// </summary>
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddWebAppUI(this IServiceCollection services)
        {
            _ = services ?? throw new ArgumentNullException(nameof(services));

            services.AddJavaScriptWrappers();

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
