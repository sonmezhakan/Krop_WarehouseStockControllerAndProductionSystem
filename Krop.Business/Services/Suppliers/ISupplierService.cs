using Krop.Business.Features.Suppliers.Dtos;

namespace Krop.Business.Services.Suppliers
{
    public interface ISupplierService
    {
        Task<bool> AddAsync(CreateSupplierDTO createSupplierDTO);
        Task<bool> UpdateAsync(UpdateSupplierDTO updateSupplierDTO);
        Task<bool> DeleteAsync(Guid id);

        Task<IEnumerable<GetSupplierDTO>> GetAllAsync();
        Task<GetSupplierDTO> GetByIdAsync(Guid id);
    }
}
