using eShop.Business.Utils;

namespace eShop.Business.Entity.System
{
    public class User
    {
        public string user_id { get; set; }


        [Required("User_name", ErrorMesseger = "User_name không được trống")]
        [CheckDup("User_name", ErrorMesseger = "User_name không được trùng")]
        [CheckSys("system", ErrorMesseger = " ")]
        public string user_name { get; set; }


        [Required("pass_word", ErrorMesseger = "pass_word không được trống")]
        public string pass_word { get; set; }

        [CheckDup("Employee_id", ErrorMesseger = "Employee_id không được trùng")]
        [CheckSys("system", ErrorMesseger = " ")]
        public string employee_id { get; set; }
    }
}
