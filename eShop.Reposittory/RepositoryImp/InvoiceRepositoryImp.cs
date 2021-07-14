using eShop.Business.Interface.IDBConnector;
using eShop.Business.Interface.IRepository;
using eShop.Business.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Repository.RepositoryImp
{
    public class InvoiceRepositoryImp : BaseRepositoryImp<InvoiceModel>, IInvoiceRepository
    {
        public InvoiceRepositoryImp(IDBConnector iDBConnector) : base(iDBConnector)
        {
        }
    }
}
