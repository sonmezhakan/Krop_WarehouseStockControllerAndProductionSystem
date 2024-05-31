using FluentValidation;
using Krop.Business.Features.StockTransfers.Constants;
using Krop.Business.Features.StockTransfers.Dtos;

namespace Krop.Business.Features.StockTransfers.Validations
{
    public class CreateStockTransferValidator : AbstractValidator<CreateStockTransferDTO>
    {
        public CreateStockTransferValidator()
        {
            RuleFor(x => x.SenderBranchId)
                .NotEmpty().WithMessage(StockTransferMessages.SenderBranchNotNull)
                .NotNull().WithMessage(StockTransferMessages.SenderBranchNotNull);

            RuleFor(x => x.SentBranchId)
                .NotEmpty().WithMessage(StockTransferMessages.SentBranchNotNull)
                .NotNull().WithMessage(StockTransferMessages.SentBranchNotNull);

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage(StockTransferMessages.ProductNotNull)
                .NotNull().WithMessage(StockTransferMessages.ProductNotNull);

            RuleFor(x => x.TransactorAppUserId)
                .NotEmpty().WithMessage(StockTransferMessages.SenderAppUserNotNull)
                .NotNull().WithMessage(StockTransferMessages.SenderAppUserNotNull);

            RuleFor(x => x.InvoiceNumber)
                .MaximumLength(32).WithMessage(StockTransferMessages.InoviceNumberMaxLenght);

            RuleFor(x => x.Quantity)
                .NotNull().WithMessage(StockTransferMessages.QuantityNotNull)
                .InclusiveBetween(1, 2147483647).WithMessage(StockTransferMessages.QuantityMaxLenght);

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage(StockTransferMessages.DescriptionMaxLenght);
        }
    }
}
