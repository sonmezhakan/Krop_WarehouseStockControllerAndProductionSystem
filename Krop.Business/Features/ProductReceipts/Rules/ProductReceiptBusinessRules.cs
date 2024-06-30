using Krop.Business.Features.ProductReceipts.Constants;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;

namespace Krop.Business.Features.ProductReceipts.Rules
{
    public class ProductReceiptBusinessRules
    {
        private readonly IProductReceiptRepository _productReceiptRepository;

        public ProductReceiptBusinessRules(IProductReceiptRepository productReceiptRepository)
        {
            _productReceiptRepository = productReceiptRepository;
        }

        public async Task<IResult> ProductReceiptCannotBeDuplicatedWhenInserted(Guid produceProductId,Guid productId)
        {
            if (produceProductId == productId)
                return new ErrorResult(StatusCodes.Status400BadRequest, ProductReceiptMessages.ProductExists);

            var result = await _productReceiptRepository.AnyAsync(x=>x.ProduceProductId == produceProductId && x.ProductId == productId);

            if (result)
                return new ErrorResult(StatusCodes.Status400BadRequest, ProductReceiptMessages.ProductReceiptExists);

            return new SuccessResult();
        }
        public async Task<IResult> ProductReceiptCannotBeDuplicatedWhenUpdated(Guid produceProductId, Guid oldProductId,Guid newProductId)
        {
            if(oldProductId != newProductId)
            {
                if (produceProductId == newProductId)
                    return new ErrorResult(StatusCodes.Status400BadRequest, ProductReceiptMessages.ProductExists);

                var produceProducts = await _productReceiptRepository.GetAllAsync(x => x.ProduceProductId == produceProductId);

                var result = produceProducts.Any(x => x.ProductId == newProductId);

                if (result)
                    return new ErrorResult(StatusCodes.Status400BadRequest, ProductReceiptMessages.ProductReceiptExists); 
            }
            return new SuccessResult();
        }
    }
}
