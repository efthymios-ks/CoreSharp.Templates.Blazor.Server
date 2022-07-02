using AutoMapper;
using AutoMapper.Internal;
using CoreSharp.Extensions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace CoreSharp.Templates.Blazor.Server.Application.Extensions;

/// <summary>
/// <see cref="IServiceCollection"/> extensions.
/// </summary>
public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        _ = services ?? throw new ArgumentNullException(nameof(services));

        var executingAssembly = Assembly.GetExecutingAssembly();
        services.AddServices(executingAssembly);
        services.AddMarkedServices(executingAssembly);
        services.AddMarkedServices();
        services.AddAppMediatR();
        services.AddAppAutoMapper();

        return services;
    }

    private static IServiceCollection AddAppMediatR(this IServiceCollection services)
        => services.AddMediatR(Assembly.GetExecutingAssembly());

    private static IServiceCollection AddAppAutoMapper(this IServiceCollection services)
    {
        //Configure individual mappings 
        static void MappingConfig(TypeMap _, IMappingExpression mapping)
            => mapping.PreserveReferences();

        //Configure mapper framework 
        static void MapperConfig(IMapperConfigurationExpression mapper)
            => mapper.Internal().ForAllMaps(MappingConfig);

        services.AddAutoMapper(MapperConfig, Assembly.GetExecutingAssembly());

        return services;
    }
}
