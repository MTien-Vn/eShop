using eShop.Business.Interface.IService;
using eShop.Business.ServiceRes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MISA_AMIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticTotalAmountByMonthController : ControllerBase
    {
        IStatisticTotalAmountByMonthService statisticTotalAmountByMonthService;
        public StatisticTotalAmountByMonthController(IStatisticTotalAmountByMonthService _service)
        {
            statisticTotalAmountByMonthService = _service;
        }
        [HttpGet("{param}")]
        public async Task<ServiceResponse> GetStatisticTotalAmountByMonth(int param)
        {
            return await statisticTotalAmountByMonthService.getData(param);
        }
    }
}
