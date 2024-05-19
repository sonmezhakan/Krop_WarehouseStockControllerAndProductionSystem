using AutoMapper;
using Krop.Business.Features.Customers.Dtos;
using Krop.Business.Features.Customers.ExceptionHelpers;
using Krop.Business.Features.Customers.Rules;
using Krop.Business.Features.Customers.Valdiations;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.Business.Services.Customers
{
    public class CustomerManager:ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly CustomerBusinessRules _customerBusinessRules;

        public CustomerManager(ICustomerRepository customerRepository,IMapper mapper,CustomerBusinessRules customerBusinessRules)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _customerBusinessRules = customerBusinessRules;
        }

        #region Add
        [ValidationAspect(typeof(CreateCustomerValidatior))]
        public async Task<IResult> AddAsync(CreateCustomerDTO createCustomerDTO)
        {
            Customer customer = _mapper.Map<Customer>(createCustomerDTO); 

            await _customerRepository.AddAsync(customer);

            return new SuccessResult();
        }
        #endregion
        #region Update
        [ValidationAspect(typeof(UpdateCustomerValidator))]
        public async  Task<IResult> UpdateAsync(UpdateCustomerDTO updateCustomerDTO)
        {
            var customer = await _customerBusinessRules.CheckByCustomerId(updateCustomerDTO.Id);

            customer = _mapper.Map(updateCustomerDTO, customer);

            await _customerRepository.UpdateAsync(customer);

            return new SuccessResult(); ;
        }
        #endregion
        #region Delete
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var customer = await _customerBusinessRules.CheckByCustomerId(id);

            await _customerRepository.DeleteAsync(customer);

            return new SuccessResult();
        }
        #endregion
        #region Listed
        public async Task<IDataResult<IEnumerable<GetCustomerDTO>>> GetAllAsync()
        {
            var result = await _customerRepository.GetAllAsync();

            return new SuccessDataResult<IEnumerable<GetCustomerDTO>>(
                _mapper.Map<List<GetCustomerDTO>>(result));
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetCustomerDTO>> GetByIdAsync(Guid id)
        {
            var customer = await _customerBusinessRules.CheckByCustomerId(id);

            return new SuccessDataResult<GetCustomerDTO>(
                _mapper.Map<GetCustomerDTO>(customer));
        }
        #endregion
    }
}
