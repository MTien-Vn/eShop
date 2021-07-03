using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Business.Entity
{
    public class Order
    {
        public string order_id { get; set; }

        public DateTime date { get; set; }

        public int culmulative_point { get; set; }

        public string employee_id { get; set; }

        public string customer_id { get; set; }

        public string discount_voucher_id { get; set; }

        public long amount { get; set; }

        public long  discount_voucehr_amount { get; set; }
    }
}
