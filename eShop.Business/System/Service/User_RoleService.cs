using eShop.Business.Entity.System;
using eShop.Business.Interface.IRepository;
using eShop.Business.Interface.ISystem;
using eShop.Business.ServiceImp;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Business.System.Service
{
    public class User_RoleService : BaseServiceImp<User_role>, IUser_RoleService
    {
        private IUser_RoleRepository userRoleRepository;
        public User_RoleService(IUser_RoleRepository _userRoleRepository) : base(_userRoleRepository)
        {
            this.userRoleRepository = _userRoleRepository;
        }
    }
}
