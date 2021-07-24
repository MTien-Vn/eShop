using eShop.Business.Utils;

namespace eShop.Business.Entity.System
{
    public class User_role
    {
        [Required("User_id", ErrorMesseger = "User_id không được trống")]
        public string user_id { get; set; }

        [Required("Role_id", ErrorMesseger = "Role_id không được trống")]
        public string role_id { get; set; }
    }
}
