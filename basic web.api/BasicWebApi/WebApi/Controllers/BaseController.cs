using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class BaseController: Controller
    {
        protected readonly IMapper Mapper;

       

        public BaseController(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}