using eShop.Business.Entity.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Business.Model
{
    public class RegisterModel
    {
        public User user { get; set; }

        public string RoleId { get; set; }
    }
}
