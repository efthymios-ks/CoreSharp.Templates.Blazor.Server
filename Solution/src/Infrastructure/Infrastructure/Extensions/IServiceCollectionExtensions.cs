using CoreSharp.Extensions;
using CoreSharp.Templates.Blazor.Server.Application.Repositories;
using CoreSharp.Templates.Blazor.Server.Infrastructure.Context;
using CoreSharp.Templates.Blazor.Server.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace CoreSharp.Templates.Blazor.Server.Infrastructure.Extensions
{
    /// <summary>
    /// <see cref="IServiceCollection"/> extensions.
    /// </summary>
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            _ = services ?? throw new ArgumentNullException(nameof(services));
            _ = configuration ?? throw new ArgumentNullException(nameof(services));

            var executingAssembly = Assembly.GetExecutingAssembly();
            services.AddServices(executingAssembly);
            services.AddMarkedServices(executingAssembly);
            services.AddAppDbContext(configuration);

            return services;
        }

        private static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");

            static void SqlServerConfigure(SqlServerDbContextOptionsBuilder options)
                => options.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);

            void DbContextConfigure(DbContextOptionsBuilder options)
              => options.UseSqlServer(connectionString, SqlServerConfigure);

            services.AddDbContext<AppDbContext>(DbContextConfigure);
            services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();

            return services;
        }
    }
}
