using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace OdeToFood.Web.Services
{
    public class AppSettings : IAppSettings
    {
        private readonly string _helloWorldText;
        private readonly string _helloWorldFromController;

        public AppSettings(IHostingEnvironment env)
        {

            var path = Path.Combine(
               env.ContentRootPath,
               @"configs", //to avoid directory separator.
               "appsettings.json");
            var builder = new ConfigurationBuilder()
                .AddJsonFile(path);

            var configuration = builder.Build();
            _helloWorldText = configuration["hello-world-text"];
            _helloWorldFromController = configuration["hello-world-from-controller"];
        }
        public string GetHelloWorldText()
        {
            return _helloWorldText;
        }

        public string GetHelloWorldFromController()
        {

            return _helloWorldFromController;
        }
    }
}