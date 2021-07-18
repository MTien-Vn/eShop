using eShop.Business.Model;
using eShop.Business.ServiceRes;
using System.Threading.Tasks;

namespace eShop.Business.Interface.IService
{
    public interface IStatisticService
    {

        Task<ServiceResponse> GetTotalCostByYear(long year);

        Task<ServiceResponse> GetTotalRevenueByYear(long year);

        Task<ServiceResponse> GetTotalProfitByYear(long year);
    }
}
