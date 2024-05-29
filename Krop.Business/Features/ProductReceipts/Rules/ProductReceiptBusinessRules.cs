using Krop.Business.Features.ProductReceipts.ExceptionHelpers;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.Business.Features.ProductReceipts.Rules
{
    public class ProductReceiptBusinessRules
    {
        private readonly IProductReceiptRepository _productReceiptRepository;
        private readonly ProductReceiptExceptionHelper _productReceiptExceptionHelper;

        public ProductReceiptBusinessRules(IProductReceiptRepository productReceiptRepository,ProductReceiptExceptionHelper productReceiptExceptionHelper)
        {
            _productReceiptRepository = productReceiptRepository;
           _productReceiptExceptionHelper = productReceiptExceptionHelper;
        }

        public async Task ProductReceiptCannotBeDuplicatedWhenInserted(Guid produceProductId,Guid productId)
        {
            if (produceProductId == productId)
                _productReceiptExceptionHelper.ThrowProductExists();

            var result = await _productReceiptRepository.AnyAsync(x=>x.ProduceProductId == produceProductId && x.ProductId == productId);

            if (result)
                _productReceiptExceptionHelper.ThrowProductReceiptExists();      
        }
        public async Task ProductReceiptCannotBeDuplicatedWhenUpdated(Guid produceProductId, Guid oldProductId,Guid newProductId)
        {
            if(oldProductId != newProductId)
            {
                if (produceProductId == newProductId)
                    _productReceiptExceptionHelper.ThrowProductExists();

                var produceProducts = await _productReceiptRepository.GetAllAsync(x => x.ProduceProductId == produceProductId);

                var result = produceProducts.Any(x => x.ProductId == newProductId);

                if (result)
                    _productReceiptExceptionHelper.ThrowProductReceiptExists();
            }
        }
        public async Task<ProductReceipt> CheckProductReceipt(Guid produceProductId, Guid productId)
        {
            var result = await _productReceiptRepository.GetAsync(x => x.ProduceProductId == produceProductId && x.ProductId == productId);

            if (result == null)
                _productReceiptExceptionHelper.ThrowProductReceiptNotFound();

            return result;
        }
    }
}
