namespace Krop.Business.Features.Departments.Dtos
{
    public record class GetDepartmentComboBoxDTO
    {
        public Guid Id { get; set; }
        public string DepartmentName { get; set; }
    }
}
