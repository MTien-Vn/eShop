using Dapper;
using eShop.Business.Interface.IDBConnector;
using eShop.Business.Interface.IRepository;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace eShop.Repository.RepositoryImp
{
    public class BaseRepositoryImp<T> : IBaseRepository<T>
    {
        IDBConnector _iDbConnector;
        public BaseRepositoryImp(IDBConnector iDBConnector)
        {
            _iDbConnector = iDBConnector;
        }

        public async Task<IEnumerable<T>> GEtDataBySQL(string sql)
        {
            return await _iDbConnector.GetData<T>(sql);
        }

        public virtual async Task<IEnumerable<T>> GetData(long page, long limmit, List<string> fieldNames = null, List<string> values = null)
        {
            return await _iDbConnector.GetData<T>(page, limmit, fieldNames, values);
        }

        public async Task<T> InsertEntity(T entity)
        {
            return await _iDbConnector.Insert<T>(entity);
        }

        public async Task<T> UpdateEntity(T entity)
        {
            return await _iDbConnector.Update<T>(entity);
        }

        public async Task<long> CountEntity(List<string> fieldNames = null, List<string> values = null)
        {
            return await _iDbConnector.Count<T>(fieldNames, values);
        }

        public async Task<int> DeleteEntity(List<string> fieldNames = null, List<string> values = null)
        {
            return await _iDbConnector.Delete<T>(fieldNames, values);
        }

        public IDbConnection GetDBConnection()
        {
            return _iDbConnector.GetDBConnection();
        }

        public async Task<string> GetEntityCodeMax()
        {
            var tableName = typeof(T).Name.ToLower();
            var storeName = $"func_get_{tableName}_code_max";
            string entityCodeMax = (string)await GetDBConnection().ExecuteScalarAsync(storeName, commandType: CommandType.StoredProcedure);
            return entityCodeMax;
        }
    }
}
