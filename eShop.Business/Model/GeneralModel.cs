using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Business.Model
{
    public class GeneralModel<T>
    {
        public List<T> items { get; set; }

        public long total_record { get; set; }
    }
}
