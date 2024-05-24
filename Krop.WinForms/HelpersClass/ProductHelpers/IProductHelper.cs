using Krop.Business.Features.Products.Dtos;

namespace Krop.WinForms.HelpersClass.ProductHelpers
{
    public interface  IProductHelper
    {
        Task<List<GetProductComboBoxDTO>> GetAllComboBoxAsync();
        Task<List<GetProductListDTO>> GetAllAsync();
        Task<GetProductDTO> GetProductByIdAsync(Guid Id);
    }
}
