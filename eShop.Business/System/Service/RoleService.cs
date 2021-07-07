using eShop.Business.Entity.System;
using eShop.Business.Interface.IRepository;
using eShop.Business.Interface.IService;
using eShop.Business.ServiceImp;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Business.System.Service
{
    public class RoleService : BaseServiceImp<Role>, IRoleService
    {
        private IRoleRepository roleRepository;
        public RoleService(IRoleRepository _roleRepository) : base(_roleRepository)
        {
            roleRepository = _roleRepository;
        }
    }
}
