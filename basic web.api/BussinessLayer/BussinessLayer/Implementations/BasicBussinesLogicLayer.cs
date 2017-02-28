using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BussinessLayer.Interfaces;
using DataAccessLayer.Models;

namespace BussinessLayer.Implementations
{
    public class BasicBussinesLogicLayer : IBasicBussinesLogicLayer
    {
        public async Task<IEnumerable<BasicTable>> Get()
        {
            //throw new System.NotImplementedException();

            var results = new List<BasicTable>
            {
                new BasicTable
                {
                    Id = Guid.NewGuid(),
                    Url = "dasdasdas"
                },
                   new BasicTable
                {
                    Id = Guid.NewGuid(),
                    Url = "dasdasdas"
                }
                   ,
                      new BasicTable
                {
                    Id = Guid.NewGuid(),
                    Url = "dasdasdas"
                }
            };
            
            return await Task.FromResult(results);
        }
    }
}
