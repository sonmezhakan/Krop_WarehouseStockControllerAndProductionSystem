using Krop.DTO.Dtos.Suppliers;

namespace Krop.Common.Helpers.WebApiRequests.Suppliers
{
    public interface ISupplierRequest
    {
        Task<HttpResponseMessage> GetAllAsync();
        Task<HttpResponseMessage> GetAllComboBoxAsync();
        Task<HttpResponseMessage> GetByIdAsync(Guid id);
        Task<HttpResponseMessage> AddAsync(CreateSupplierDTO createSupplierDTO);
        Task<HttpResponseMessage> UpdateAsync(UpdateSupplierDTO updateSupplierDTO);
        Task<HttpResponseMessage> DeleteAsync(Guid id);
    }
}
