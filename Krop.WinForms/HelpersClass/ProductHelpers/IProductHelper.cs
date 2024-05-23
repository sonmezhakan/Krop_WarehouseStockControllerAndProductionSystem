using Krop.Business.Features.Products.Dtos;

namespace Krop.WinForms.HelpersClass.ProductHelpers
{
    public interface  IProductHelper
    {
        Task<List<GetProductComboBoxDTO>> GetAllComboBoxAsync();
        Task<GetProductDTO> GetProductByIdAsync(Guid Id);
    }
}
