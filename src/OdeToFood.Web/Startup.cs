using System.Diagnostics.CodeAnalysis;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OdeToFood.Web.Services;

namespace OdeToFood.Web
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    internal sealed class Startup
    {
        private IConfigurationRoot _appSettingsConfiguration;

        private void BuildAppSettings(IHostingEnvironment env)
        {
            var path = Path.Combine(
                env.ContentRootPath,
                @"configs", //to avoid directory separator.
                "appsettings.json");
            var builder = new ConfigurationBuilder()
                .AddJsonFile(path);
                
            _appSettingsConfiguration = builder.Build();
        }

        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IAppSettings, AppSettings>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env, ILoggerFactory loggerFactory,
            IAppSettings appSettings )
        {
            BuildAppSettings(env);
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(appSettings.GetHelloWorldText());
            });
        }
    }
}
