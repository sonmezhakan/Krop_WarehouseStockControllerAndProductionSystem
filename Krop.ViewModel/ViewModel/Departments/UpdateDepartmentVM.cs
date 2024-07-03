using Krop.DTO.Dtos.Departments;

namespace Krop.ViewModel.ViewModel.Departments
{
    public record UpdateDepartmentVM
    {
        public List<GetDepartmentComboBoxDTO>? GetDepartmentComboBoxDTO { get; init; }
        public UpdateDepartmentDTO? UpdateDepartmentDTO { get; init; }
    }
}
