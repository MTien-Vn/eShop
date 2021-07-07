using eShop.Business.Entity.System;
using eShop.Business.Interface.IDBConnector;
using eShop.Business.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Repository.RepositoryImp
{
    public class RoleRepository : BaseRepositoryImp<Role>, IRoleRepository
    {
        public RoleRepository(IDBConnector iDBConnector) : base(iDBConnector)
        {
        }
    }
}
