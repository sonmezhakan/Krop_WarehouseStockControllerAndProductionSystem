using Krop.Business.Features.Customers.Constants;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;

namespace Krop.Business.Features.Customers.Rules
{
    public class CustomerBusinessRules
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerBusinessRules(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IDataResult<Customer>> CheckByCustomerId(Guid id)
        {
            var result = await _customerRepository.GetAsync(c => c.Id == id);
            if (result is null)
                return new ErrorDataResult<Customer>(StatusCodes.Status404NotFound, CustomerMessages.CustomerNotFound);

            return new SuccessDataResult<Customer>(result);
        }
    }
}
