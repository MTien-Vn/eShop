using eShop.Business.Entity;
using eShop.Business.ServiceRes;
using NMT.Model.Model;

namespace eShop.Business.Interface.IService
{
    public interface IItemModelService : IBaseService<Item>
    {
        /// <summary>
        /// lưu/ update sản phẩm  mới (có thể) kèm theo nhà cung cấp
        /// </summary>
        /// <param name="itemModel"></param>
        /// <returns></returns>
        public ServiceResponse SaveItemModel(ItemModel itemModel);
    }
}
