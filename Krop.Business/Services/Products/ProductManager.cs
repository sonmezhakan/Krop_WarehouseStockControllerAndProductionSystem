using AutoMapper;
using Krop.Business.Exceptions.Middlewares.Transaction;
using Krop.Business.Features.Products.Constants;
using Krop.Business.Features.Products.Rules;
using Krop.Business.Features.Products.Validations;
using Krop.Business.Services.Stocks;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Helpers.CacheHelpers;
using Krop.Common.Utilits.Business;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DataAccess.UnitOfWork;
using Krop.DTO.Dtos.Products;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace Krop.Business.Services.Products
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ProductBusinessRules _productBusinessRules;
        private readonly IStockService _stockService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheHelper _cacheHelper;

        public ProductManager(IProductRepository productRepository, IMapper mapper, ProductBusinessRules productBusinessRules, IStockService stockService, IUnitOfWork unitOfWork, ICacheHelper cacheHelper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productBusinessRules = productBusinessRules;
            _stockService = stockService;
            _unitOfWork = unitOfWork;
            _cacheHelper = cacheHelper;
        }

        #region Add 
        [TransactionScope]
        [ValidationAspect(typeof(CreateProductValidator))]
        public async Task<IResult> AddAsync(CreateProductDTO createProductDTO)
        {
            var result = BusinessRules.Run(
                await _productBusinessRules.ProductNameCannotBeDuplicatedWhenInserted(createProductDTO.ProductName),
                await _productBusinessRules.ProductCodeCannotBeDuplicatedWhenInserted(createProductDTO.ProductCode));
            if (!result.Success)
                return result;

            Product product = _mapper.Map<Product>(createProductDTO);
            await _stockService.NewProductAddedBranchAsync(product.Id);

            await _productRepository.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                ProductCacheKeys.GetAllAsync,
                ProductCacheKeys.GetAllComboBoxAsync
            });
            return new SuccessResult();
        }
        #endregion
        #region Update     
        [TransactionScope]
        [ValidationAspect(typeof(UpdateProductValidator))]
        public async Task<IResult> UpdateAsync(UpdateProductDTO updateProductDTO)
        {
            var getProduct = await _productRepository.GetAsync(x => x.Id == updateProductDTO.Id);
            if (getProduct is null)
                return new ErrorResult(StatusCodes.Status404NotFound, ProductMessages.ProductNotFound);

            var result = BusinessRules.Run(
                 await _productBusinessRules.ProductNameCannotBeDuplicatedWhenInserted(updateProductDTO.ProductName),
                 await _productBusinessRules.ProductCodeCannotBeDuplicatedWhenInserted(updateProductDTO.ProductCode));
            if (!result.Success)
                return result;

            Product product = _mapper.Map(updateProductDTO, getProduct);

            await _productRepository.UpdateAsync(product);
            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                ProductCacheKeys.GetAllAsync,
                ProductCacheKeys.GetAllComboBoxAsync,
                $"{ProductCacheKeys.GetByIdAsync}{updateProductDTO.Id}"
            });
            return new SuccessResult();
        }

        #endregion
        #region Delete
        [TransactionScope]
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var getProduct = await _productRepository.GetAsync(x => x.Id == id);
            if (getProduct is null)
                return new ErrorResult(StatusCodes.Status404NotFound, ProductMessages.ProductNotFound);

            //Eğer ürünler stokdan silinir ise ürünü de sil
            await _stockService.ProductDeletedBranchAsync(id);//şubeki ürünü sil
            await _productRepository.DeleteAsync(getProduct);
            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                ProductCacheKeys.GetAllAsync,
                ProductCacheKeys.GetAllComboBoxAsync,
                $"{ProductCacheKeys.GetByIdAsync}{id}"
            });
            return new SuccessResult();
        }
        #endregion
        #region Listed
        public async Task<IDataResult<IEnumerable<GetProductListDTO>>> GetAllAsync()
        {
            IEnumerable<GetProductListDTO>? getProductListDTOs = await _cacheHelper.GetOrAddListAsync(
                ProductCacheKeys.GetAllAsync,
                async () =>
                {
                    var result = await _productRepository.GetAllWithIncludesAsync();
                    return result is null ? null : _mapper.Map<IEnumerable<GetProductListDTO>>(result);
                },
                60
                );
            return new SuccessDataResult<IEnumerable<GetProductListDTO>>(getProductListDTOs);
        }

        public async Task<IDataResult<IEnumerable<GetProductComboBoxDTO>>> GetAllComboBoxAsync()
        {
            IEnumerable<GetProductComboBoxDTO>? getProductComboBoxDTOs = await _cacheHelper.GetOrAddListAsync(
                ProductCacheKeys.GetAllComboBoxAsync,
                async () =>
                {
                    var result = await _productRepository.GetAllComboBoxAsync();
                    return result is null ? null : _mapper.Map<IEnumerable<GetProductComboBoxDTO>>(result);
                },
                60
                );

            return new SuccessDataResult<IEnumerable<GetProductComboBoxDTO>>(getProductComboBoxDTOs);
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetProductDTO>> GetByIdAsync(Guid id)
        {
            GetProductDTO? getProductDTO = await _cacheHelper.GetOrAddAsync(
                $"{ProductCacheKeys.GetByIdAsync}{id}",
                async () =>
                {
                    var result = await _productRepository.GetAsync(x => x.Id == id);
                    return result is null ? null : _mapper.Map<GetProductDTO>(result);
                },
                60
                );
            
            return getProductDTO is null ?
                new ErrorDataResult<GetProductDTO>(StatusCodes.Status404NotFound, ProductMessages.ProductNotFound):
                new SuccessDataResult<GetProductDTO>(getProductDTO);
        }

        public async Task<IDataResult<GetProductCartDTO>> GetByIdCartAsync(Guid Id)
        {
            GetProductCartDTO? getProductCartDTO = await _cacheHelper.GetOrAddAsync(
                $"{ProductCacheKeys.GetByIdAsync}{Id}",
                async () =>
                {
                    var result = await _productRepository.GetAsync(x => x.Id == Id,
                     includeProperties: new Expression<Func<Product, object>>[]
                    {
                          c=>c.Category,
                          b=>b.Brand
                    });
                    return result is null ? null : _mapper.Map<GetProductCartDTO>(result);
                },
                60
                );
            return getProductCartDTO is null ?
                new ErrorDataResult<GetProductCartDTO>(StatusCodes.Status404NotFound, ProductMessages.ProductNotFound) :
                 new SuccessDataResult<GetProductCartDTO>(getProductCartDTO);
        }
        #endregion
    }
}
