﻿namespace Krop.DTO.Dtos.Employees
{
    public record  CreateEmployeeDTO
    {
        public Guid AppUserId{ get; init; }
        public Guid? DepartmentId{ get; init; }
        public Guid? BranchId{ get; init; }
        public DateTime? StartDateOfWork{ get; init; }
        public DateTime? EndDateOfWork{ get; init; }
        public decimal? Salary{ get; init; }
        public bool? WorkingStatu{ get; init; }
    }
}
