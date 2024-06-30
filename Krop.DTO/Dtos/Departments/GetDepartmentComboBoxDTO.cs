namespace Krop.DTO.Dtos.Departments
{
    public record  GetDepartmentComboBoxDTO
    {
        public Guid Id{ get; init; }
        public string DepartmentName{ get; init; }
    }
}
