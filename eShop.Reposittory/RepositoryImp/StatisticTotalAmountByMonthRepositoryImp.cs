using eShop.Business.Interface.IDBConnector;
using eShop.Business.Interface.IRepository;
using eShop.Business.Model;

namespace eShop.Repository.RepositoryImp
{
    public class StatisticTotalAmountByMonthRepositoryImp : BaseRepositoryImp<Statistic_Total_Amount_By_Month>, IStatisticTotalAmountByMonthRepository
    {
        public StatisticTotalAmountByMonthRepositoryImp(IDBConnector iDBConnector) : base(iDBConnector)
        {
        }
    }
}
