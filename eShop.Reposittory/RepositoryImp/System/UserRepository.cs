using eShop.Business.Entity.System;
using eShop.Business.Interface.IDBConnector;
using eShop.Business.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Repository.RepositoryImp
{
    public class UserRepository : BaseRepositoryImp<User>, IUserRepository
    {
        public UserRepository(IDBConnector iDBConnector) : base(iDBConnector)
        {
        }
    }
}
