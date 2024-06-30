using Krop.DataAccess.Repositories.Abstracts;

namespace Krop.Business.Features.Customers.Rules
{
    public class CustomerBusinessRules
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerBusinessRules(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
    }
}
