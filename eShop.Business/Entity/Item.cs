using eShop.Business.Utils;

namespace eShop.Business.Entity
{
    /// <summary>
    /// enttity ứng với bảng trong db
    /// </summary>
    public class Item : BaseModel
    {
        public string item_id { get; set; }

        [Required("Mã sản phẩm", ErrorMesseger = "Mã sản phẩm không được trống")]
        [CheckDup("Mã sản phẩm", ErrorMesseger = "Mã sản phẩm không được trùng")]
        public string item_code { get; set; }

        public string item_name { get; set; }

        public string unit { get; set; }

        public double imported_price { get; set; }

        public string description { get; set; }

        public string category_id { get; set; }

        public int state { get; set; }

        public double selling_price { get; set; }

        public int rate_profit { get; set; }
    }
}
