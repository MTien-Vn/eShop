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
        public async Task<ServiceResponse> GetUserModel(string userName)
        {
            ServiceResponse sr = new ServiceResponse();
            string storeName = "func_get_user_model";
            var dbConnection = userModelRepo.GetDBConnection();
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@user_name_in", userName);
            var result = await dbConnection.QueryAsync(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);

            sr.MisaCode = MyEnum.Scuccess;
            sr.Messenger.Add(Resources.Success);
            sr.Data = result;
            return sr;
        }
    }
}
