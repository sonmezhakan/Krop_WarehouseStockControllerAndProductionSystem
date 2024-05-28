using Krop.Business.Features.Categories.Dtos;

namespace Krop.WinForms.HelpersClass.CategoryHelpers
{
    public interface ICategoryHelper
    {
        List<GetCategoryComboBoxDTO> GetAllComboBoxAsync();
        List<GetCategoryDTO> GetAllAsync();
        GetCategoryDTO GetByCategoryIdAsync(Guid Id);
    }
}
