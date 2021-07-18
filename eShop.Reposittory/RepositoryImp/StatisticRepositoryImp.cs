using eShop.Business.Interface.IDBConnector;
using eShop.Business.Interface.IRepository;
using eShop.Business.Model;
using System.Data;

namespace eShop.Repository.RepositoryImp
{
    public class StatisticRepositoryImp : IStatisticRepository
    {
        private readonly IDBConnector iDBConnector;
        public StatisticRepositoryImp(IDBConnector _iDBConnector)
        {
            this.iDBConnector = _iDBConnector;
        }

        public IDbConnection GetDBConnection()
        {
            return this.iDBConnector.GetDBConnection();
        }
    }
}
