using eShop.Business.Entity;
using eShop.Business.Interface.IRepository.IVendorRepository;
using eShop.Business.Interface.IService.IVendorService;
using System.Collections.Generic;

namespace eShop.Business.ServiceImp.VendorServiceImp
{
    public class VendorServiceImp : BaseServiceImp<Vendor>, IVendorService
    {
        IVendorRepository vendorRepository;
        public VendorServiceImp(IVendorRepository _vendorRepository) : base(_vendorRepository)
        {
            vendorRepository = _vendorRepository;
        }

        #region count vendor
        public ServiceResponse CountVendorByKey(string key)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("vendor_code");
            values.Add(key);
            var sr = this.CountEntity(fieldNames, values);
            if(sr.MisaCode == MyEnum.False)
            {
                fieldNames.Remove("vendor_code");
                fieldNames.Add("vendor_name");
                sr = this.CountEntity(fieldNames, values);
            }
            return sr;
        }
        #endregion

        #region get vendor
        
        public ServiceResponse GetVendorByEmail(string email)
        {
            ServiceResponse sr = new ServiceResponse();
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("email");
            values.Add(email);
            return this.GetEntity(0,10, fieldNames, values);
        }

        public ServiceResponse GetVendorByVendorCode(string code)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("vendor_code");
            values.Add(code);
            return this.GetEntity(0, 10, fieldNames, values);
        }

        public ServiceResponse GetVendorByPhoneNumber(string phoneNumber)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("phone_number");
            values.Add(phoneNumber);
            return this.GetEntity(0, 10, fieldNames, values);
        }

        public string GetVendorCodeMax()
        {
            return vendorRepository.GetEntityCodeMax();
        }

        public ServiceResponse GetVendorByName(string name, long page, long limmit)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("vendorName");
            values.Add(name);
            return this.GetEntity(0, 10, fieldNames, values);
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
        public ServiceResponse filterVendor(string key, long page, long limmit)
        {
            var result = this.GetVendorByVendorCode(key);
            if(result.MisaCode == MyEnum.False && result.Data == null)
            {
                result = this.GetVendorByName(key, page, limmit);
            }
            return result;
        }
        #endregion

    }
}
