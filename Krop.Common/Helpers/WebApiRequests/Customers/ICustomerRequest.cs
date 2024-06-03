using Krop.DTO.Dtos.Customers;

namespace Krop.Common.Helpers.WebApiRequests.Customers
{
    public interface ICustomerRequest
    {
        Task<HttpResponseMessage> GetAllAsync();
        Task<HttpResponseMessage> GetAllComboBoxAsync();
        Task<HttpResponseMessage> GetByIdAsync(Guid id);
        Task<HttpResponseMessage> AddAsync(CreateCustomerDTO createCustomerDTO);
        Task<HttpResponseMessage> UpdateAsync(UpdateCustomerDTO updateCustomerDTO);
        Task<HttpResponseMessage> DeleteAsync(Guid id);
    }
}
