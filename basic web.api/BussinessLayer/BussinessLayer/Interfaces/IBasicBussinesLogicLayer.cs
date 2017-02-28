using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BussinessLayer.Interfaces
{
    public interface IBasicBussinesLogicLayer
    {
        Task<IEnumerable<BasicTable>> Get();
    }
}