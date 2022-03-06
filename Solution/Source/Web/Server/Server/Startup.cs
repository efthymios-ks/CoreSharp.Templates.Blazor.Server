using CoreSharp.CleanStructure.Blazor.Application.Extensions;
using CoreSharp.CleanStructure.Blazor.Infrastructure.Extensions;
using CoreSharp.CleanStructure.Blazor.Server.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoreSharp.CleanStructure.Blazor.Server
{
    public class Startup
    {
        //Constructors
        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        //Properties
        public IConfiguration Configuration { get; }

        //Methods
        /// <summary>
        /// This method gets called by the runtime.
        /// Use this method to add services to the container.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            //Solution configurations 
            services.AddApplication();
            services.AddInfrastructure(Configuration);

            //Local configurations 
            services.AddAppApiVersioning();
            services.AddAppSwagger();
            services.AddAppCors(Configuration);

            //System 
            services.AddControllers();
        }

        /// <summary>
        /// This method gets called by the runtime.
        /// Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment environment, IApiVersionDescriptionProvider provider)
        {
            if (environment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            //Local configurations 
            app.UseAppMiddlewares(environment);
            app.UseAppSwagger(provider);
            app.UseAppCors();

            //System configurations 
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
