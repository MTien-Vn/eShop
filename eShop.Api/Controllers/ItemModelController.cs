using eShop.Business.Entity;
using eShop.Business.Interface.IService;
using eShop.Business.Model;
using eShop.Business.ServiceRes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MISA_AMIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemModelController : BaseEntityController<Item>
    {
        readonly IItemModelService itemService;
        public ItemModelController(IItemModelService _itemService) : base(_itemService)
        {
            this.itemService = _itemService;
        }

        [HttpPost("postItemModel")]
        public async Task<ServiceResponse> PostItemModel(ItemModel itemModel)
        {
            return await itemService.SaveItemModel(itemModel);
        }
    }
}
