using FluentValidation;
using Krop.Business.Features.Branches.Constants;
using Krop.DTO.Dtos.Branches;

namespace Krop.Business.Features.Branches.Validations
{
    public class CreateBranchValidator:AbstractValidator<CreateBranchDTO>
    {
        public CreateBranchValidator()
        {
            //BranchName
            RuleFor(x => x.BranchName)
                .NotEmpty().WithMessage(BranchMessages.BranchNameNotNull)
                .NotNull().WithMessage(BranchMessages.BranchNameNotNull)
                .MinimumLength(3).WithMessage(BranchMessages.BranchNameMinAndMaxLenght)
                .MaximumLength(255).WithMessage(BranchMessages.BranchNameMinAndMaxLenght);

            //PhoneNumber, Email
            RuleFor(x => x.PhoneNumber)
                .MaximumLength(11).WithMessage(BranchMessages.BranchPhoneNumberMaxLenght);

            RuleFor(x => x.Email)
                .MaximumLength(128).WithMessage(BranchMessages.BranchEmailMaxLenght);

            //Country, City, Address
            RuleFor(x => x.Country)
                .MaximumLength(64) .WithMessage(BranchMessages.BranchCountryMaxLenght);

            RuleFor(x => x.City)
                .MaximumLength(64).WithMessage(BranchMessages.BranchCityMaxLenght);

            RuleFor(x => x.Addres)
                .MaximumLength(255).WithMessage(BranchMessages.BranchAddressMaxLenght);
        }
    }
}
