using eShop.Business.Entity;
using eShop.Business.Interface.IDBConnector;
using eShop.Business.Interface.IRepository.IVendorRepository;

namespace eShop.Repository.RepositoryImp.VendorRepositoryImp
{
    public class VendorRepositoryImp : BaseRepositoryImp<Vendor>, IVendorRepository
    {
        public VendorRepositoryImp(IDBConnector iDBConnector) : base(iDBConnector)
        {
        }
    }
}
