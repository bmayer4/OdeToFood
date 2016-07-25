using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MvcCoreTest.Entities;
using MvcCoreTest.Services;

namespace MvcCoreTest
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Originally this code changed the
            // service configuration together using 
            // fluent API calls but that caused configuration
            // errors. 
            services.AddMvc();

            services.AddEntityFramework();
            services.AddEntityFrameworkSqlServer();
            services.AddDbContext<OdeToFoodDbContext>(options => options.UseSqlServer(Configuration["database:connection"]));



            services.AddSingleton(provider => Configuration);
            services.AddSingleton<IGreeter, Greeter>();
            services.AddScoped<IRestaurantData, SqlRestaurantData>();
;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            IGreeter greeter)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /// The order in which middleware is added
            /// decides which middleware gets a chance
            /// to handle an incoming request first.

            // These don't work. I think app.UseIISIntegration()
            // was moved, but app.UseRuntimeInfoPage() is gone.
            //app.UseIISIntegration();
            //app.UseRuntimeInfoPage();

            // app.UseDefaultFiles() needs to come 
            // before app.UseStaticFiles().

            //app.UseDefaultFiles();
            //app.UseStaticFiles();

            app.UseFileServer();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(ConfigureRoute);

            app.Run(async (context) =>
            {
                //throw new Exception("test");
                //await context.Response.WriteAsync(Configuration["greeting"]);
                await context.Response.WriteAsync(greeter.GetGreeting());
            });
        }

        private void ConfigureRoute(IRouteBuilder routeBuilder)
        {
            // Ex: /Home/Index/
            // =Home, =Index tells it what to use 
            // when nothing is passed.
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
