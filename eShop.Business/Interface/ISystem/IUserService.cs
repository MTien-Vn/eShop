using eShop.Business.System.UsersRequest;
using System.Threading.Tasks;

namespace eShop.Business.Interface.ISystem
{
    public interface IUserService
    {
        Task<string> Authencate(LoginRequest request);

        Task<bool> Register(RegisterRequest request);
    }
}
