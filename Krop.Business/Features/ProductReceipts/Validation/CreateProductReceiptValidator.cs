using FluentValidation;
using Krop.Business.Features.ProductReceipts.Constants;
using Krop.DTO.Dtos.ProductReceipts;

namespace Krop.Business.Features.ProductReceipts.Validation
{
    public class CreateProductReceiptValidator:AbstractValidator<CreateProductReceiptDTO>
    {
        public CreateProductReceiptValidator()
        {
            RuleFor(x => x.ProduceProductId)
                .NotEmpty().WithMessage(ProductReceiptMessages.ProduceProductIdNotNull)
                .NotNull().WithMessage(ProductReceiptMessages.ProduceProductIdNotNull);
            
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage(ProductReceiptMessages.ProductIdNotNull)
                .NotNull().WithMessage(ProductReceiptMessages.ProductIdNotNull);

            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage(ProductReceiptMessages.QuantityNotNull)
                .NotNull().WithMessage(ProductReceiptMessages.QuantityNotNull);
        }
    }
}
