using FluentValidation;
using Krop.Business.Features.Employees.Constants;
using Krop.DTO.Dtos.Employees;

namespace Krop.Business.Features.Employees.Validations
{
    public class CreateEmployeeValidator:AbstractValidator<CreateEmployeeDTO>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.AppUserId)
                .NotEmpty().WithMessage(EmployeeMessages.EmployeeAppUserIdNotNull)
                .NotNull().WithMessage(EmployeeMessages.EmployeeAppUserIdNotNull);

            RuleFor(x => x.BranchId)
                .NotEmpty().WithMessage(EmployeeMessages.EmployeeBranchIdNotNull)
                .NotNull().WithMessage(EmployeeMessages.EmployeeBranchIdNotNull);

            RuleFor(x => x.DepartmentId)
                .NotEmpty().WithMessage(EmployeeMessages.EmployeeDepartmentIdNotNull)
                .NotNull().WithMessage(EmployeeMessages.EmployeeDepartmentIdNotNull);
        }
    }
}
