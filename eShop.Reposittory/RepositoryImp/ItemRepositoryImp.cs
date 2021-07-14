using eShop.Business.Interface.IDBConnector;
using eShop.Business.Interface.IRepository;
using eShop.Business.Model;

namespace eShop.Repository.RepositoryImp
{
    public class ItemRepositoryImp : BaseRepositoryImp<ItemModel>, IItemRepository
    {
        public ItemRepositoryImp(IDBConnector iDBConnector) : base(iDBConnector)
        {
        }
    }
}
