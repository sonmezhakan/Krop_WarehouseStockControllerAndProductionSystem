namespace Krop.DTO.Dtos.Departments
{
    public record  CreateDepartmentDTO
    {
        public string DepartmentName{ get; init; }
        public string Description{ get; init; }
    }
}
