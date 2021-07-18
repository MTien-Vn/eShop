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
        public async Task<ServiceResponse> GetStatisticCostRevenueProfitByYear(string userName)
        {
            ServiceResponse sr = new ServiceResponse();
            var model = await userModelService.GetUserModel(userName);
            sr.Data = model;
            sr.MisaCode = MyEnum.Scuccess;

            return sr;
        }
    }
}
