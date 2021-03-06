using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace eShop.Business.Interface.IRepository
{
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// lấy db connection
        /// </summary>
        /// <returns>DBConnection</returns>
        /// createdBy:Manh Tien(8/2/2021)
        IDbConnection GetDBConnection();

        #region get entity
        /// <summary>
        /// lấy bản ghi bằng sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>Danh sách các bản ghi</returns>
        /// CreadtedBy: Mạnh Tiến(25/12/2020)
        Task<IEnumerable<T>> GEtDataBySQL(string sql);

        /// <summary>
        /// lấy danh sách bản ghi theo fielName(option)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="page"></param>
        /// <param name="limmit"></param>
        /// <param name="fieldNames"></param>
        /// <param name="values"></param>
        /// <returns>danh sách các bản ghi</returns>
        /// createdBy: Manh Tien (5/2/2021)
        Task<IEnumerable<T>> GetData(long page, long limmit, List<string> fieldNames = null, List<string> values = null);
        #endregion

        /// <summary>
        /// Thêm 1 bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Đối tượng quản lý dữ liệu sau khi thao tác Db</returns>
        /// CreadtedBy: Mạnh Tiến(25/12/2020)
        Task<T> InsertEntity(T entity);

        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Số lượng bản ghi được cập nhật</returns>
        /// CreadtedBy: Mạnh Tiến(25/12/2020)
        Task<T> UpdateEntity(T entity);

        //// <summary>
        /// xóa bản ghi theo trường (option) của đối tượng, không truyền sẽ xóa theo mã đối tượng
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fieldNames"></param>
        /// <param name="values"></param>
        /// <returns>số bản ghi bị xóa</returns>
        /// createdBy: Mạnh Tiến(26/12/2020)
        Task<int> DeleteEntity(List<string> fieldNames = null, List<string> values = null);

        /// <summary>
        /// tính tổng số bản ghi
        /// </summary>
        /// <returns>số lượng bản ghi</returns>
        /// CreadtedBy: Mạnh Tiến(5/2/2020)
        Task<long> CountEntity(List<string> fieldNames = null, List<string> values = null);

        /// <summary>
        /// lấy mã nhân viên lớn nhất
        /// </summary>
        /// <returns>mã lớn nhất</returns>
        /// createdBy: Mạnh Tiến(3/1/2020)
        Task<string> GetEntityCodeMax();
    }
}
