using Krop.Business.Features.StockInputs.ExceptionHelpers;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.Business.Features.StockInputs.Rules
{
    public class StockInputBusinessRules
    {
        private readonly IStockInputRepository _stockInputRepository;
        private readonly StockInputExceptionHelper _stockInputExceptionHelper;

        public StockInputBusinessRules(IStockInputRepository stockInputRepository, StockInputExceptionHelper stockInputExceptionHelper)
        {
            _stockInputRepository = stockInputRepository;
            _stockInputExceptionHelper = stockInputExceptionHelper;
        }

        public async Task<StockInput> CheckStockInput(Guid Id)
        {
            var result = await _stockInputRepository.GetAsync(x=>x.Id == Id);

            if (result is null)
                _stockInputExceptionHelper.ThrowStockInputNotFound();

            return result;

        }
    }
}
