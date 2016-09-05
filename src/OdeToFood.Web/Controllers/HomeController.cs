using OdeToFood.Web.Services;

namespace OdeToFood.Web.Controllers
{
    internal class HomeController
    {
        private readonly IAppSettings _appSettings;

        public HomeController(IAppSettings appSettings)
        {
            _appSettings = appSettings;
        }
        public string Index()
        {
            return _appSettings.GetHelloWorldFromController();
        }
    }
}
