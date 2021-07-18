using eShop.Business.Interface.IDBConnector;
using eShop.Business.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace eShop.Repository.RepositoryImp
{
    public class UserModelRepositoryImp : IUserModelRepository
    {
        private readonly IDBConnector iDBConnector;
        public UserModelRepositoryImp(IDBConnector _iDBConnector)
        {
            this.iDBConnector = _iDBConnector;
        }
        public IDbConnection GetDBConnection()
        {
            return this.iDBConnector.GetDBConnection();
        }
    }
}
