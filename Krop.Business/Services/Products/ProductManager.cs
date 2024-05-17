using AutoMapper;
using Krop.Business.Features.Products.Dtos;
using Krop.Business.Features.Products.ExceptionHelpers;
using Krop.Business.Features.Products.Rules;
using Krop.Business.Services.Stocks;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Krop.Business.Services.Products
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ProductBusinessRules _productBusinessRules;
        private readonly ProductExceptionHelper _productExceptionHelper;
        private readonly IStockService _stockService;

        public ProductManager(IProductRepository productRepository, IMapper mapper, ProductBusinessRules productBusinessRules, ProductExceptionHelper productExceptionHelper, IStockService stockService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productBusinessRules = productBusinessRules;
            _productExceptionHelper = productExceptionHelper;
            _stockService = stockService;
        }

        #region Add
        public async Task<bool> AddAsync(CreateProductDTO createProductDTO)
        {
            await _productBusinessRules.ProductNameCannotBeDuplicatedWhenInserted(createProductDTO.ProductName);//ProductName Rule
            await _productBusinessRules.ProductCodeCannotBeDuplicatedWhenInserted(createProductDTO.ProductCode);//ProductCode Rule

            Product product = _mapper.Map<Product>(createProductDTO);
            product.Stocks = await _stockService.NewProductAddedBranchAsync(product.Id);//Gelen stock listesini product.Stocks aktarıyoruz

            return await _productRepository.AddAsync(product);
        }

        public async Task<bool> AddRangeAsync(List<CreateProductDTO> createProductDTOs)
        {
            createProductDTOs.ForEach(async p =>
            {
                await _productBusinessRules.ProductNameCannotBeDuplicatedWhenInserted(p.ProductName);//ProductName Rule
                await _productBusinessRules.ProductCodeCannotBeDuplicatedWhenInserted(p.ProductCode);//ProductCode Rule
            });

            List<Product> products = _mapper.Map<List<Product>>(createProductDTOs);

            //Productlarda dönerek gelen stock listesini Product.Stocks a aktarıyoruz.
            products.ForEach(async p =>
            {
                p.Stocks = await _stockService.NewProductAddedBranchAsync(p.Id);
            });

            return await _productRepository.AddRangeAsync(products);
        }
        #endregion
        #region Update
        public async Task<bool> UpdateAsync(UpdateProductDTO updateProductDTO)
        {
            Product product = await _productRepository.FindAsync(updateProductDTO.Id);
            if (product is null)
                _productExceptionHelper.ThrowProductNotFound();

            await _productBusinessRules.ProductNameCannotBeDuplicatedWhenUpdated(product.ProductName, updateProductDTO.ProductName);//ProductName Rule
            await _productBusinessRules.ProductCodeCannotBeDuplicatedWhenUpdated(product.ProductCode, updateProductDTO.ProductCode);//ProductCode Rule

            product = _mapper.Map(updateProductDTO, product);

            return await _productRepository.UpdateAsync(product);
        }

        public async Task<bool> UpdateRangeAsync(List<UpdateProductDTO> updateProductDTOs)
        {
            updateProductDTOs.ForEach(async p =>
            {
                Product product = await _productRepository.FindAsync(p.Id);
                if (product is null)
                    _productExceptionHelper.ThrowProductNotFound();

                await _productBusinessRules.ProductNameCannotBeDuplicatedWhenUpdated(product.ProductName, p.ProductName);//ProductName Rule
                await _productBusinessRules.ProductCodeCannotBeDuplicatedWhenUpdated(product.ProductCode, p.ProductCode);//ProductCode Rule
            });

            List<Product> products = _mapper.Map<List<Product>>(updateProductDTOs);

            return await _productRepository.UpdateRangeAsync(products);
        }
        #endregion
        #region Delete
        public async Task<bool> DeleteAsync(Guid id)
        {
            Product product = await _productRepository.FindAsync(id);
            if (product is null)
                _productExceptionHelper.ThrowProductNotFound();

            //Eğer ürünler stokdan silinir ise ürünü de sil
            if (await _stockService.ProductDeletedBranchAsync(id))
                return await _productRepository.DeleteAsync(product);

            return false;
        }

        public async Task<bool> DeleteRangeAsync(List<Guid> ids)
        {
            List<Product> products = new();

            ids.ForEach(async p =>
            {
                Product product = await _productRepository.FindAsync(p);
                if (product is null)
                    _productExceptionHelper.ThrowProductNotFound();

                products.Add(product);
            });

            //Eğer ürünler stokdan silinir ise ürünü de sil
            if (await _stockService.ProductDeletedRangeBranchAsync(ids))
                return await _productRepository.DeleteRangeAsync(products);

            return false;
        }
        #endregion
        #region Listed
        public async Task<IEnumerable<GetProductDTO>> GetAllAsync()
        {
            var result = await _productRepository.GetAllAsync(includeProperties:new Expression<Func<Product, object>>[]
            {
                c=>c.Category,
                b=>b.Brand//Include
            });

            List<GetProductDTO> products = _mapper.Map<List<GetProductDTO>>(result);

            return products;
        }
        #endregion
        #region Search
        public async Task<GetProductDTO> GetByIdAsync(Guid id)
        {
            Product product = await _productRepository.FindAsync(id);

            return _mapper.Map<GetProductDTO>(product);
        }
        #endregion    
    }
}
