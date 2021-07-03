using eShop.Business.Utils;

namespace eShop.Business.Entity
{
    public class Customer
    {
        public string customer_id { get; set; }

        public string customer_name { get; set; }

        [Required("Customer id", ErrorMesseger = "Customer id null")]
        [CheckDup("Customer code", ErrorMesseger = "Customer code duplicate")]
        public string customer_code { get; set; }

        public int dob { get; set; }

        public int cumulative_point { get; set; }

        public string email { get; set; }

        [Required("Phone", ErrorMesseger = "phone null")]
        [CheckDup("Phone", ErrorMesseger = "Phone already exists")]
        public string phone { get; set; }

        public string address { get; set; }

        [Required("state", ErrorMesseger = "Customer state id null")]
        public int state { get; set; }
    }
}
