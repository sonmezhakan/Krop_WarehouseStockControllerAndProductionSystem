using FluentValidation;
using Krop.Business.Features.ProductNotifications.Constants;
using Krop.DTO.Dtos.ProductNotifications;

namespace Krop.Business.Features.ProductNotifications.Validations
{
    public class CreateProductNotificationValidator:AbstractValidator<CreateProductNotificationDTO>
    {
        public CreateProductNotificationValidator()
        {
            RuleFor(x => x.BranchId)
                .NotEmpty().WithMessage(ProductNotificationMessages.BranchNotNull)
                .NotNull().WithMessage(ProductNotificationMessages.BranchNotNull);

            RuleFor(x => x.ProductId)
                .NotNull().WithMessage(ProductNotificationMessages.ProductNotNull)
                .NotEmpty().WithMessage(ProductNotificationMessages.ProductNotNull);

            RuleFor(x => x.SenderEmployeeId)
                .NotEmpty().WithMessage(ProductNotificationMessages.SenderEmployeeNotNull)
                .NotNull().WithMessage(ProductNotificationMessages.SenderEmployeeNotNull);

            RuleFor(x => x.SentEmployeeId)
                .NotEmpty().WithMessage(ProductNotificationMessages.SentEmployeeNotNull)
                .NotNull().WithMessage(ProductNotificationMessages.SentEmployeeNotNull);

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage(ProductNotificationMessages.DescriptionMaxLenght);
        }
    }
}
