namespace Krop.DTO.Dtos.Employees
{
    public record  GetEmployeeComboBoxDTO
    {
        public Guid AppUserId{ get; init; }
        public string UserName{ get; init; }
    }
}
