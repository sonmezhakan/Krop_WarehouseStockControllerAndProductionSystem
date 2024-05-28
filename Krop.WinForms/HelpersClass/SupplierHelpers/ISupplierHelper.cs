using Krop.Business.Features.Suppliers.Dtos;

namespace Krop.WinForms.HelpersClass.SupplierHelpers
{
    public interface ISupplierHelper
    {
        List<GetSupplierComboBoxDTO> GetAllComboBoxAsync();
        List<GetSupplierDTO> GetAllAsync();
        GetSupplierDTO GetBySupplierIdAsync(Guid Id);
    }
}
