using eShop.Business.Model;
using eShop.Business.ServiceRes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Business.Interface.IService
{
    public interface IUserModelService
    {
        Task<ServiceResponse> GetUserModel(string userName);
    }
}
