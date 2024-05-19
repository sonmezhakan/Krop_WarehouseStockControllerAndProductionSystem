using Krop.Business.Features.Suppliers.Dtos;
using Krop.Common.Utilits.Result;

namespace Krop.Business.Services.Suppliers
{
    public interface ISupplierService
    {
        Task<IResult> AddAsync(CreateSupplierDTO createSupplierDTO);
        Task<IResult> UpdateAsync(UpdateSupplierDTO updateSupplierDTO);
        Task<IResult> DeleteAsync(Guid id);

        Task<IDataResult<IEnumerable<GetSupplierDTO>>> GetAllAsync();
        Task<IDataResult<GetSupplierDTO>> GetByIdAsync(Guid id);
    }
}
