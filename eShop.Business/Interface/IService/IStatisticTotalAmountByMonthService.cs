using eShop.Business.Model;
using eShop.Business.ServiceRes;
using System.Threading.Tasks;

namespace eShop.Business.Interface.IService
{
    public interface IStatisticTotalAmountByMonthService : IBaseService<Statistic_Total_Amount_By_Month>
    {
        Task<ServiceResponse> getData(int param);
    }
}
