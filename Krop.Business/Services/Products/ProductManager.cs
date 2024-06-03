using AutoMapper;
using Krop.Business.Features.Products.Rules;
using Krop.Business.Features.Products.Validations;
using Krop.Business.Services.Stocks;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DTO.Dtos.Products;
using Krop.Entities.Entities;
using System.Linq.Expressions;

namespace Krop.Business.Services.Products
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ProductBusinessRules _productBusinessRules;
        private readonly IStockService _stockService;

        public ProductManager(IProductRepository productRepository, IMapper mapper, ProductBusinessRules productBusinessRules, IStockService stockService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productBusinessRules = productBusinessRules;
            _stockService = stockService;
        }

        #region Add
        [ValidationAspect(typeof(CreateProductValidator))]
        public async Task<IResult> AddAsync(CreateProductDTO createProductDTO)
        {
            await _productBusinessRules.ProductNameCannotBeDuplicatedWhenInserted(createProductDTO.ProductName);//ProductName Rule
            await _productBusinessRules.ProductCodeCannotBeDuplicatedWhenInserted(createProductDTO.ProductCode);//ProductCode Rule

            Product product = _mapper.Map<Product>(createProductDTO);
            product.Stocks = await _stockService.NewProductAddedBranchAsync(product.Id);//Gelen stock listesini product.Stocks aktarıyoruz

            await _productRepository.AddAsync(product);
            return new SuccessResult();
        }
        [ValidationAspect(typeof(CreateProductValidator))]
        public async Task<IResult> AddRangeAsync(List<CreateProductDTO> createProductDTOs)
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

            await _productRepository.AddRangeAsync(products);
            return new SuccessResult();
        }
        #endregion
        #region Update
        [ValidationAspect(typeof(UpdateProductValidator))]
        public async Task<IResult> UpdateAsync(UpdateProductDTO updateProductDTO)
        {
            var product = await _productBusinessRules.CheckByProductId(updateProductDTO.Id);//ProductId Rule

            await _productBusinessRules.ProductNameCannotBeDuplicatedWhenUpdated(product.ProductName, updateProductDTO.ProductName);//ProductName Rule
            await _productBusinessRules.ProductCodeCannotBeDuplicatedWhenUpdated(product.ProductCode, updateProductDTO.ProductCode);//ProductCode Rule

            product = _mapper.Map(updateProductDTO, product);

            await _productRepository.UpdateAsync(product);
            return new SuccessResult();
        }
        [ValidationAspect(typeof(UpdateProductValidator))]
        public async Task<IResult> UpdateRangeAsync(List<UpdateProductDTO> updateProductDTOs)
        {
            updateProductDTOs.ForEach(async p =>
            {
                var product = await _productBusinessRules.CheckByProductId(p.Id);//ProductId Rule

                await _productBusinessRules.ProductNameCannotBeDuplicatedWhenUpdated(product.ProductName, p.ProductName);//ProductName Rule
                await _productBusinessRules.ProductCodeCannotBeDuplicatedWhenUpdated(product.ProductCode, p.ProductCode);//ProductCode Rule
            });

            await _productRepository.UpdateRangeAsync(
                _mapper.Map<List<Product>>(updateProductDTOs));

            return new SuccessResult();
        }
        #endregion
        #region Delete
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var product = await _productBusinessRules.CheckByProductId(id);

            //Eğer ürünler stokdan silinir ise ürünü de sil
            await _stockService.ProductDeletedBranchAsync(id);//şubeki ürünü sil
            await _productRepository.DeleteAsync(product);

            return new SuccessResult(); ;
        }

        public async Task<IResult> DeleteRangeAsync(List<Guid> ids)
        {
            List<Product> products = new();

            ids.ForEach(async p =>
            {
                var product = await _productBusinessRules.CheckByProductId(p);

                products.Add(product);
            });

            await _stockService.ProductDeletedRangeBranchAsync(ids);//şubelerdeki ürünü sil
            await _productRepository.DeleteRangeAsync(products);

            return new SuccessResult();
        }
        #endregion
        #region Listed
        public async Task<IDataResult<IEnumerable<GetProductListDTO>>> GetAllAsync()
        {
            var result = await _productRepository.GetAllAsync(includeProperties:new Expression<Func<Product, object>>[]
            {
                c=>c.Category,
                b=>b.Brand//Include
            });

            return new SuccessDataResult<IEnumerable<GetProductListDTO>>(
                _mapper.Map<IEnumerable<GetProductListDTO>>(result));
        }

        public async Task<IDataResult<IEnumerable<GetProductComboBoxDTO>>> GetAllComboBoxAsync()
        {
            var result = await _productRepository.GetAllComboBoxAsync();

            return new SuccessDataResult<IEnumerable<GetProductComboBoxDTO>>(
                _mapper.Map<IEnumerable<GetProductComboBoxDTO>>(result));
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetProductDTO>> GetByIdAsync(Guid id)
        {
            var product = await _productBusinessRules.CheckByProductId(id);

            return new SuccessDataResult<GetProductDTO>(
                _mapper.Map<GetProductDTO>(product));
        }

        public async Task<IDataResult<GetProductCartDTO>> GetByIdCartAsync(Guid Id)
        {
            var result = await _productRepository.GetAsync(x => x.Id == Id,
                includeProperties: new Expression<Func<Product, object>>[]
                {
                    c=>c.Category,
                    b=>b.Brand
                });

            return new SuccessDataResult<GetProductCartDTO>(
                _mapper.Map<GetProductCartDTO>(result));
        }
        #endregion
    }
}
