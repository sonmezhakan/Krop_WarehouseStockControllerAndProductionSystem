using Krop.DTO.Dtos.Branches;
using Krop.DTO.Dtos.Departments;
using Krop.DTO.Dtos.Employees;

namespace Krop.ViewModel.ViewModels.Employees
{
    public record UpdateEmployeeVM
    {
        public List<GetEmployeeComboBoxDTO>? GetEmployeeComboBoxDTOs { get; init; }
        public List<GetDepartmentComboBoxDTO>? GetDepartmentComboBoxDTOs { get; init; }
        public List<GetBranchComboBoxDTO>? GetBranchComboBoxDTOs { get; init; }
        public UpdateEmployeeDTO? UpdateEmployeeDTO { get; init; }
    }
}
