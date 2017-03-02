using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BussinessLayer.Implementations.EntityFrameworkCore
{
    public class BasicBussinesLogicLayer : BaseBussinesLogicLayer, IBasicBussinesLogicLayer
    {
        public BasicBussinesLogicLayer(IBasicWebApi context ): base(context)
        {

        }

        public async Task<IEnumerable<BasicTable>> Get()
        {
            var blogs = await (from b in Context.Blogs
                               orderby b.Url
                               select b).ToListAsync();
            return blogs;
        }
    }
}
