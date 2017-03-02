using DataAccessLayer;

namespace BussinessLayer.Implementations.EntityFrameworkCore
{
    public abstract class BaseBussinesLogicLayer
    {
        protected readonly IBasicWebApi Context;

        protected BaseBussinesLogicLayer(IBasicWebApi context)
        {
            Context = context;
        }
    }
}