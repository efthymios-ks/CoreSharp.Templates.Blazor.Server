using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace CoreSharp.CleanStructure.Blazor.Server.Extensions
{
    /// <summary>
    /// <see cref="SwaggerGeneratorOptions"/> extensions.
    /// </summary>
    internal static class SwaggerGenOptionsExtensions
    {
        /// <summary>
        /// <para>Sort Swagger actions by method name.</para>
        /// <para>GET, POST, PUT, PATCH, DELETE, OPTIONS, TRACE.</para>
        /// Remember! Swagger groups all actions by relative path and cannot be yet overriden.
        /// </summary>
        public static void OrderActionsByHttpMethod(this SwaggerGenOptions options)
        {
            var orderedHttpMethods = new[] {
                        HttpMethods.Get,
                        HttpMethods.Post,
                        HttpMethods.Put,
                        HttpMethods.Patch,
                        HttpMethods.Delete,
                        HttpMethods.Options,
                        HttpMethods.Trace
                    };

            int FindHttpMethodIndex(string method)
                => Array.FindIndex(orderedHttpMethods, m => string.Equals(m, method, StringComparison.InvariantCultureIgnoreCase));

            options.OrderActionsBy(api =>
            {
                var controllerName = api.ActionDescriptor.RouteValues["controller"];
                var methodIndex = FindHttpMethodIndex(api.HttpMethod);
                var relativePath = api.RelativePath;
                return $"{controllerName}_{methodIndex}_{relativePath}";
            });
        }
    }
}
