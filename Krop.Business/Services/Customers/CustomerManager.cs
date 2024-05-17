using AutoMapper;
using Krop.Business.Features.Customers.Dtos;
using Krop.Business.Features.Customers.ExceptionHelpers;
using Krop.Business.Features.Customers.Rules;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.Business.Services.Customers
{
    public class CustomerManager:ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly CustomerExceptionHelper _customerExceptionHelper;
        private readonly CustomerBusinessRules _customerBusinessRules;

        public CustomerManager(ICustomerRepository customerRepository,IMapper mapper,CustomerExceptionHelper customerExceptionHelper,CustomerBusinessRules customerBusinessRules)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _customerExceptionHelper = customerExceptionHelper;
            _customerBusinessRules = customerBusinessRules;
        }

        #region Add
        public async Task<bool> AddAsync(CreateCustomerDTO createCustomerDTO)
        {
            Customer customer = _mapper.Map<Customer>(createCustomerDTO);

            return await _customerRepository.AddAsync(customer);
        }
        #endregion
        #region Update
        public async  Task<bool> UpdateAsync(UpdateCustomerDTO updateCustomerDTO)
        {
            Customer customer = await _customerRepository.FindAsync(updateCustomerDTO.Id);
            if (customer is null)
                _customerExceptionHelper.ThrowCustomerNotFound();

            customer = _mapper.Map(updateCustomerDTO, customer);

            return await _customerRepository.UpdateAsync(customer);
        }
        #endregion
        #region Delete
        public async Task<bool> DeleteAsync(Guid id)
        {
            Customer customer = await _customerRepository.FindAsync(id);
            if (customer is null)
                _customerExceptionHelper.ThrowCustomerNotFound();

            return await _customerRepository.DeleteAsync(customer);
        }
        #endregion
        #region Listed
        public async Task<IEnumerable<GetCustomerDTO>> GetAllAsync()
        {
            var result = await _customerRepository.GetAllAsync();

            return _mapper.Map<List<GetCustomerDTO>>(result);
        }
        #endregion
        #region Search
        public async Task<GetCustomerDTO> GetByIdAsync(Guid id)
        {
            Customer customer = await _customerRepository.FindAsync(id);
            if (customer is null)
                _customerExceptionHelper.ThrowCustomerNotFound();

            return _mapper.Map<GetCustomerDTO>(customer);
        }
        #endregion
    }
}
