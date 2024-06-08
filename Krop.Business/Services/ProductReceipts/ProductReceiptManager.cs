using AutoMapper;
using Krop.Business.Features.ProductReceipts.Rules;
using Krop.Business.Features.ProductReceipts.Validation;
using Krop.Common.Utilits.Business;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DataAccess.UnitOfWork;
using Krop.DTO.Dtos.ProductReceipts;
using Krop.Entities.Entities;
using System.Linq.Expressions;

namespace Krop.Business.Services.ProductReceipts
{
    public class ProductReceiptManager : IProductReceiptService
    {
        private readonly IProductReceiptRepository _productReceiptRepository;
        private readonly IMapper _mapper;
        private readonly ProductReceiptBusinessRules _productReceiptBusinessRule;
        private readonly IUnitOfWork _unitOfWork;

        public ProductReceiptManager(IProductReceiptRepository productReceiptRepository, IMapper mapper, ProductReceiptBusinessRules productReceiptBusinessRule,IUnitOfWork unitOfWork)
        {
            _productReceiptRepository = productReceiptRepository;
            _mapper = mapper;
            _productReceiptBusinessRule = productReceiptBusinessRule;
           _unitOfWork = unitOfWork;
        }
        #region Add
        

        public async Task<IResult> AddAsync(CreateProductReceiptDTO createProductReceiptDTO)
        {
            var result = BusinessRules.Run(await _productReceiptBusinessRule.ProductReceiptCannotBeDuplicatedWhenInserted(createProductReceiptDTO.ProduceProductId, createProductReceiptDTO.ProductId));//Business Rule
            if (!result.Success)
                return result;

            await _productReceiptRepository.AddAsync(
               _mapper.Map<ProductReceipt>(createProductReceiptDTO));

            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult();
        }
        #endregion
        #region Update
        
        public async Task<IResult> UpdateAsync(UpdateProductReceiptDTO updateProductReceiptDTO)
        {
            var getProductReceipt = await _productReceiptBusinessRule.CheckProductReceipt(updateProductReceiptDTO.ProduceProductId, updateProductReceiptDTO.ProductId);
            if (!getProductReceipt.Success)
                return getProductReceipt;

            var result = BusinessRules.Run(await _productReceiptBusinessRule.ProductReceiptCannotBeDuplicatedWhenUpdated(updateProductReceiptDTO.ProduceProductId, getProductReceipt.Data.ProductId, updateProductReceiptDTO.ProductId));//Business Rule
            if (!result.Success)
                return result;

            ProductReceipt productReceipt = _mapper.Map(updateProductReceiptDTO, getProductReceipt.Data);

            await _productReceiptRepository.UpdateAsync(productReceipt);

            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult();
        }
        #endregion
        #region HardDeleted
        public async Task<IResult> DeleteAsync(Guid produceProductId, Guid productId)
        {
            var result = await _productReceiptBusinessRule.CheckProductReceipt(produceProductId, productId);
            if (!result.Success)
                return result;

            await _productReceiptRepository.HardDeleteAsync(result.Data);

            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult();
        }
        #endregion
        #region Listed
        public async Task<IDataResult<IEnumerable<GetProductReceiptListDTO>>> GetAllAsync(Guid produceProductId)
        {
            var result = await _productReceiptRepository.GetAllAsync(predicate: x => x.ProduceProductId == produceProductId,
                includeProperties: new Expression<Func<ProductReceipt, object>>[]
                {
                    p=>p.Product
                });

            return new SuccessDataResult<IEnumerable<GetProductReceiptListDTO>>(_mapper.Map<IEnumerable<GetProductReceiptListDTO>>(result));
        }
        #endregion

        /*public async Task<IDataResult<IEnumerable<GetProductReceiptDTO>>> GetByProduceProductId(Guid produceProductId,Guid branchId)
        {
            var result = await _productReceiptRepository.GetAllAsync(x => x.ProduceProductId == produceProductId,
                includeProperties: new Expression<Func<ProductReceipt, object>>[]
                {
                    x=>x.Product,
                    x=>x.Product.Stocks.Where(x=>x.BranchId == branchId)
                });

            return new SuccessDataResult<IEnumerable<GetProductReceiptDTO>>(
                _mapper.Map<IEnumerable<GetProductReceiptDTO>>(result));
        }*/
    }
}
