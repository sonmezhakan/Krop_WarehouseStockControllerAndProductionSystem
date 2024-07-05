using AutoMapper;
using Krop.Business.Features.ProductReceipts.Constants;
using Krop.Business.Features.ProductReceipts.Rules;
using Krop.Business.Features.ProductReceipts.Validation;
using Krop.Business.Features.Products.Validations;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Helpers.CacheHelpers;
using Krop.Common.Utilits.Business;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DataAccess.UnitOfWork;
using Krop.DTO.Dtos.ProductReceipts;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace Krop.Business.Services.ProductReceipts
{
    public class ProductReceiptManager : IProductReceiptService
    {
        private readonly IProductReceiptRepository _productReceiptRepository;
        private readonly IMapper _mapper;
        private readonly ProductReceiptBusinessRules _productReceiptBusinessRule;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheHelper _cacheHelper;

        public ProductReceiptManager(IProductReceiptRepository productReceiptRepository, IMapper mapper, ProductReceiptBusinessRules productReceiptBusinessRule, IUnitOfWork unitOfWork, ICacheHelper cacheHelper)
        {
            _productReceiptRepository = productReceiptRepository;
            _mapper = mapper;
            _productReceiptBusinessRule = productReceiptBusinessRule;
            _unitOfWork = unitOfWork;
            _cacheHelper = cacheHelper;
        }
        #region Add
        [ValidationAspect(typeof(CreateProductReceiptValidator))]
        public async Task<IResult> AddAsync(CreateProductReceiptDTO createProductReceiptDTO)
        {
            var result = BusinessRules.Run(await _productReceiptBusinessRule.ProductReceiptCannotBeDuplicatedWhenInserted(createProductReceiptDTO.ProduceProductId, createProductReceiptDTO.ProductId));//Business Rule
            if (!result.Success)
                return result;

            await _productReceiptRepository.AddAsync(
               _mapper.Map<ProductReceipt>(createProductReceiptDTO));

            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                $"{ProductReceiptCacheKeys.GetByProduceIdAsync}{createProductReceiptDTO.ProduceProductId}"
            });
            return new SuccessResult();
        }
        #endregion
        #region Update
        [ValidationAspect(typeof(UpdateProductReceiptValidator))]
        public async Task<IResult> UpdateAsync(UpdateProductReceiptDTO updateProductReceiptDTO)
        {
            var getProductReceipt = await _productReceiptRepository.GetAsync(x => x.ProduceProductId == updateProductReceiptDTO.ProduceProductId && x.ProductId == updateProductReceiptDTO.ProductId);
            if (getProductReceipt is null)
                return new ErrorResult(StatusCodes.Status404NotFound, ProductReceiptMessages.ProductreceiptNotFound);

            var result = BusinessRules.Run(await _productReceiptBusinessRule.ProductReceiptCannotBeDuplicatedWhenUpdated(updateProductReceiptDTO.ProduceProductId, getProductReceipt.ProductId, updateProductReceiptDTO.ProductId));//Business Rule
            if (!result.Success)
                return result;

            ProductReceipt productReceipt = _mapper.Map(updateProductReceiptDTO, getProductReceipt);

            await _productReceiptRepository.UpdateAsync(productReceipt);

            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                $"{ProductReceiptCacheKeys.GetByProduceIdAsync}{getProductReceipt.ProduceProductId}",
                $"{ProductReceiptCacheKeys.GetByProduceIdAsync}{updateProductReceiptDTO.ProduceProductId}",
                $"IProductReceiptService.GetByProduceProductIdAndProductIdAsync/produceProductId={updateProductReceiptDTO.ProduceProductId}/productId={updateProductReceiptDTO.ProductId}"
            });
            return new SuccessResult();
        }
        #endregion
        #region HardDeleted
        public async Task<IResult> DeleteAsync(Guid produceProductId, Guid productId)
        {
            var getProductReceipt = await _productReceiptRepository.GetAsync(x => x.ProduceProductId == produceProductId && x.ProductId == productId);
            if (getProductReceipt is null)
                return new ErrorResult(StatusCodes.Status404NotFound, ProductReceiptMessages.ProductreceiptNotFound);

            await _productReceiptRepository.HardDeleteAsync(getProductReceipt);

            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                $"{ProductReceiptCacheKeys.GetByProduceIdAsync}{produceProductId}",
                $"IProductReceiptService.GetByProduceProductIdAndProductIdAsync/produceProductId={produceProductId}/productId={productId}"
            });
            return new SuccessResult();
        }
        #endregion
        #region Listed
        public async Task<IDataResult<IEnumerable<GetProductReceiptListDTO>>> GetByProduceIdAsync(Guid produceProductId)
        {
            IEnumerable<GetProductReceiptListDTO>? getProductReceiptListDTOs = await _cacheHelper.GetOrAddListAsync(
                $"{ProductReceiptCacheKeys.GetByProduceIdAsync}{produceProductId}",
                async () =>
                {
                    var result = await _productReceiptRepository.GetAllWithIncludesAsync(predicate: x => x.ProduceProductId == produceProductId,
                    includeProperties: new Expression<Func<ProductReceipt, object>>[]
                    {
                       p=>p.Product
                    });
                    return result is null ? null : _mapper.Map<IEnumerable<GetProductReceiptListDTO>>(result);
                },
                60
                );

            return new SuccessDataResult<IEnumerable<GetProductReceiptListDTO>>(getProductReceiptListDTOs);
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetProductReceiptDTO>> GetByProduceProductIdAndProductIdAsync(Guid produceProductId, Guid productId)
        {
            GetProductReceiptDTO? getProductReceiptDTO = await _cacheHelper.GetOrAddAsync(
                $"IProductReceiptService.GetByProduceProductIdAndProductIdAsync/produceProductId={produceProductId}/productId={productId}",
                async () =>
                {
                    var result = await _productReceiptRepository.GetIcludesAsync(predicate: x => x.ProduceProductId == produceProductId && x.ProductId == productId,
                        includeProperties: new Expression<Func<ProductReceipt, object>>[]
                        {
                            p=>p.Product
                        });
                    return result is null ? null : _mapper.Map<GetProductReceiptDTO>(result);
                },
                15
                );
            return getProductReceiptDTO is null ?
                new ErrorDataResult<GetProductReceiptDTO>(StatusCodes.Status404NotFound, ProductReceiptMessages.ProductreceiptNotFound) :
                new SuccessDataResult<GetProductReceiptDTO>(getProductReceiptDTO);
        }
    }
    #endregion
}
