using Krop.Business.Features.Products.Constants;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;

namespace Krop.Business.Features.Products.Rules
{
    public class ProductBusinessRules
    {
        private readonly IProductRepository _productRepository;

        public ProductBusinessRules(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IDataResult<Product>> CheckByProductId(Guid id)
        {
            var result = await _productRepository.GetAsync(p => p.Id == id);
            if (result is null)
                return new ErrorDataResult<Product>(StatusCodes.Status404NotFound, ProductMessages.ProductNotFound);

            return new SuccessDataResult<Product>(result);
        }
        public async Task<IDataResult<Product>> CheckByProductName(string productName)
        {
            var result = await _productRepository.GetAsync(p=>p.ProductCode == productName);
            if (result is null)
                return new ErrorDataResult<Product>(StatusCodes.Status404NotFound, ProductMessages.ProductNotFound);

            return new SuccessDataResult<Product>(result);
        }

        public async Task<IResult> ProductNameCannotBeDuplicatedWhenInserted(string productName)
        {
            bool result = await _productRepository.AnyAsync(p => p.ProductName == productName);

            if (result)
                return new ErrorResult(StatusCodes.Status400BadRequest, ProductMessages.ProductNameExists);

            return new SuccessResult();
        }
        public async Task<IResult> ProductNameCannotBeDuplicatedWhenUpdated(string oldProductName,string newProductName)
        {
            if(oldProductName != newProductName)
            {
                bool result = await _productRepository.AnyAsync(p => p.ProductName == newProductName);

                if (result)
                    return new ErrorResult(StatusCodes.Status400BadRequest, ProductMessages.ProductNameExists);
            }
            return new SuccessResult();
        }
        public async Task<IResult> ProductCodeCannotBeDuplicatedWhenInserted(string productCode)
        {
            bool result = await _productRepository.AnyAsync(p => p.ProductCode == productCode);

            if (result)
                return new ErrorResult(StatusCodes.Status400BadRequest, ProductMessages.ProductCodeNotNull);

            return new SuccessResult();
        }
        public async Task<IResult> ProductCodeCannotBeDuplicatedWhenUpdated(string oldProductCode,string newProductCode)
        {
            if(oldProductCode != newProductCode)
            {
                bool result = await _productRepository.AnyAsync(p=>p.ProductCode == newProductCode);

                if (result)
                    return new ErrorResult(StatusCodes.Status400BadRequest, ProductMessages.ProductCodeNotNull);
            }
            return new SuccessResult();
        }
    }
}
