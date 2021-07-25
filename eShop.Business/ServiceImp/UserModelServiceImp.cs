using Dapper;
using eShop.Business.Interface.IRepository;
using eShop.Business.Interface.IService;
using eShop.Business.Model;
using eShop.Business.Properties;
using eShop.Business.ServiceRes;
using sShop.Business.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Business.ServiceImp
{
    public class UserModelServiceImp : IUserModelService
    {
        private readonly IUserModelRepository userModelRepo;
        public UserModelServiceImp(IUserModelRepository _repo)
        {
            this.userModelRepo = _repo;
        }

        public async Task<ServiceResponse> GetUerModels(long limmit, long page)
        {
            using var dbConnection = userModelRepo.GetDBConnection();
            dbConnection.Open();
            using var transaction = dbConnection.BeginTransaction();
            ServiceResponse sr = new ServiceResponse();
            try
            {
                long offSet;
                if (page == 1)
                {
                    offSet = 0;
                }
                else
                {
                    offSet = (page - 1) * limmit - 1;
                }
                string storeName = "func_get_user_model";

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@off_set", offSet);
                dynamicParameters.Add("@limmit", limmit);
                var result = await dbConnection.QueryAsync(storeName, dynamicParameters, commandType: CommandType.StoredProcedure, transaction: transaction);

                string storeNameCount = "func_count_user_model";
                var total_number = await dbConnection.ExecuteScalarAsync(storeNameCount, commandType: CommandType.StoredProcedure, transaction: transaction);

                var dic = new Dictionary<string, object>
                {
                    { "items", result },
                    { "total_record", total_number }
                };

                sr.MisaCode = MyEnum.Scuccess;
                sr.Messenger.Add(Resources.Success);
                sr.Data = dic;
                transaction.Commit();
                return sr;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine(ex);
                sr.MisaCode = MyEnum.False;
                sr.Messenger.Add(Resources.False);
                return sr;
            }
            
        }

        public async Task<ServiceResponse> GetUserModelByUserName(string userName)
        {
            using var dbConnection = userModelRepo.GetDBConnection();
            dbConnection.Open();
            using var transaction = dbConnection.BeginTransaction();
            ServiceResponse sr = new ServiceResponse();
            try
            {
                string storeName = "func_get_user_model_by_user_name";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@user_name_in", userName);
                var result = await dbConnection.QueryAsync(storeName, dynamicParameters, commandType: CommandType.StoredProcedure, transaction: transaction);

                sr.MisaCode = MyEnum.Scuccess;
                sr.Messenger.Add(Resources.Success);
                sr.Data = result;
                transaction.Commit();
                return sr;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine(ex);
                sr.MisaCode = MyEnum.False;
                sr.Messenger.Add(Resources.False);
                return sr;
            }
            
        }
    }
}
