using eShop.Business.Entity;
using eShop.Business.Interface.IService.IVendorService;
using Microsoft.AspNetCore.Mvc;

namespace MISA_AMIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : BaseEntityController<Vendor>
    {
        IVendorService vendorService;
        public VendorController(IVendorService _vendorService) : base(_vendorService)
        {
            this.vendorService = _vendorService;
        }
        
    }
}
