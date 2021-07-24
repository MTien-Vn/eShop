using eShop.Business.Entity;
using eShop.Business.Interface.IService;
using eShop.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseEntityController<Employee>
    {
        public EmployeeController(IBaseService<Employee> _baseService) : base(_baseService)
        {
        }
    }
}
