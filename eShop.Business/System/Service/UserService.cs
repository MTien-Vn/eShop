using eShop.Business.Entity.System;
using eShop.Business.Interface.ISystem;
using eShop.Business.System.UsersRequest;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace eShop.Business.System.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public Task<string> Authencate(LoginRequest request)
        {
            
        }

        public Task<bool> Register(RegisterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
