using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Business.System.UsersRequest
{
    public class LoginRequest
    {
        public string user_name { get; set; }

        public string pass_word { get; set; }

        public bool remember_me { get; set; }
    }
}
