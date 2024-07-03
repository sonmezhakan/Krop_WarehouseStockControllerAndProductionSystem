using Krop.DTO.Dtos.Departments;

namespace Krop.ViewModel.ViewModel.Departments
{
    public record DeleteDepartmentVM
    {
        public List<GetDepartmentComboBoxDTO>? GetDepartmentComboBoxDTO { get; init; }
        public Guid? Id { get; init; }
    }
}
