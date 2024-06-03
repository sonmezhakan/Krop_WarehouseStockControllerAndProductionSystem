using Krop.Business.Features.Productions.ExceptionHelpers;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.Business.Features.Productions.Rules
{
    public class ProductionBusinessRules
    {
        private readonly ProductionExceptionHelper _productionExceptionHelper;
        private readonly IProductionRepository _productionRepository;

        public ProductionBusinessRules(ProductionExceptionHelper productionExceptionHelper,IProductionRepository productionRepository)
        {
            _productionExceptionHelper = productionExceptionHelper;
            _productionRepository = productionRepository;
        }

        public async Task<Production> CheckByProductionId(Guid id)
        {
            var result = await _productionRepository.GetAsync(x => x.Id == id);
            if (result == null)
                _productionExceptionHelper.ThrowProductionNotFound();

            return result;
        }
    }
}
