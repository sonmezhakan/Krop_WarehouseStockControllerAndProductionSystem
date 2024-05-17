using Krop.Business.Features.Products.ExceptionHelpers;
using Krop.DataAccess.Repositories.Abstracts;

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
