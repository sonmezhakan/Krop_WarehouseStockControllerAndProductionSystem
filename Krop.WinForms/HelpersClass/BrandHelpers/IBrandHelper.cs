using Krop.Business.Features.Brands.Dtos;

namespace Krop.WinForms.HelpersClass.BrandHelpers
{
    public interface IBrandHelper
    {
        List<GetBrandComboBoxDTO> GetAllComboBoxAsync();
        List<GetBrandDTO> GetAllAsync();
        GetBrandDTO GetByBrandIdAsync(Guid Id);
    }
}
