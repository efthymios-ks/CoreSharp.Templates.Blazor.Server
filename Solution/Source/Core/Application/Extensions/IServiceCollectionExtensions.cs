using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace CoreSharp.CleanStructure.Blazor.Application.Extensions
{
    /// <summary>
    /// <see cref="IServiceCollection"/> extensions.
    /// </summary>
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            _ = services ?? throw new ArgumentNullException(nameof(services));

            services.AddAppMediatR();
            services.AddAppAutoMapper();

            return services;
        }

        private static IServiceCollection AddAppMediatR(this IServiceCollection services)
        {
            _ = services ?? throw new ArgumentNullException(nameof(services));

            return services.AddMediatR(Assembly.GetExecutingAssembly());
        }

        private static IServiceCollection AddAppAutoMapper(this IServiceCollection services)
        {
            _ = services ?? throw new ArgumentNullException(nameof(services));

            //Configure individual mappings 
            static void MappingConfig(TypeMap _, IMappingExpression mapping)
                => mapping.PreserveReferences();

            //Configure mapper framework 
            static void MapperConfig(IMapperConfigurationExpression mapper)
                => mapper.ForAllMaps(MappingConfig);

            services.AddAutoMapper(MapperConfig, Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
