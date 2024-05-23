using Krop.Business.Features.Categories.Dtos;

namespace Krop.WinForms.HelpersClass.CategoryHelpers
{
    public interface ICategoryHelper
    {
        Task<List<GetCategoryComboBoxDTO>> GetAllComboBoxAsync();
        Task<List<GetCategoryDTO>> GetAllAsync();
        Task<GetCategoryDTO> GetByCategoryIdAsync(Guid Id);
    }
}
