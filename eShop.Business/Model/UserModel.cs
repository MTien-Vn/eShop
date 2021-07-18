using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Business.Model
{
    public class UserModel
    {
        public string code { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string identifyNumber { get; set; }
        public int shift { get; set; }
        public DateTime joinDate { get; set; }
        public string groupName { get; set; }
        public double baseSalary { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
