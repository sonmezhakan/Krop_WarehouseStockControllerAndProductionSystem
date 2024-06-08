using Krop.Business.Features.Productions.Constants;
using Krop.Business.Features.StockInputs.Constants;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;

namespace Krop.Business.Features.StockInputs.Rules
{
    public class StockInputBusinessRules
    {
        private readonly IStockInputRepository _stockInputRepository;

        public StockInputBusinessRules(IStockInputRepository stockInputRepository)
        {
            _stockInputRepository = stockInputRepository;
        }

        public async Task<IDataResult<StockInput>> CheckStockInput(Guid Id)
        {
            var result = await _stockInputRepository.GetAsync(x=>x.Id == Id);

            if (result is null)
                return new ErrorDataResult<StockInput>(StatusCodes.Status404NotFound, StockInputMessages.StockInputNotFound);

            return new SuccessDataResult<StockInput>(result);
        }
        public async Task<IResult> CheckIfStockInputProduction(StockInput stockInput)
        {
            if (stockInput.ProductionId != null && stockInput.ProductionId != Guid.Empty)
                return new ErrorResult(StatusCodes.Status400BadRequest, StockInputMessages.ProductionEntryCannotBeChangedOrDeleted);

            return new SuccessResult();
        }
    }
}
