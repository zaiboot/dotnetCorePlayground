using System;
using System.Collections.Generic;
using System.Linq;
using OdeToFood.Web.Entities;

namespace OdeToFood.Web.Services
{
    public class RestaurantServiceInMemory : IRestaurantService
    {
        private IEnumerable<Restaurant> _restaurants;

        public RestaurantServiceInMemory()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "Matsuri"},
                new Restaurant { Id = 2, Name = "Don Fernando"}

            };

        }
        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }
    }
}