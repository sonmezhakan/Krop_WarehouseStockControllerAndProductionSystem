using FluentValidation;
using Krop.Business.Features.Departments.Constants;
using Krop.Business.Features.Departments.Dtos;

namespace Krop.Business.Features.Departments.Validations
{
    public class CreateDepartmentValidator:AbstractValidator<CreateDepartmentDTO>
    {
        public CreateDepartmentValidator()
        {
            RuleFor(x => x.DepartmentName)
                .NotEmpty().WithMessage(DepartmentMessages.DepartmentNameNotNull)
                .NotNull().WithMessage(DepartmentMessages.DepartmentNameNotNull)
                .MinimumLength(3).WithMessage(DepartmentMessages.DepartmentNameMinAndMaxLenght)
                .MaximumLength(255).WithMessage(DepartmentMessages.DepartmentNameMinAndMaxLenght);

            RuleFor(x => x.Description)
                .MaximumLength(255).WithMessage(DepartmentMessages.DepartmentDescriptionMaxLenght);
        }
    }
}
