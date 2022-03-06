using CoreSharp.CleanStructure.Blazor.Application.Repositories;
using CoreSharp.CleanStructure.Blazor.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CoreSharp.CleanStructure.Blazor.Infrastructure.Extensions
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

            services.AddAppDbContext(configuration);

            return services;
        }

        private static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            _ = services ?? throw new ArgumentNullException(nameof(services));
            _ = configuration ?? throw new ArgumentNullException(nameof(services));

            var connectionString = configuration.GetConnectionString("DefaultConnection");

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
