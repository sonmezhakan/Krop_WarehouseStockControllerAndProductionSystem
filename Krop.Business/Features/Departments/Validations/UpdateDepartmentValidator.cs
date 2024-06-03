using FluentValidation;
using Krop.Business.Features.Departments.Constants;
using Krop.DTO.Dtos.Departments;

namespace Krop.Business.Features.Departments.Validations
{
    public class UpdateDepartmentValidator : AbstractValidator<UpdateDepartmentDTO>
    {
        public UpdateDepartmentValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage(DepartmentMessages.DepartmentIdNotEmptyAndNull)
                .NotEmpty().WithMessage(DepartmentMessages.DepartmentIdNotEmptyAndNull);

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
