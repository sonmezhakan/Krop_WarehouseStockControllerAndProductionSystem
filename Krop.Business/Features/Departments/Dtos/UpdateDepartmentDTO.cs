namespace Krop.Business.Features.Departments.Dtos
{
    public record class UpdateDepartmentDTO
    {
        public Guid Id { get; init; }
        public string DepartmentName { get; init; }
        public string Description { get; init; }
    }
}
