using CoreSharp.Extensions;
using CoreSharp.Templates.Blazor.Server.Application.Extensions;
using CoreSharp.Templates.Blazor.Server.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using WebApp.Extensions;
using WebApp.UI.Extensions;

namespace WebApp;

public class Startup
{
    //Properties
    public IConfiguration Configuration { get; }

    //Constructors 
    public Startup(IConfiguration configuration)
        => Configuration = configuration;

    //Methods 
    /// <summary>
    /// This method gets called by the runtime. Use this method to add services to the container.
    /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    /// </summary>
    public void ConfigureServices(IServiceCollection services)
    {
        //User 
        services.AddApplication();
        services.AddInfrastructure(Configuration);
        services.AddWebAppUI();
        services.AddServices(Assembly.GetExecutingAssembly());
        services.AddCurrentUser();

        //System
        services.AddHttpContextAccessor();
        services.AddRazorPages(options => options.RootDirectory = "/Features");
        services.AddServerSideBlazor();
    }

    /// <summary>
    /// This method gets called by the runtime.
    /// Use this method to configure the HTTP request pipeline.
    /// </summary>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
    {
        //Environment dependent
        if (environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
        }

        //System 
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapBlazorHub();
            endpoints.MapFallbackToPage("/_Host");
        });
    }
}
