using eShop.Business.Interface.IRepository;
using eShop.Business.Interface.IService;
using eShop.Business.Properties;
using eShop.Business.ServiceRes;
using eShop.Business.ValidateData;
using sShop.Business.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.Business.ServiceImp
{
    public class BaseServiceImp<T> : IBaseService<T>
    {
        IBaseRepository<T> baseRepository;
        public BaseServiceImp(IBaseRepository<T> _baseRepository)
        {
            baseRepository = _baseRepository;
        }
        public virtual async Task<ServiceResponse> CountEntity(List<string> fieldNames = null, List<string> values = null)
        {
            ServiceResponse sr = new ServiceResponse();
            var result = await baseRepository.CountEntity(fieldNames, values);
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

        public virtual async Task<ServiceResponse> GetEntity(long page, long limmit, List<string> fieldNames = null, List<string> values = null)
        {
            ServiceResponse sr = new ServiceResponse();
            var result = await baseRepository.GetData(page, limmit, fieldNames, values);
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
        public async Task<ServiceResponse> GetEntityById(string id)
        {
            var tableName = typeof(T).Name;
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add(tableName + "_id");
            values.Add(id);
            return await GetEntity(0, 1, fieldNames, values);
        }

        public async Task<ServiceResponse> InsertT(T entity)
        {
            var validateObj = new ValidateObj<T>(baseRepository);
            var serviceResponse = validateObj.ValidateObject(entity, null);
            if (serviceResponse.MisaCode == MyEnum.Scuccess)
            {
                var result = await baseRepository.InsertEntity(entity);
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

        public async Task<ServiceResponse> UpdateT(T entity, string id)
        {
            var validateObj = new ValidateObj<T>(baseRepository);
            var serviceResponse = validateObj.ValidateObject(entity, id);
            if (serviceResponse.MisaCode == MyEnum.Scuccess)
            {
                var result = await baseRepository.UpdateEntity(entity);
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

        public async Task<ServiceResponse> DeleteT(List<string> fieldNames = null, List<string> values = null)
        {
            var serviceResponse = new ServiceResponse();
            var res = await baseRepository.DeleteEntity(fieldNames, values);
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

        public async Task<ServiceResponse> GetEntityCodeMax()
        {
            var sr = new ServiceResponse();
            var result = await baseRepository.GetEntityCodeMax();
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
