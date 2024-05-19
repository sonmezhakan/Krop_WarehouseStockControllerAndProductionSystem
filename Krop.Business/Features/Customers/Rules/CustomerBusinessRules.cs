using Krop.Business.Features.Customers.ExceptionHelpers;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.Business.Features.Customers.Rules
{
    public class CustomerBusinessRules
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerExceptionHelper _customerExceptionHelper;

        public CustomerBusinessRules(ICustomerRepository customerRepository, CustomerExceptionHelper customerExceptionHelper)
        {
            _customerRepository = customerRepository;
            _customerExceptionHelper = customerExceptionHelper;
        }

        public async Task<Customer> CheckByCustomerId(Guid id)
        {
            var result = await _customerRepository.GetAsync(c => c.Id == id);
            if (result is null)
                _customerExceptionHelper.ThrowCustomerNotFound();

            return result;
        }
    }
}
