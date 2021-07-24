using eShop.Business.Entity.System;
using eShop.Business.Interface.IRepository;
using eShop.Business.Interface.ISystem;
using eShop.Business.ServiceImp;
using eShop.Business.ServiceRes;
using eShop.Business.System.UsersRequest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sShop.Business.Enum;
using eShop.Business.Properties;
using Dapper;
using System.Data;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Collections;
using eShop.Business.System.UserResponse;
using eShop.Business.Model;
using eShop.Business.ValidateData;

namespace eShop.Business.System.Service
{
    public class UserService : BaseServiceImp<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUser_RoleService _userRoleService;
        private readonly IConfiguration _config;

        public UserService(IUser_RoleService userRoleService, IUserRepository userRepository, IConfiguration config) : base(userRepository)
        {
            _userRepository = userRepository;
            _userRoleService = userRoleService;
            _config = config;
        }
        public async Task<ServiceResponse> Authencate(LoginRequest request)
        {
            var sr = new ServiceResponse();
            var user = await this.GetUserByUserName(request.user_name);
            if (user == null)
            {
                sr.MisaCode = MyEnum.False;
                sr.Messenger.Add(Resources.Authen_false);
                return sr;
            }
            var result = await this.SignInUser(request.user_name, request.pass_word);
            if(result == null)
            {
                sr.MisaCode = MyEnum.False;
                sr.Messenger.Add(Resources.SignIn_false);
                return sr;
            }

            var roles = await this.GetRoles(request.user_name);
            string[] arrRoles = new string[roles.Count()];
            int index = 0;
            foreach (var role in roles)
            {
                arrRoles[index] = role.role_name;
                index++;
            }
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.user_name),
                new Claim(ClaimTypes.Role, string.Join(";", arrRoles))
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            var data = new JwtSecurityTokenHandler().WriteToken(token);

            var loginResponse = new LoginResponse();
            loginResponse.token = data;
            loginResponse.roles = arrRoles;
            loginResponse.userName = result.user_name;

            sr.MisaCode = MyEnum.Scuccess;
            sr.Messenger.Add(Resources.signIn_sucess);
            sr.Data = loginResponse;
            return sr;
        }

        public async Task<ServiceResponse> Register(User user)
        {
            return await this.InsertT(user);
        }

        public async Task<User> GetUserByUserName(string name_key)
        {
            var dbConnection = _userRepository.GetDBConnection();

            var storeName = $"func_get_user_by_user_name";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@_user_name", name_key);

            var entities = await dbConnection.QueryAsync<User>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return entities.FirstOrDefault();
        }

        public async Task<User> SignInUser(string name_key, string pass_word)
        {
            var dbConnection = _userRepository.GetDBConnection();

            var storeName = $"func_get_user_by_user_name_pass_word";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@_user_name", name_key);

            dynamicParameters.Add("@_pass_word", pass_word);

            var entities = await dbConnection.QueryAsync<User>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return entities.FirstOrDefault();
        }

        public async Task<List<Role>> GetRoles(string name_key)
        {
            var dbConnection = _userRepository.GetDBConnection();

            var storeName = $"func_get_role_by_user_name";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@_user_name", name_key);

            var entities = await dbConnection.QueryAsync<Role>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return (List<Role>)entities;
        }

        public async Task<ServiceResponse> CreateUser(RegisterModel registerModel)
        {
            ServiceResponse sr = new ServiceResponse();
            if (string.IsNullOrEmpty(registerModel.RoleId))
            {
                sr.MisaCode = MyEnum.False;
                sr.Messenger.Add(Resources.Error_Role_id_not_null);
                return sr;
            }
            var resultInsertUser = await this.InsertT(registerModel.user);
            if(resultInsertUser.MisaCode == MyEnum.Scuccess)
            {
                var user_role = new User_role();
                user_role.user_id = (resultInsertUser.Data as User).user_id;
                user_role.role_id = registerModel.RoleId;
                
                var resultInsertUserRole = await _userRoleService.InsertT(user_role);
                if(resultInsertUserRole.MisaCode == MyEnum.Scuccess)
                {
                    sr.MisaCode = MyEnum.Scuccess;
                    sr.Messenger.Add(Resources.Success);
                    sr.Data = resultInsertUser.Data;
                }
                else
                {
                    List<string> fieldName = new List<string>();
                    List<string> values = new List<string>();
                    fieldName.Add("user_name");
                    values.Add(registerModel.user.user_name);
                    await this.DeleteT(fieldName, values);

                    sr.MisaCode = MyEnum.False;
                    sr.Messenger.Add(Resources.Error_Insert_User_Role);
                }
            }
            else
            {
                sr.MisaCode = MyEnum.False;
                sr.Messenger.Add(resultInsertUser.Messenger.FirstOrDefault());
            }
            return sr;
        }
    }
}
