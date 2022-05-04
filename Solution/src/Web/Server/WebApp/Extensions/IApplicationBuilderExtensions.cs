using CoreSharp.AspNetCore.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using WebApp.Constants;

namespace WebApp.Extensions
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

        public static IApplicationBuilder UseAppCors(this IApplicationBuilder app)
        {
            _ = app ?? throw new ArgumentNullException(nameof(app));

            app.UseCors(Configuration.CorsPolicyName);

            return app;
        }
    }
}
