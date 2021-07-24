using eShop.Business.Entity.System;
using eShop.Business.Interface.IService;
using eShop.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : BaseEntityController<Role>
    {
        public RoleController(IBaseService<Role> _baseService) : base(_baseService)
        {
        }
    }
}
