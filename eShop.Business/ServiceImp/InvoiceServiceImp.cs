using eShop.Business.Interface.IRepository;
using eShop.Business.Interface.IService;
using eShop.Business.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Business.ServiceImp
{
    public class InvoiceServiceImp : BaseServiceImp<InvoiceModel>, IInvoiceService
    {
        private IInvoiceRepository invoiceRepository;
        public InvoiceServiceImp(IInvoiceRepository _invoiceRepository) : base(_invoiceRepository)
        {
            this.invoiceRepository = _invoiceRepository;
        }
    }
}
