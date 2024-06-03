namespace Krop.DTO.Dtos.Departments
{
    public record class GetDepartmentComboBoxDTO
    {
        public Guid Id { get; set; }
        public string DepartmentName { get; set; }
    }
}
