using Krop.Business.Features.Products.Dtos;

namespace Krop.WinForms.HelpersClass.ProductHelpers
{
    public interface  IProductHelper
    {
        List<GetProductComboBoxDTO> GetAllComboBoxAsync();
        List<GetProductListDTO> GetAllAsync();
        GetProductDTO GetByProductIdAsync(Guid Id);
        GetProductCartDTO GetByProductIdCartAsync(Guid Id);
    }
}
