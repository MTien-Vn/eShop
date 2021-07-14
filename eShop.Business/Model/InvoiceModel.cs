using eShop.Business.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Business.Model
{
    public class InvoiceModel : Invoice
    {
        public string employee_code { get; set; }
        public string employee_name { get; set; }
        public string vendor_code { get; set; }
        public string vendor_name { get; set; }
        public float tax { get; set; }
        public float total_amount { get; set; }
        public DateTime date_imported { get; set; }

    }
}
