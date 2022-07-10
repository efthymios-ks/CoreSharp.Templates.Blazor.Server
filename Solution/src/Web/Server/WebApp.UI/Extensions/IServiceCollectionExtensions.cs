using CoreSharp.Blazor.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace WebApp.UI.Extensions;

/// <summary>
/// <see cref="IServiceCollection"/> extensions.
/// </summary>
public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddWebAppUI(this IServiceCollection services)
    {
        _ = services ?? throw new ArgumentNullException(nameof(services));

        services.AddCoreSharpBlazor();
        services.AddJavaScriptWrappers(Assembly.GetExecutingAssembly());

        return services;
    }
}
