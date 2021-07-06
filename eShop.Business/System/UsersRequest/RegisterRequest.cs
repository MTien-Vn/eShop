using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Business.System.UsersRequest
{
    public class RegisterRequest
    {
        public string name { get; set; }

        public string address { get; set; }

        public string user_name { get; set; }

        public string password { get; set; }

        public string email { get; set; }

        public string phone { get; set; }
    }
}
