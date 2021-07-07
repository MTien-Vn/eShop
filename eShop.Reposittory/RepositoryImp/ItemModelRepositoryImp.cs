using eShop.Business.Entity;
using eShop.Business.Interface.IDBConnector;
using eShop.Business.Interface.IRepository;

namespace eShop.Repository.RepositoryImp
{
    public class ItemModelRepositoryImp : BaseRepositoryImp<Item>, IItemModelRepository
    {
        public ItemModelRepositoryImp(IDBConnector iDBConnector) : base(iDBConnector)
        {
        }
    }
}
