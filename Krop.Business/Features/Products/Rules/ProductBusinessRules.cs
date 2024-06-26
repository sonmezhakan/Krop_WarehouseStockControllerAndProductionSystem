﻿using Krop.Business.Features.Products.Constants;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
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
