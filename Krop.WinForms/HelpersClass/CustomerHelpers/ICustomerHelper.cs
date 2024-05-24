using Krop.Business.Features.Customers.Dtos;

namespace Krop.WinForms.HelpersClass.CustomerHelpers
{
    public interface ICustomerHelper
    {
        Task<List<GetCustomerDTO>> GetAllAsync();
        Task<List<GetCustomerComboBoxDTO>> GetAllComboBoxAsync();
        Task<GetCustomerDTO> GetByCustomerIdAsync(Guid Id);
    }
}
