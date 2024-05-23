using Krop.Business.Features.Brands.Dtos;

namespace Krop.WinForms.HelpersClass.BrandHelpers
{
    public interface IBrandHelper
    {
        Task<List<GetBrandComboBoxDTO>> GetAllComboBoxAsync();
        Task<List<GetBrandDTO>> GetAllAsync();
        Task<GetBrandDTO> GetByBrandIdAsync(Guid Id);
    }
}
