using NMT.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NMT.Model.Model
{
    /// <summary>
    /// object để hứng dữ liệu và truyền dữ liệu với client
    /// </summary>
    public class ItemModel : Item
    {
        public string category_name { get; set; }

        public string category_code { get; set; }

        public string vendor_name { get; set; }

        public string vendor_code { get; set; }
    }
}
