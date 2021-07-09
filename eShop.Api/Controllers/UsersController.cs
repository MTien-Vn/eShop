using eShop.Business.Interface.ISystem;
using eShop.Business.System.UsersRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using sShop.Business.Enum;
using eShop.Business.ServiceRes;
using eShop.Business.Entity.System;

namespace eShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<ServiceResponse> Authenticate([FromBody] LoginRequest request)
        {
            return await _userService.Authencate(request);
            
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ServiceResponse> Register([FromBody] User request)
        {
            return await _userService.Register(request);

        }
    }
}
