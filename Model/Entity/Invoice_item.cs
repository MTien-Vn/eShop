using NMT.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace NMT.Model.Entity
{
    public class Invoice_item
    {
        [Required("Invoice_id", ErrorMesseger = "Invoice_id not null")]
        [CheckDupPair("Invoice id", ErrorMesseger = "Invoice id is duplicate")]
        public string invoice_id { get; set; }

        [Required("Item id", ErrorMesseger = "Item_id not null")]
        [CheckDupPair("Item id", ErrorMesseger = "Item id is duplicate")]
        public string item_id { get; set; }

        public int quantity { get; set; }

        [Required("Imported price", ErrorMesseger = "Imported price not null")]
        public double imported_price { get; set; }
    }
}
