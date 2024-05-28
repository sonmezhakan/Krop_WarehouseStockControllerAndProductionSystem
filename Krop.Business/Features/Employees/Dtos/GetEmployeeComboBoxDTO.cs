namespace Krop.Business.Features.Employees.Dtos
{
    public record class GetEmployeeComboBoxDTO
    {
        public Guid AppUserId { get; set; }
        public string UserName { get; set; }
    }
}
