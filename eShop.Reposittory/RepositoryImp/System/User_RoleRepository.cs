using eShop.Business.Entity.System;
using eShop.Business.Interface.IDBConnector;
using eShop.Business.Interface.ISystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Repository.RepositoryImp.System
{
    public class User_RoleRepository : BaseRepositoryImp<User_role>, IUser_RoleRepository
    {
        public User_RoleRepository(IDBConnector iDBConnector) : base(iDBConnector)
        {
        }
    }
}
