﻿using Krop.Common.Utilits.Result;
using Krop.DTO.Dtos.ProductReceipts;

namespace Krop.Business.Services.ProductReceipts
{
    public interface IProductReceiptService
    {
        Task<IDataResult<IEnumerable<GetProductReceiptListDTO>>> GetByProduceIdAsync(Guid produceProductId);
        Task<IDataResult<GetProductReceiptDTO>> GetByProduceProductIdAndProductIdAsync(Guid produceProductId,Guid productId);
        Task<IResult> AddAsync(CreateProductReceiptDTO createProductReceiptDTO);
        Task<IResult> UpdateAsync(UpdateProductReceiptDTO updateProductReceiptDTO);
        Task<IResult> DeleteAsync(Guid produceProductId,Guid productId);
    }
}
