using Dapper;
using eShop.Business.Interface.IRepository;
using eShop.Business.Interface.IService;
using eShop.Business.Model;
using eShop.Business.Properties;
using eShop.Business.ServiceImp;
using eShop.Business.ServiceRes;
using sShop.Business.Enum;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Misa.BL.ServiceImp
{
    public class StatisticServiceImp : IStatisticService
    {
        IStatisticRepository statisticRepository;
        public StatisticServiceImp(IStatisticRepository _repository)
        {
            this.statisticRepository = _repository;
        }

        public async Task<ServiceResponse> GetTotalCostByYear(long year)
        {
            var storeName = $"func_get_statistic_total_cost_by_year";
            return await this.GetDataByProce(year, storeName);
        }

        public async Task<ServiceResponse> GetTotalProfitByYear(long year)
        {
            var storeName = $"func_get_statistic_total_profit_by_year";
            return await this.GetDataByProce(year, storeName);
        }

        public async Task<ServiceResponse> GetTotalRevenueByYear(long year)
        {
            var storeName = $"func_get_statistic_total_revenue_by_year";
            return await this.GetDataByProce(year, storeName);
        }

        private async Task<ServiceResponse> GetDataByProce(long param, string storeName)
        {
            ServiceResponse sr = new ServiceResponse();
            
            var dbConnection = statisticRepository.GetDBConnection();
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@year_in", param);
            var result = await dbConnection.ExecuteScalarAsync(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);

            sr.MisaCode = MyEnum.Scuccess;
            sr.Messenger.Add(Resources.Success);
            sr.Data = result;
            return sr;
        }
    }
}
