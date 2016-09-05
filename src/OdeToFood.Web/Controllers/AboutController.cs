using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Web.Controllers
{
    [Route("info/[controller]")] //uses the name of the class, in case we change this to nskfdnlfsController
    public class AboutController
    {
        [Route("")]
        public string Country()
        {
            return "CRC";
        }

        [Route("[action]")]
        public string Phone()
        {
            return "+506 667 66666";
        }
    }
}
