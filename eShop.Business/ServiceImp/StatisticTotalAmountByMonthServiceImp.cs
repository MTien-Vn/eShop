using Dapper;
using eShop.Business.Interface.IRepository;
using eShop.Business.Interface.IService;
using eShop.Business.Model;
using eShop.Business.Properties;
using eShop.Business.ServiceImp;
using eShop.Business.ServiceRes;
using sShop.Business.Enum;
using System.Data;
using System.Threading.Tasks;

namespace Misa.BL.ServiceImp
{
    public class StatisticTotalAmountByMonthServiceImp : BaseServiceImp<Statistic_Total_Amount_By_Month>, IStatisticTotalAmountByMonthService
    {
        IStatisticTotalAmountByMonthRepository statisticTotalAmountByMonthRepository;
        public StatisticTotalAmountByMonthServiceImp(IStatisticTotalAmountByMonthRepository _repository) : base(_repository)
        {
            statisticTotalAmountByMonthRepository = _repository;
        }

        public async Task<ServiceResponse> getData(int param)
        {
            ServiceResponse sr = new ServiceResponse();
            var dbConnection =  statisticTotalAmountByMonthRepository.GetDBConnection();

            var storeName = $"func_get_statistic_total_amount_by_month";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@year_in", param);
            var entities = await dbConnection.QueryAsync<Statistic_Total_Amount_By_Month>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            if(entities != null)
            {
                sr.MisaCode = MyEnum.Scuccess;
                sr.Messenger.Add(Resources.Success);
                sr.Data = entities;
            }
            else
            {
                sr.MisaCode = MyEnum.False;
                sr.Messenger.Add(Resources.False);
            }
            return sr;
        }
    }
}
