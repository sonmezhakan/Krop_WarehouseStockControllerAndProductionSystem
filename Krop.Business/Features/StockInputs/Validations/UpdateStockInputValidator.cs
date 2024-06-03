using FluentValidation;
using Krop.Business.Features.StockInputs.Constants;
using Krop.DTO.Dtos.StockInputs;

namespace Krop.Business.Features.StockInputs.Validation
{
    public class UpdateStockInputValidator:AbstractValidator<UpdateStockInputDTO>
    {
        public UpdateStockInputValidator()
        {
            RuleFor(x => x.ProductId)
                .NotNull().WithMessage(StockInputMessages.ProductNotNull)
                .NotEmpty().WithMessage(StockInputMessages.ProductNotNull);

            RuleFor(x => x.BranchId)
                .NotNull().WithMessage(StockInputMessages.BranchNotNull)
                .NotEmpty().WithMessage(StockInputMessages.BranchNotNull);

            RuleFor(x => x.AppUserId)
                .NotEmpty().WithMessage(StockInputMessages.EmployeeNotNull)
                .NotNull().WithMessage(StockInputMessages.EmployeeNotNull);

            RuleFor(x => x.InvoiceNumber)
                .MaximumLength(32).WithMessage(StockInputMessages.InvoiceNumberMaxLenght);

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage(StockInputMessages.DescriptionMaxLenght);

            RuleFor(x => x.Quantity)
                .InclusiveBetween(1, 2147483647).WithMessage(StockInputMessages.QuantityMaxLenght);
        }
    }
}
