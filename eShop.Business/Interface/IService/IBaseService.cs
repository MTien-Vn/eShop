using eShop.Business.ServiceRes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.Business.Interface.IService
{
    public interface IBaseService<T>
    {
        #region get entity

        /// <summary>
        /// lấy bản ghi có phân trang
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limmit"></param>
        /// <param name="fieldNames"></param>
        /// <param name="values"></param>
        /// <returns>danh sách các bản ghi</returns>
        /// creadtedBy: Mạnh TIến(5/2/2020)
        Task<ServiceResponse> GetEntity(long page, long limmit, List<string> fieldNames = null, List<string> values = null);

        /// <summary>
        /// lấy thông tin đối tượng bằng id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>thông tin đối tượng</returns>
        /// creadtedBy: Mạnh TIến(5/2/2020)
        Task<ServiceResponse> GetEntityById(string id);
        #endregion

        /// <summary>
        /// Thêm một thông tin khách hàng
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>số khách hàng được thêm</returns>
        Task<ServiceResponse> InsertT(T entity);

        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Số lượng bản ghi được cập nhật</returns>
        /// /// CreadtedBy: Mạnh Tiến(25/12/2020)
        Task<ServiceResponse> UpdateT(T entity, string id);

        /// <summary>
        /// Xóa bản ghi theo trường của đối tượng
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Số lượng bản ghi được xóa</returns>
        /// /// CreadtedBy: Mạnh Tiến(25/12/2020)
        Task<ServiceResponse> DeleteT(List<string> fieldNames = null, List<string> values = null);

        /// <summary>
        /// tính số bản ghi trong database
        /// </summary>
        /// <returns>Số lượng bản ghi</returns>
        /// createdBy: Mạnh Tiến(27/12/2020)
        Task<ServiceResponse> CountEntity(List<string> fieldNames = null, List<string> values = null);

        /// <summary>
        /// lấy mã nhân viên lớn nhất
        /// </summary>
        /// <returns>mã lớn nhất</returns>
        /// createdBy: Mạnh Tiến(3/1/2020)
        Task<ServiceResponse> GetEntityCodeMax();
    }
}
