using eShop.Business.Interface.IService;
using eShop.Business.Interface.IRepository;
using eShop.Business.ServiceRes;
using eShop.Business.Entity;
using eShop.Business.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace eShop.Business.ServiceImp
{
    public class ItemServiceImp : BaseServiceImp<ItemModel>, IItemService
    {
        IItemRepository itemRepository;
        public ItemServiceImp(IItemRepository _itemRepository) : base(_itemRepository)
        {
            itemRepository = _itemRepository;
        }

        public Task<ServiceResponse> SaveItemModel(ItemModel itemModel)
        {
            //List<Vendor> vendors = itemModel.vendors;
            //Item item = itemModel.item;

            //ServiceResponse sr = new ServiceResponse();

            //if (item.item_id == "" || item.item_id == null)
            //{
            //    var serResultItem = this.InsertT(item);
            //    if (serResultItem.MisaCode == MyEnum.Scuccess)
            //    {
            //        sr.MisaCode = MyEnum.Scuccess;

            //        var itemResult = serResultItem.Data as Item;

            //        //lưu vào bảng vendor_item
            //        var vendorItem = new Vendor_invoice();
            //        vendorItem.item_id = itemResult.item_id;

            //        var vendorIdErrors = new List<string>();

            //        foreach (var vendor in vendors)
            //        {
            //            vendorItem.vendor_id = vendor.vendor_id;
            //            var rs = vendorItemService.InsertT(vendorItem);
            //            if (rs.MisaCode == MyEnum.False)
            //            {
            //                vendorIdErrors.Add(item.item_id);
            //            }
            //        }
            //        if (vendorIdErrors.Any())
            //        {
            //            sr.Messenger.Add(Resources.Error_Insert_Vendor_Item);
            //            sr.Data = vendorIdErrors;
            //        }
            //    }
            //    else
            //    {
            //        sr.MisaCode = MyEnum.False;
            //        sr.Messenger.Add(Resources.False);
            //    }
            //    return sr;
            //}
            //else
            //{
            //    var serResultItem = this.UpdateT(item, item.item_id.ToString());
            //    return serResultItem;
            //}
            return null;
        }
    }
}
