using CoreSharp.AspNetCore.Middlewares;
using CoreSharp.CleanStructure.Blazor.Server.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Reflection;

namespace CoreSharp.CleanStructure.Blazor.Server.Extensions
{
    /// <summary>
    /// <see cref="IApplicationBuilder"/> extensions.
    /// </summary>
    internal static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseAppMiddlewares(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            _ = app ?? throw new ArgumentNullException(nameof(app));
            _ = env ?? throw new ArgumentNullException(nameof(env));

            app.UseMiddleware<ErrorHandleMiddleware>();
            if (!env.IsProduction())
                app.UseMiddleware<RequestLogMiddleware>();

            return app;
        }

        public static IApplicationBuilder UseAppSwagger(this IApplicationBuilder app, IApiVersionDescriptionProvider apiProvider)
        {
            _ = app ?? throw new ArgumentNullException(nameof(app));
            _ = apiProvider ?? throw new ArgumentNullException(nameof(apiProvider));

            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                var currentAssembly = Assembly.GetExecutingAssembly().GetName();
                var apiVersions = apiProvider.ApiVersionDescriptions.OrderByDescending(v => v.GroupName);
                foreach (var apiVersion in apiVersions)
                {
                    config.SwaggerEndpoint(
                        $"/swagger/{apiVersion.GroupName}/swagger.json",
                        apiVersion.GroupName.ToUpperInvariant());
                }
            });

            return app;
        }

        public static IApplicationBuilder UseAppCors(this IApplicationBuilder app)
        {
            _ = app ?? throw new ArgumentNullException(nameof(app));

            app.UseCors(Configuration.CorsPolicyName);

            return app;
        }
    }
}
