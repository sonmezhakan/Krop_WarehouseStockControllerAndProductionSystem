using Krop.Business.Features.Customers.Dtos;

namespace Krop.WinForms.HelpersClass.CustomerHelpers
{
    public interface ICustomerHelper
    {
        List<GetCustomerDTO> GetAllAsync();
        List<GetCustomerComboBoxDTO> GetAllComboBoxAsync();
        GetCustomerDTO GetByCustomerIdAsync(Guid Id);
    }
}
