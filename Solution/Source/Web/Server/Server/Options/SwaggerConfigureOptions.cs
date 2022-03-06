using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace CoreSharp.CleanStructure.Blazor.Server.Options
{
    internal class SwaggerConfigureOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        //Fields
        private readonly IApiVersionDescriptionProvider _apiProvider;

        //Constructors
        public SwaggerConfigureOptions(IApiVersionDescriptionProvider apiProvider)
            => _apiProvider = apiProvider;

        //Methods
        public void Configure(string name, SwaggerGenOptions options)
            => Configure(options);

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _apiProvider.ApiVersionDescriptions)
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
        }

        private static OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var currentAssembly = Assembly.GetExecutingAssembly().GetName();
            var info = new OpenApiInfo
            {
                Title = currentAssembly.Name,
                Version = $"{description.ApiVersion}"
            };

            if (description.IsDeprecated)
                info.Title += " [Deprecated]";

            return info;
        }
    }
}
