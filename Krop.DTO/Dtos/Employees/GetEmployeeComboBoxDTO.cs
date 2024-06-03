namespace Krop.DTO.Dtos.Employees
{
    public record class GetEmployeeComboBoxDTO
    {
        public Guid AppUserId { get; set; }
        public string UserName { get; set; }
    }
}
