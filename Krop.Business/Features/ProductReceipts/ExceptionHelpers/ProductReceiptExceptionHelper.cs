using Krop.Business.Exceptions.Types;
using Krop.Business.Features.ProductReceipts.Constants;

namespace Krop.Business.Features.ProductReceipts.ExceptionHelpers
{
    public class ProductReceiptExceptionHelper
    {
        public void ThrowProductReceiptExists() => throw new BusinessException(ProductReceiptMessages.ProductReceiptExists);
        public void ThrowProductReceiptNotFound() => throw new NotFoundException(ProductReceiptMessages.ProductreceiptNotFound);
        public void ThrowProductExists() => throw new BusinessException(ProductReceiptMessages.ProductExists);
    }
}
