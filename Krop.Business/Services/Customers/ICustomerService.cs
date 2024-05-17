using Krop.Business.Features.Customers.Dtos;

namespace Krop.Business.Services.Customers
{
    public interface ICustomerService
    {
        Task<bool> AddAsync(CreateCustomerDTO createCustomerDTO);
        Task<bool> UpdateAsync(UpdateCustomerDTO updateCustomerDTO);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<GetCustomerDTO>> GetAllAsync();
        Task<GetCustomerDTO> GetByIdAsync(Guid id);
    }
}
