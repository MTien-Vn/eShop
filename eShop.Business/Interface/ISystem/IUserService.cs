using eShop.Business.Entity.System;
using eShop.Business.Interface.IService;
using eShop.Business.ServiceRes;
using eShop.Business.System.UsersRequest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.Business.Interface.ISystem
{
    public interface IUserService : IBaseService<User>
    {
        Task<ServiceResponse> Authencate(LoginRequest request);

        Task<ServiceResponse> Register(User request);

        Task<User> GetUserByUserName(string name_key);

        Task<User> SignInUser(string name_key, string pass_word);

        Task<List<Role>> GetRoles(string name_key);  
    }
}
