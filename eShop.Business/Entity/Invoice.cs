using eShop.Business.Utils;
using System;

namespace eShop.Business.Entity
{
    public class Invoice
    {
        public string invoice_id { get; set; }

        [Required("invoice code", ErrorMesseger = "invoice code not null")]
        [CheckDup("invoice code", ErrorMesseger = "invoice code duplicate")]
        public string invoice_code { get; set; }

        [Required("Employee code", ErrorMesseger = "Employee code not null")]
        public string employee_id { get; set; }

        [Required("Vendor_id", ErrorMesseger = "Vendor_id not null")]
        public string vendor_id { get; set; }

        public DateTime date { get; set; }

        public long amount { get; set; }
    }
}
