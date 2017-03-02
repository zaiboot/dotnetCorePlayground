using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BussinessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class BasicController : BaseController
    {
        private readonly IBasicBussinesLogicLayer _bll;

        public BasicController(IBasicBussinesLogicLayer bll , IMapper mapper, ILogger<BasicController> logger) : base(mapper, logger)
        {
            _bll = bll;
        }
        
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<BasicTableViewModel>> Get()
        {
            IEnumerable<BasicTable>  records =  await _bll.Get();
            return Mapper.Map<IEnumerable<BasicTableViewModel>>(records);

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
