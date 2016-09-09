using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Web.Entities;
using OdeToFood.Web.Services;
using OdeToFood.Web.ViewModels;

namespace OdeToFood.Web.Controllers
{
    public class HomeController:  Controller
    {
        private readonly IAppSettings _appSettings;
        private readonly IRestaurantService _restaurantService;

        private ObjectResult RenderObjectResult(object obj)
        {
            return new ObjectResult(obj);
        }

        public HomeController(IAppSettings appSettings, IRestaurantService restaurantService)
        {
            _appSettings = appSettings;
            _restaurantService = restaurantService;
        }
        public IActionResult Index()
        {
            
            return Content( _appSettings.GetHelloWorldFromController());
        }

        public ObjectResult Restaurants()
        {
          
            var homePageViewModel = new HomePageViewModel
            {
                Restaurants =  _restaurantService.GetAll(),
                CurrentGreeting = _appSettings.GetHelloWorldFromController()
                
            };

            return RenderObjectResult(homePageViewModel);
        }

        public IActionResult Details(int id)
        {
            var restaurant = _restaurantService.Get(id);
            if (restaurant ==null)
            {
                //return Redirect("~/hello");
                return RedirectToAction("Index");
            }
            
            return RenderObjectResult(restaurant);
            
            
        }
    }
}
