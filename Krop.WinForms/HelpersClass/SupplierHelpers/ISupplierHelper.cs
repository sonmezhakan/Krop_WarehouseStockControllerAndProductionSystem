using Krop.Business.Features.Suppliers.Dtos;

namespace Krop.WinForms.HelpersClass.SupplierHelpers
{
    public interface ISupplierHelper
    {
        Task<List<GetSupplierComboBoxDTO>> GetAllComboBoxAsync();
        Task<List<GetSupplierDTO>> GetAllAsync();
        Task<GetSupplierDTO> GetBySupplierIdAsync(Guid Id);
    }
}
