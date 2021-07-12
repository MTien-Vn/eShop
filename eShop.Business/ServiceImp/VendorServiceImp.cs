using eShop.Business.Entity;
using eShop.Business.Interface.IRepository.IVendorRepository;
using eShop.Business.Interface.IService.IVendorService;
using eShop.Business.Model;
using eShop.Business.Properties;
using eShop.Business.ServiceRes;
using sShop.Business.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.Business.ServiceImp.VendorServiceImp
{
    public class VendorServiceImp : BaseServiceImp<Vendor>, IVendorService
    {
        IVendorRepository vendorRepository;
        public VendorServiceImp(IVendorRepository _vendorRepository) : base(_vendorRepository)
        {
            vendorRepository = _vendorRepository;
        }

        #region get vendor

        public async Task<ServiceResponse> GetVendorByEmail(string email)
        {
            ServiceResponse sr = new ServiceResponse();
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("email");
            values.Add(email);
            return await this.GetEntity(0,10, fieldNames, values);
        }

        public async Task<ServiceResponse> GetVendorByVendorCode(string code)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("vendor_code");
            values.Add(code);
            return await this.GetEntity(0, 10, fieldNames, values);
        }

        public async Task<ServiceResponse> GetVendorByPhoneNumber(string phoneNumber)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("phone_number");
            values.Add(phoneNumber);
            return await this.GetEntity(0, 10, fieldNames, values);
        }

        public async Task<string> GetVendorCodeMax()
        {
            return await vendorRepository.GetEntityCodeMax();
        }

        public async Task<ServiceResponse> GetVendorByName(string name, long page, long limmit)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("vendorName");
            values.Add(name);
            return await this.GetEntity(0, 10, fieldNames, values);
        }
        #endregion

        #region save vendor

        //public ServiceResponse SaveVendor(VendorModel vendorModel)
        //{
        //    Vendor vendor = vendorModel.vendor;
        //    List<Item> items = vendorModel.items;
        //    ServiceResponse sr = new ServiceResponse();

        //    if (vendor.vendor_id == "" || vendor.vendor_id == null)
        //    {
        //        var serResultvendor = this.InsertT(vendor);
        //        if(serResultvendor.MisaCode == MyEnum.Scuccess)
        //        {
        //            sr.MisaCode = MyEnum.Scuccess;

        //            var vendorResult = serResultvendor.Data as Vendor;

        //            //lưu vào bảng vendor_item
        //            var vendorItem = new Vendor_invoice();
        //            vendorItem.vendor_id = vendorResult.vendor_id;

        //            var itemIdErrors = new List<string>();

        //            foreach (var item in items)
        //            {
        //                vendorItem.item_id = item.item_id;
        //                var rs = vendorItemService.InsertT(vendorItem);
        //                if(rs.MisaCode == MyEnum.False)
        //                {
        //                    itemIdErrors.Add(item.item_id);
        //                }
        //            }
        //            if (itemIdErrors.Any())
        //            {
        //                sr.Messenger.Add(Resources.Error_Insert_Vendor_Item);
        //                sr.Data = itemIdErrors;
        //            }
        //        }
        //        else
        //        {
        //            sr.MisaCode = MyEnum.False;
        //            sr.Messenger.Add(Resources.False);
        //        }
        //        return sr;
        //    }
        //    else
        //    {
        //        var serResultvendor = this.UpdateT(vendor, vendor.vendor_id.ToString());
        //        return serResultvendor;
        //    }
        //}
        #endregion

        #region filter vendor
        public async Task<ServiceResponse> FilterVendor(string key, long page, long limmit)
        {
            var result = await this.GetVendorByVendorCode(key);
            if(result.MisaCode == MyEnum.False && result.Data == null)
            {
                result = await this.GetVendorByName(key, page, limmit);
            }
            return result;
        }
        #endregion

    }
}
