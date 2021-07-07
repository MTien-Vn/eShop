using eShop.Business.Entity;

namespace eShop.Business.Model
{
    /// <summary>
    /// object để hứng dữ liệu và truyền dữ liệu với client
    /// </summary>
    public class ItemModel : Item
    {
        public string category_name { get; set; }

        public string category_code { get; set; }

        public string vendor_name { get; set; }

        public string vendor_code { get; set; }
    }
}
