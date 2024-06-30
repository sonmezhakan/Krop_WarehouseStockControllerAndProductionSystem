using AutoMapper;
using Krop.Business.Features.Customers.Constants;
using Krop.Business.Features.Customers.Rules;
using Krop.Business.Features.Customers.Valdiations;
using Krop.Business.Features.Departments.Constants;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Helpers.CacheHelpers;
using Krop.Common.Utilits.Business;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DataAccess.UnitOfWork;
using Krop.DTO.Dtos.Customers;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;

namespace Krop.Business.Services.Customers
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly CustomerBusinessRules _customerBusinessRules;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheHelper _cacheHelper;

        public CustomerManager(ICustomerRepository customerRepository, IMapper mapper, CustomerBusinessRules customerBusinessRules, IUnitOfWork unitOfWork, ICacheHelper cacheHelper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _customerBusinessRules = customerBusinessRules;
            _unitOfWork = unitOfWork;
            _cacheHelper = cacheHelper;
        }

        #region Add
        [ValidationAspect(typeof(CreateCustomerValidatior))]
        public async Task<IResult> AddAsync(CreateCustomerDTO createCustomerDTO)
        {
            Customer customer = _mapper.Map<Customer>(createCustomerDTO);

            await _customerRepository.AddAsync(customer);
            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                CustomerCacheKeys.GetAllAsync,
                CustomerCacheKeys.GetAllComboBoxAsync
            });
            return new SuccessResult();
        }
        #endregion
        #region Update
        [ValidationAspect(typeof(UpdateCustomerValidator))]
        public async Task<IResult> UpdateAsync(UpdateCustomerDTO updateCustomerDTO)
        {
            var result = await _customerRepository.GetAsync(x=>x.Id ==  updateCustomerDTO.Id);
            if (result is null)
                return new ErrorResult(StatusCodes.Status404NotFound, CustomerMessages.CustomerNotFound);

            Customer customer = _mapper.Map(updateCustomerDTO, result);

            await _customerRepository.UpdateAsync(customer);
            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                CustomerCacheKeys.GetAllAsync,
                CustomerCacheKeys.GetAllComboBoxAsync,
                $"{CustomerCacheKeys.GetByIdAsync}{updateCustomerDTO.Id}"
            });
            return new SuccessResult(); ;
        }
        #endregion
        #region Delete
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var result = await _customerRepository.GetAsync(x => x.Id == id);
            if (result is null)
                return new ErrorResult(StatusCodes.Status404NotFound, CustomerMessages.CustomerNotFound);

            await _customerRepository.DeleteAsync(result);
            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                CustomerCacheKeys.GetAllAsync,
                CustomerCacheKeys.GetAllComboBoxAsync,
                $"{CustomerCacheKeys.GetByIdAsync}{id}"
            });
            return new SuccessResult();
        }
        #endregion
        #region Listed
        public async Task<IDataResult<IEnumerable<GetCustomerDTO>>> GetAllAsync()
        {
            IEnumerable<GetCustomerDTO>? getCustomerDTOs = await _cacheHelper.GetOrAddListAsync(
                CustomerCacheKeys.GetAllAsync,
                async () =>
                {
                    var result = await _customerRepository.GetAllAsync();
                    return result is null ? null : _mapper.Map<IEnumerable<GetCustomerDTO>>(result);
                },
                60
                );
            return new SuccessDataResult<IEnumerable<GetCustomerDTO>>(getCustomerDTOs);
        }
        public async Task<IDataResult<IEnumerable<GetCustomerComboBoxDTO>>> GetAllComboBoxAsync()
        {
            IEnumerable<GetCustomerComboBoxDTO>? getCustomerComboBoxDTOs = await _cacheHelper.GetOrAddListAsync(
                CustomerCacheKeys.GetAllComboBoxAsync,
                async () =>
                {
                    var result = await _customerRepository.GetAllComboBoxAsync();
                    return result is null ? null : _mapper.Map<IEnumerable<GetCustomerComboBoxDTO>>(result);
                },
                60
                );
            return new SuccessDataResult<IEnumerable<GetCustomerComboBoxDTO>>(getCustomerComboBoxDTOs);
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetCustomerDTO>> GetByIdAsync(Guid id)
        {
            GetCustomerDTO? getCustomerDTO = await _cacheHelper.GetOrAddAsync(
                $"{CustomerCacheKeys.GetByIdAsync}{id}",
                async () =>
                {
                    var result = await _customerRepository.GetAsync(x=>x.Id == id);
                    return result is null ? null : _mapper.Map<GetCustomerDTO>(result);
                },
                60
                );
                return getCustomerDTO is null ?
                new ErrorDataResult<GetCustomerDTO>(StatusCodes.Status404NotFound, CustomerMessages.CustomerNotFound):
                 new SuccessDataResult<GetCustomerDTO>(getCustomerDTO);
        }

        #endregion
    }
}
