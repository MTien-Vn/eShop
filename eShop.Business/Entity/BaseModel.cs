using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Business.Entity
{
    public class BaseModel
    {
        /// <summary>
        /// người tạo
        /// </summary>
        public string created_by { get; set; }

        /// <summary>
        /// ngày tạo
        /// </summary>
        public DateTime created_date { get; set; }

        /// <summary>
        /// người sửa
        /// </summary>
        public string modified_by { get; set; }

        /// <summary>
        /// ngày sửa
        /// </summary>
        public DateTime modified_date { get; set; }
    }
}
