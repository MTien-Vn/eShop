using eShop.Business.Entity;
using eShop.Business.Model;
using eShop.Business.ServiceRes;
using System.Threading.Tasks;

namespace eShop.Business.Interface.IService
{
    public interface IItemService : IBaseService<ItemModel>
    {
        /// <summary>
        /// lưu/ update sản phẩm  mới (có thể) kèm theo nhà cung cấp
        /// </summary>
        /// <param name="itemModel"></param>
        /// <returns></returns>
        Task<ServiceResponse> SaveItemModel(ItemModel itemModel);
    }
}
