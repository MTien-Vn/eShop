using eShop.Business.Interface.IService;
using eShop.Business.Model;
using eShop.Business.ServiceRes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sShop.Business.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserModelController : ControllerBase
    {
        IUserModelService userModelService;
        public UserModelController(IUserModelService _service)
        {
            userModelService = _service;
        }
        [HttpGet("{userName}")]
        public async Task<ServiceResponse> GetUserModel(string userName)
        {
            return await userModelService.GetUserModelByUserName(userName);
        }

        [HttpGet("{page}/{limmit}")]
        public async Task<ServiceResponse> GetUserModel(long page, long limmit)
        {
            return await userModelService.GetUerModels(limmit, page);
        }
    }
}
