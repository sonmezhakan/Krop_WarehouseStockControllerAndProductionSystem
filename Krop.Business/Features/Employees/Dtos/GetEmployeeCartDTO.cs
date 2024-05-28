namespace Krop.Business.Features.Employees.Dtos
{
    public record class GetEmployeeCartDTO
    {
        public Guid AppUserId { get; init; }
        public string DepartmentName { get; init; }
        public string BranchName { get; init; }
        public DateTime StartDateOfWork { get; init; }
        public DateTime EndDateOfWork { get; init; }
        public decimal Salary { get; init; }
        public bool WorkingStatu { get; init; }
    }
}
