namespace Krop.DTO.Dtos.Departments
{
    public record  UpdateDepartmentDTO
    {
        public Guid Id{ get; init; }
        public string DepartmentName{ get; init; }
        public string Description{ get; init; }
    }
}
