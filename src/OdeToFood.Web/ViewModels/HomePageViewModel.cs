using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Web.Entities;

namespace OdeToFood.Web.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string CurrentGreeting { get; set; }
    }
}