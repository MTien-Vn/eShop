using eShop.Business.Utils;

namespace eShop.Business.Entity
{
    /// <summary>
    /// enttity ứng với bảng trong db
    /// </summary>
    public class Vendor : BaseModel
    {
        public string vendor_id { get; set; }

        [Required("Mã nhà cung cấp", ErrorMesseger ="Mã nhà cung cấp không được trống")]
        [CheckDup("Mã nhà cung cấp", ErrorMesseger = "Mã nhà cung cấp không được trùng")]
        public string vendor_code { get; set; }

        public string vendor_name { get; set; }

        public string address { get; set; }

        [Required("Số điện thoại", ErrorMesseger = "Số điện thoại không được trống")]
        [CheckDup("Số điện thoại", ErrorMesseger = "Số điện thoại không được trùng")]
        public string phone_number { get; set; }

        public string email { get; set; }

        public string tax_number { get; set; }

        [Required("Trạng thái", ErrorMesseger = "Trạng thái không được trống")]
        public int state { get; set; }
    }
}
