using AutoMapper;
using Krop.Business.Features.ProductReceipts.Rules;
using Krop.Business.Features.ProductReceipts.Validation;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
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

        public ProductReceiptManager(IProductReceiptRepository productReceiptRepository, IMapper mapper, ProductReceiptBusinessRules productReceiptBusinessRule)
        {
            _productReceiptRepository = productReceiptRepository;
            _mapper = mapper;
            _productReceiptBusinessRule = productReceiptBusinessRule;
        }
        [ValidationAspect(typeof(CreateProductReceiptValidator))]
        public async Task<IResult> AddAsync(CreateProductReceiptDTO createProductReceiptDTO)
        {
            await _productReceiptBusinessRule.ProductReceiptCannotBeDuplicatedWhenInserted(createProductReceiptDTO.ProduceProductId, createProductReceiptDTO.ProductId);//Business Rule

            await _productReceiptRepository.AddAsync(
               _mapper.Map<ProductReceipt>(createProductReceiptDTO));

            return new SuccessResult();
        }
        [ValidationAspect(typeof(UpdateProductReceiptValidator))]
        public async Task<IResult> UpdateAsync(UpdateProductReceiptDTO updateProductReceiptDTO)
        {
            ProductReceipt productReceipt = await _productReceiptBusinessRule.CheckProductReceipt(updateProductReceiptDTO.ProduceProductId, updateProductReceiptDTO.ProductId);

            await _productReceiptBusinessRule.ProductReceiptCannotBeDuplicatedWhenUpdated(updateProductReceiptDTO.ProduceProductId, productReceipt.ProductId, updateProductReceiptDTO.ProductId);//Business Rule

            productReceipt = _mapper.Map(updateProductReceiptDTO, productReceipt);

            await _productReceiptRepository.UpdateAsync(productReceipt);

            return new SuccessResult();

        }
        public async Task<IResult> DeleteAsync(Guid produceProductId, Guid productId)
        {
            ProductReceipt productReceipt = await _productReceiptBusinessRule.CheckProductReceipt(produceProductId, productId);

            await _productReceiptRepository.HardDeleteAsync(productReceipt);

            return new SuccessResult();
        }

        public async Task<IDataResult<IEnumerable<GetProductReceiptListDTO>>> GetAllAsync(Guid produceProductId)
        {
            var result = await _productReceiptRepository.GetAllAsync(predicate: x => x.ProduceProductId == produceProductId,
                includeProperties: new Expression<Func<ProductReceipt, object>>[]
                {
                    p=>p.Product
                });

            return new SuccessDataResult<IEnumerable<GetProductReceiptListDTO>>(_mapper.Map<IEnumerable<GetProductReceiptListDTO>>(result));
        }

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
