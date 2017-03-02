using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BussinessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Models;

namespace BussinessLayer.Implementations
{
    public class BasicBussinesLogicLayer : IBasicBussinesLogicLayer
    {
        private readonly IBasicWebApi _context;

        public BasicBussinesLogicLayer(IBasicWebApi context )
        {
            _context = context;
        }
        public async Task<IEnumerable<BasicTable>> Get()
        {
            //throw new System.NotImplementedException();

            //var results = new List<BasicTable>
            //{
            //    new BasicTable
            //    {
            //        Id = Guid.NewGuid(),
            //        Url = "dasdasdas"
            //    },
            //       new BasicTable
            //    {
            //        Id = Guid.NewGuid(),
            //        Url = "dasdasdas"
            //    }
            //       ,
            //          new BasicTable
            //    {
            //        Id = Guid.NewGuid(),
            //        Url = "dasdasdas"
            //    }
            //};
            
            return await Task.FromResult(_context.Blogs);
        }
    }
}
