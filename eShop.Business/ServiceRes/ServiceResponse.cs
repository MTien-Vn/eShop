using sShop.Business.Enum;
using System.Collections.Generic;

namespace eShop.Business.ServiceRes
{
    /// <summary>
    /// đối tượng quản lý dữ liệu trả về sau khi thao tác db
    /// </summary>
    public class ServiceResponse
    {
        public object Data { get; set; }

        /// <summary>
        /// Danh sách thông báo trả về
        /// </summary>
        public List<string> Messenger { get; set; } = new List<string>();

        /// <summary>
        /// mã thông báo lỗi
        /// </summary>
        public MyEnum MisaCode { get; set; }
    }
}
