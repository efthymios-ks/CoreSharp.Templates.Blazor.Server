using CoreSharp.CleanStructure.Blazor.Domain.Entities;
using CoreSharp.EntityFramework.Models.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace CoreSharp.CleanStructure.Blazor.Infrastructure.Context
{
    public class AppDbContext : DbContextBase
    {
        //Constructors
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        //Properties
        public DbSet<Dummy> Dummies { get; set; }

        //Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Always call base method 
            base.OnModelCreating(modelBuilder);

            ConfigureEnums(modelBuilder);
            ConfigureModels(modelBuilder);
        }

        private static void ConfigureEnums(ModelBuilder modelBuilder)
            => _ = modelBuilder ?? throw new ArgumentNullException(nameof(modelBuilder));

        private static void ConfigureModels(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
