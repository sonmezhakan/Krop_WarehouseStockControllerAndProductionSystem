using AutoMapper;
using Krop.Business.Features.Customers.Rules;
using Krop.Business.Features.Customers.Valdiations;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DataAccess.UnitOfWork;
using Krop.DTO.Dtos.Customers;
using Krop.Entities.Entities;

namespace Krop.Business.Services.Customers
{
    public class CustomerManager:ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly CustomerBusinessRules _customerBusinessRules;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerManager(ICustomerRepository customerRepository,IMapper mapper,CustomerBusinessRules customerBusinessRules,IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _customerBusinessRules = customerBusinessRules;
            _unitOfWork = unitOfWork;
        }

        #region Add
       
        public async Task<IResult> AddAsync(CreateCustomerDTO createCustomerDTO)
        {
            Customer customer = _mapper.Map<Customer>(createCustomerDTO); 

            await _customerRepository.AddAsync(customer);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult();
        }
        #endregion
        #region Update
       
        public async  Task<IResult> UpdateAsync(UpdateCustomerDTO updateCustomerDTO)
        {
            var result = await _customerBusinessRules.CheckByCustomerId(updateCustomerDTO.Id);
            if (!result.Success)
                return result;

            Customer customer = _mapper.Map(updateCustomerDTO, result.Data);

            await _customerRepository.UpdateAsync(customer);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult(); ;
        }
        #endregion
        #region Delete
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var result = await _customerBusinessRules.CheckByCustomerId(id);
            if (!result.Success)
                return result;

            await _customerRepository.DeleteAsync(result.Data);
            await _unitOfWork.SaveChangesAsync();
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
        public async Task<IDataResult<IEnumerable<GetCustomerComboBoxDTO>>> GetAllComboBoxAsync()
        {
            var result =await _customerRepository.GetAllComboBoxAsync();

            return new SuccessDataResult<IEnumerable<GetCustomerComboBoxDTO>>(
                _mapper.Map<List<GetCustomerComboBoxDTO>>(result));
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetCustomerDTO>> GetByIdAsync(Guid id)
        {
            var result = await _customerBusinessRules.CheckByCustomerId(id);
            if (!result.Success)
                return new ErrorDataResult<GetCustomerDTO>(result.Status, result.Detail);

            return new SuccessDataResult<GetCustomerDTO>(
                _mapper.Map<GetCustomerDTO>(result.Data));
        }

        #endregion
    }
}
