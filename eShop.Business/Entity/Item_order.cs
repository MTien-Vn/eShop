using eShop.Business.Utils;

namespace eShop.Business.Entity
{
    public class Item_order
    {
        [Required("Order_id", ErrorMesseger = "Order_id not null")]
        [CheckDupPair("Order id", ErrorMesseger = "Order id is duplicate")]
        public string order_id { get; set; }

        [Required("Invoice_id", ErrorMesseger = "Invoice_id not null")]
        [CheckDupPair("item id", ErrorMesseger = "item id is duplicate")]
        public string item_id { get; set; }

        public int quantity { get; set; }
    }
}
