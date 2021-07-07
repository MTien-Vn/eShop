using Dapper;
using eShop.Business.Interface.IDBConnector;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Repository.DBConnectorImp
{
    public class DBConnectorImp : IDBConnector
    {
        protected string connectionString;
        protected IDbConnection dbConnection;
        readonly IConfiguration configuration;
        public DBConnectorImp(IConfiguration config)
        {
            configuration = config;
            connectionString = configuration.GetSection("DBInfo").GetSection("ConnectionString").Value;
            dbConnection = new NpgsqlConnection(connectionString);
        }

        #region get entity
        public async Task<IEnumerable<T>> GetData<T>(long page, long limmit, List<string> fieldNames = null, List<string> values = null)
        {
            long offSet;
            if (page == 1)
            {
                offSet = 0;
            }
            else
            {
                offSet = (page - 1) * limmit - 1;
            }
            var tableName = typeof(T).Name.ToLower();
            var storeName = $"func_get_{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@off_set", offSet);
            dynamicParameters.Add("@limmit", limmit);
            if (values == null)
            {
                var entities = await dbConnection.QueryAsync<T>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
                return entities;
            }
            else
            {
                int index = 0;
                storeName += "_by";
                Array _values = values.ToArray();
                foreach (var fieldName in fieldNames)
                {
                    var fielNameLowwer = fieldName.ToLower();
                    storeName += $"_{fielNameLowwer}";
                    dynamicParameters.Add($"@{fielNameLowwer}", _values.GetValue(index));
                    index++;
                }
                var entities = await dbConnection.QueryAsync<T>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
                return entities;
            }
        }

        public async Task<IEnumerable<T>> GetData<T>(string sql)
        {
            var entity = await dbConnection.QueryAsync<T>(sql);
            return entity;
        }
        #endregion

        public async Task<T> Insert<T>(T entity)
        {
            var tableName = typeof(T).Name.ToLower();
            var storeName = $"func_insert_{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    if (propertyValue == null)
                    {
                        propertyValue = "";
                    }
                    else
                    {
                        propertyValue = propertyValue.ToString();
                    }
                }
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            var affects = await dbConnection.QueryAsync<T>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return affects.FirstOrDefault();
        }

        
        public async Task<T> Update<T>(T entity)
        {
            var tableName = typeof(T).Name.ToLower();
            var storeName = $"func_update_{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    if (propertyValue == null)
                    {
                        propertyValue = "";
                    }
                    else
                    {
                        propertyValue = propertyValue.ToString();
                    }
                }
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            var affects = await dbConnection.QueryAsync<T>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return affects.FirstOrDefault();
        }

        public async Task<int> Delete<T>(List<string> fieldNames, List<string> values)
        {
            var tableName = typeof(T).Name.ToLower();
            var storeName = $"func_delete_{tableName}_by";
            var index = 0;
            DynamicParameters dynamicParameters = new DynamicParameters();
            foreach (var fieldName in fieldNames)
            {
                var fielNameLowwer = fieldName.ToLower();
                storeName += '_';
                storeName += fielNameLowwer;
                dynamicParameters.Add($"@{fielNameLowwer}", values[index]);
                index++;
            }
            var affect = await dbConnection.ExecuteAsync(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return affect;
        }

        #region count entity
        public async Task<long> Count<T>(List<string> fieldNames = null, List<string> values = null)
        {
            var tableName = typeof(T).Name.ToLower();
            if (values == null)
            {
                var storeName = $"func_count_{tableName}";
                long total = (long)await dbConnection.ExecuteScalarAsync(storeName, commandType: CommandType.StoredProcedure);
                return total;
            }
            else
            {
                string storeName = $"func_count_{tableName}_by";
                DynamicParameters dynamicParameters = new DynamicParameters();
                Array _values = values.ToArray();
                int index = 0;
                if (fieldNames.Any() == false)
                {
                    return -1;
                }
                else
                {
                    foreach (var fieldName in fieldNames)
                    {
                        storeName += '_';
                        storeName += $"{fieldName}";
                        dynamicParameters.Add($"@{fieldName}", _values.GetValue(index));
                        index++;
                    }
                }
                long total = (long)await dbConnection.ExecuteScalarAsync(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
                return total;
            }
        }

        public IDbConnection GetDBConnection()
        {
            return dbConnection;
        }
        #endregion
    }
}
