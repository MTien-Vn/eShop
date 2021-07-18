using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace eShop.Business.Interface.IRepository
{
    public interface IUserModelRepository
    {
        IDbConnection GetDBConnection();
    }
}
