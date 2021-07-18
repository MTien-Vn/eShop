using eShop.Business.Interface.IService;
using eShop.Business.Model;
using eShop.Business.ServiceRes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sShop.Business.Enum;
using System;
using System.Threading.Tasks;

namespace MISA_AMIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StatisticController : ControllerBase
    {
        IStatisticService statisticService;
        public StatisticController(IStatisticService _service)
        {
            statisticService = _service;
        }
        [HttpGet("{param}")]
        public async Task<ServiceResponse> GetStatisticCostRevenueProfitByYear(long param)
        {
            ServiceResponse sr = new ServiceResponse();
            StatisticProfitRevenueCostModel model = new StatisticProfitRevenueCostModel();
            var n = 
            model.cost = Convert.ToDouble((await statisticService.GetTotalCostByYear(param)).Data);
            model.profit = Convert.ToDouble((await statisticService.GetTotalProfitByYear(param)).Data);
            model.revenue = Convert.ToDouble((await statisticService.GetTotalRevenueByYear(param)).Data);

            sr.Data = model;
            sr.MisaCode = MyEnum.Scuccess;

            return sr;
        }
    }
}
