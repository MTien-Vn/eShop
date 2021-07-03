using eShop.Business.Utils;
using System;

namespace eShop.Business.Entity
{
    public class Discount_voucher
    {
        public string discount_voucher_id { get; set; }

        [Required("Discount voucher code", ErrorMesseger = "Discount voucher code null")]
        [CheckDup("Discount voucher code", ErrorMesseger = "Discount voucher code duplicate")]
        public string discount_voucher_code { get; set; }

        public DateTime expired_date { get; set; }

        public long min_total_amount { get; set; }

        public DateTime effective_date { get; set; }

        public int discount_rate { get; set; }

        public long max_discount { get; set; }
    }
}
