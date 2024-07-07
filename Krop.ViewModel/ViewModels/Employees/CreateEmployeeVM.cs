using Krop.DTO.Dtos.AppUsers;
using Krop.DTO.Dtos.Branches;
using Krop.DTO.Dtos.Departments;
using Krop.DTO.Dtos.Employees;

namespace Krop.ViewModel.ViewModels.Employees
{
    public record CreateEmployeeVM
    {
        public List<GetAppUserComboBoxDTO>? GetAppUserComboBoxDTOs { get; init; }
        public List<GetDepartmentComboBoxDTO>? GetDepartmentComboBoxDTOs { get; init; }
        public List<GetBranchComboBoxDTO>? GetBranchComboBoxDTOs { get; init; }
        public CreateEmployeeDTO? CreateEmployeeDTO { get; init; }
    }
}
