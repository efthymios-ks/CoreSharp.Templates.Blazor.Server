using CoreSharp.CleanStructure.Blazor.Shared.Constants;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;

namespace CoreSharp.CleanStructure.Blazor.Server.SwaggerFilters
{
    internal class ApiVersionFilter : IOperationFilter
    {
        //Fields
        private static string SwaggerApiHeaderKey
            => HeaderNamesX.AcceptVersion;

        //Methods
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var apiVersion = GetApiVersion(context);
            if (string.IsNullOrEmpty(apiVersion))
                return;

            var apiVersionParameter = GetApiVersionParameter(operation);
            if (apiVersionParameter is null)
                return;

            apiVersionParameter.Required = false;
            apiVersionParameter.Example = new OpenApiString($"{apiVersion}");
        }

        private static bool IsApiHeaderParameter(string parameterName)
             => string.Equals(SwaggerApiHeaderKey, parameterName, StringComparison.InvariantCultureIgnoreCase);

        private static string GetApiVersion(OperationFilterContext context)
        {
            var apiVersion = context.ApiDescription.ParameterDescriptions
                                    .FirstOrDefault(p => IsApiHeaderParameter(p.Name))?.DefaultValue;
            return $"{apiVersion}";
        }

        private static OpenApiParameter GetApiVersionParameter(OpenApiOperation operation)
            => operation.Parameters.FirstOrDefault(p => IsApiHeaderParameter(p.Name));
    }
}
