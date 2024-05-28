using Krop.Business.Features.Departments.Dtos;

namespace Krop.WinForms.HelpersClass.Departments
{
    public interface IDepartmentHelper
    {
        List<GetDepartmentDTO> GetAllAsync();
        List<GetDepartmentComboBoxDTO> GetAllComboBoxAsync();
        GetDepartmentDTO GetByDepartmentId(Guid Id);
    }
}
