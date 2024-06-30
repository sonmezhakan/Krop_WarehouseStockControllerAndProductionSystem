namespace Krop.DTO.Dtos.Employees
{
    public record  GetEmployeeListDTO
    {
        public Guid AppUserId{ get; init; }
        public string Username{ get; init; }
        public string FirstName{ get; init; }
        public string LastName{ get; init; }
        public string DepartmentName{ get; init; }
        public string BranchName{ get; init; }
        public decimal Salary{ get; init; }
        public string NationalNumber{ get; init; }
        public string PhoneNumber{ get; init; }
        public string Email{ get; init; }
        public string Country{ get; init; }
        public string City{ get; init; }
        public string Adress{ get; init; }
        public DateTime StartDateOfWork{ get; init; }
        public DateTime EndDateOfWork{ get; init; }
        public bool WorkingStatu{ get; init; }
    }
}
