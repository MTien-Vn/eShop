using eShop.Business.Utils;

namespace eShop.Business.Entity
{
    public class Category
    {
        public string category_id { get; set; }

        [Required("category_name", ErrorMesseger = "Category name not null")]
        public string category_name { get; set; }

        [Required("Category code", ErrorMesseger = "Category code not null")]
        [CheckDup("Category code", ErrorMesseger = "Category code duplicate")]
        public string category_code  { get; set; }

        public string description { get; set; }

    }
}
