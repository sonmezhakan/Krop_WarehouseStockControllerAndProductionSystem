using Krop.Business.Features.Employees.Dtos;

namespace Krop.WinForms.HelpersClass.Employees
{
    public interface IEmployeeHelper
    {
        GetEmployeeDTO GetByEmployeeIdAsync(Guid Id);
        GetEmployeeCartDTO GetByEmployeeIdCartAsync(Guid Id);
        IEnumerable<GetEmployeeComboBoxDTO> GetAllComboBoxAsync();
        IEnumerable<GetEmployeeListDTO> GetAllAsync();
    }
}
