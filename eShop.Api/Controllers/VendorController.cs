using eShop.Business.Entity;
using eShop.Business.Interface.IService.IVendorService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MISA_AMIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="admin")]
    public class VendorController : BaseEntityController<Vendor>
    {
        IVendorService vendorService;
        public VendorController(IVendorService _vendorService) : base(_vendorService)
        {
            vendorService = _vendorService;
        }
        
    }
}
