using eShop.Business.Model;
using System.Data;

namespace eShop.Business.Interface.IRepository
{
    public interface IStatisticRepository
    {
        IDbConnection GetDBConnection();
    }
}
