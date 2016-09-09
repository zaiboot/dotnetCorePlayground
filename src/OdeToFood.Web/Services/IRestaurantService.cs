using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Web.Entities;

namespace OdeToFood.Web.Services
{
    public interface IRestaurantService
    {
        IEnumerable<Restaurant> GetAll();

        Restaurant Get(int id);
    }
}
