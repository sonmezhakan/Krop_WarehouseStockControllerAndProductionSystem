using Krop.Business.Features.Products.ExceptionHelpers;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.Business.Features.Products.Rules
{
    public class ProductBusinessRules
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductExceptionHelper _productExceptionHelper;

        public ProductBusinessRules(IProductRepository productRepository,ProductExceptionHelper productExceptionHelper)
        {
            _productRepository = productRepository;
            _productExceptionHelper = productExceptionHelper;
        }
        public async Task<Product> CheckByProductId(Guid id)
        {
            var result = await _productRepository.GetAsync(p => p.Id == id);
            if (result is null)
                _productExceptionHelper.ThrowProductNotFound();

            return result;
        }
        public async Task<Product> CheckByProductName(string productName)
        {
            var result = await _productRepository.GetAsync(p=>p.ProductCode == productName);
            if(result is null)
                _productExceptionHelper.ThrowProductNotFound();

            return result;
        }

        public async Task ProductNameCannotBeDuplicatedWhenInserted(string productName)
        {
            bool result = await _productRepository.AnyAsync(p => p.ProductName == productName);

            if (result)
                _productExceptionHelper.ThrowProductNameExists();
        }
        public async Task ProductNameCannotBeDuplicatedWhenUpdated(string oldProductName,string newProductName)
        {
            if(oldProductName != newProductName)
            {
                bool result = await _productRepository.AnyAsync(p => p.ProductName == newProductName);

                if(result)
                    _productExceptionHelper.ThrowProductNameExists();
            }
        }
        public async Task ProductCodeCannotBeDuplicatedWhenInserted(string productCode)
        {
            bool result = await _productRepository.AnyAsync(p => p.ProductCode == productCode);

            if(result)
                _productExceptionHelper.ThrowProductCodeExists();
        }
        public async Task ProductCodeCannotBeDuplicatedWhenUpdated(string oldProductCode,string newProductCode)
        {
            if(oldProductCode != newProductCode)
            {
                bool result = await _productRepository.AnyAsync(p=>p.ProductCode == newProductCode);

                if(result)
                _productExceptionHelper.ThrowProductCodeExists();
            }
        }
    }
}
