using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OdeToFood.Web.Services;

namespace OdeToFood.Web
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    internal sealed class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IAppSettings, AppSettings>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env, ILoggerFactory loggerFactory,
            IAppSettings appSettings)
        {

            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app
                //.UseDefaultFiles()
                //    .UseStaticFiles()
                .UseFileServer() //use file server is a direct replacement to call default and then static
               .UseWelcomePage("/hello")
            //   .UseMvcWithDefaultRoute( new 

            .Run(async (context) =>
            {
                await context.Response.WriteAsync(appSettings.GetHelloWorldText());
            });
        }
    }
}
