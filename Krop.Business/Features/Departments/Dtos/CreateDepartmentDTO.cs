namespace Krop.Business.Features.Departments.Dtos
{
    public record class CreateDepartmentDTO
    {
        public string DepartmentName { get; init; }
        public string Description { get; init; }
    }
}
