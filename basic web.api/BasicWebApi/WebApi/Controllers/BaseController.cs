using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    public class BaseController: Controller
    {
        protected readonly IMapper Mapper;

        public BaseController(IMapper mapper, ILogger<BaseController> logger)
        {
            Mapper = mapper;
        }
    }
}