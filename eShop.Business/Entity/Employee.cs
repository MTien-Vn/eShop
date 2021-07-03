using eShop.Business.Utils;
using System;

namespace eShop.Business.Entity
{
    /// <summary>
    /// enttity ứng với bảng trong db
    /// </summary>
    public class Employee : BaseModel
    {
        public string employee_id { get; set; }

        [Required("Mã nhân viên", ErrorMesseger = "Mã nhân viên không được trống")]
        [CheckDup("MÃ nhân viên", ErrorMesseger = "Mã nhân viên không được trùng")]
        public string employee_code { get; set; }

        public string employee_name { get; set; }

        public DateTime dob { get; set; }

        public string address { get; set; }

        [Required("Số điện thoại", ErrorMesseger = "Số điện thoại không được trống")]
        [CheckDup("Số điện thoại", ErrorMesseger = "Số điện thoại không được trùng")]
        public string phone_number { get; set; }

        public string email { get; set; }

        public int gender { get; set; }

        /// <summary>
        /// số CMT/CCCD
        /// </summary>
        [Required("số CMT/CCCD", ErrorMesseger = "số CMT/CCCD không được trống")]
        [CheckDup("số CMT/CCCD", ErrorMesseger = "số CMT/CCCD không được trùng")]
        public string identify_number { get; set; }

        public string group_id { get; set; }

        /// <summary>
        /// ca làm việc
        /// </summary>
        public int shift { get; set; }

        public string pass_word { get; set; }

        /// <summary>
        /// ngay thu viec
        /// </summary>
        public DateTime join_date { get; set; }

        public int status { get; set; }
    }
}
