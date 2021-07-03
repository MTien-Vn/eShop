using eShop.Business.ServiceRes;
using NMT.Model.Model;

namespace eShop.Business.Interface.IService
{
    public interface IStatisticTotalAmountByMonthService : IBaseService<Statistic_Total_Amount_By_Month>
    {
        ServiceResponse getData(int param);
    }
}
