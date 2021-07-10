using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Business.System.UserResponse
{
    public class LoginResponse
    {
        public string token { get; set; }

        public string[] roles { get; set; }
    }
}
