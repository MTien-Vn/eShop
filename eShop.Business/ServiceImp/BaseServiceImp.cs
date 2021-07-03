using eShop.Business.Interface.IRepository;
using eShop.Business.Interface.IService;
using eShop.Business.ServiceRes;
using eShop.Business.ValidateData;
using Misa.BL.Properties;
using sShop.Business.Enum;
using System.Collections.Generic;

namespace eShop.Business.ServiceImp
{
    public class BaseServiceImp<T> : IBaseService<T>
    {
        IBaseRepository<T> baseRepository;
        public BaseServiceImp(IBaseRepository<T> _baseRepository)
        {
            baseRepository = _baseRepository;
        }
        public virtual ServiceResponse CountEntity(List<string> fieldNames = null, List<string> values = null)
        {
            ServiceResponse sr = new ServiceResponse();
            var result =  baseRepository.CountEntity(fieldNames, values);
            if(result >= 0)
            {
                sr.MisaCode = MyEnum.Scuccess;
                sr.Messenger.Add(Resources.Success);
                sr.Data = result;
            }
            else
            {
                sr.MisaCode = MyEnum.False;
                sr.Messenger.Add(Resources.Error_Get_count_entity);
            }
            return sr;
        }

        public ServiceResponse GetEntity(long page, long limmit, List<string> fieldNames = null, List<string> values = null)
        {
            ServiceResponse sr = new ServiceResponse();
            var result = baseRepository.GetData(page, limmit, fieldNames, values);
            if (result != null)
            {
                sr.MisaCode = MyEnum.Scuccess;
                sr.Messenger.Add(Resources.Success);
                sr.Data = result;
            }
            else
            {
                sr.MisaCode = MyEnum.False;
                sr.Messenger.Add(Resources.Error);
            }
            return sr;
        }
        public ServiceResponse GetEntityById(string id)
        {
            var tableName = typeof(T).Name;
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add(tableName + "_id");
            values.Add(id);
            return GetEntity(0, 1, fieldNames, values);
        }

        public ServiceResponse InsertT(T entity)
        {
            var validateObj = new ValidateObj<T>(baseRepository);
            var serviceResponse = validateObj.ValidateObject(entity, null);
            if (serviceResponse.MisaCode == MyEnum.Scuccess)
            {
                var result = baseRepository.InsertEntity(entity);
                if (result != null)
                {
                    serviceResponse.MisaCode = MyEnum.False;
                    serviceResponse.Messenger.Add(Resources.False);
                    serviceResponse.Data = result;
                }
            }
            else
            {
                serviceResponse.MisaCode = MyEnum.False;
                serviceResponse.Messenger.Add(Resources.False);
            }
            return serviceResponse;

        }

        public ServiceResponse UpdateT(T entity, string id)
        {
            var validateObj = new ValidateObj<T>(baseRepository);
            var serviceResponse = validateObj.ValidateObject(entity, id);
            if (serviceResponse.MisaCode == MyEnum.Scuccess)
            {
                var result = baseRepository.UpdateEntity(entity);
                if(result != null)
                {
                    serviceResponse.MisaCode = MyEnum.False;
                    serviceResponse.Messenger.Add(Resources.False);
                    serviceResponse.Data = result;
                }
            }
            else
            {
                serviceResponse.MisaCode = MyEnum.False;
                serviceResponse.Messenger.Add(Resources.False);
            }
            return serviceResponse;
        }

        public ServiceResponse DeleteT(List<string> fieldNames = null, List<string> values = null)
        {
            var serviceResponse = new ServiceResponse();
            var res = baseRepository.DeleteEntity(fieldNames, values);
            if (res == 0)
            {
                serviceResponse.MisaCode = MyEnum.False;
                serviceResponse.Messenger.Add(Resources.Error_Delete);
            }
            else
            {
                serviceResponse.MisaCode = MyEnum.Scuccess;
                serviceResponse.Messenger.Add(Resources.Success_Delete);
            }
            return serviceResponse;
        }

        public ServiceResponse GetEntityCodeMax()
        {
            var sr = new ServiceResponse();
            var result = baseRepository.GetEntityCodeMax();
            if (result != null)
            {
                sr.MisaCode = MyEnum.Scuccess;
                sr.Messenger.Add(Resources.Success);
                sr.Data = result;
            }
            else
            {
                sr.MisaCode = MyEnum.False;
                sr.Messenger.Add(Resources.Error);
            }
            return sr;
        }
    }
}
