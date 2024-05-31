﻿using Krop.Business.Features.StockTransfers.Dtos;
using Krop.Common.Utilits.Result;

namespace Krop.Business.Services.StockTransfers
{
    public interface IStockTransferService
    {
        Task<IDataResult<IEnumerable<GetStockTransferListDTO>>> GetAllAsync();
        Task<IDataResult<IEnumerable<GetStockTransferListDTO>>> AppUserBranchGetAllAsync(Guid appUserId);
        Task<IDataResult<GetStockTransferDTO>> GetByIdAsync(Guid Id, Guid appUserId);

        Task<IResult> AddAsync(CreateStockTransferDTO createStockTransferDTO);
        Task<IResult> UpdateAsync(UpdateStockTransferDTO updateStockTransferDTO);
        Task<IResult> DeleteAsync(Guid Id, Guid appUserId);
    }
}
