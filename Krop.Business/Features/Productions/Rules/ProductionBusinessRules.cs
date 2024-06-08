using Krop.Business.Features.Productions.Constants;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;

namespace Krop.Business.Features.Productions.Rules
{
    public class ProductionBusinessRules
    {
        private readonly IProductionRepository _productionRepository;

        public ProductionBusinessRules(IProductionRepository productionRepository)
        {
            _productionRepository = productionRepository;
        }

        public async Task<IDataResult<Production>> CheckByProductionId(Guid id)
        {
            var result = await _productionRepository.GetAsync(x => x.Id == id);
            if (result == null)
                return new ErrorDataResult<Production>(StatusCodes.Status404NotFound, ProductionMessages.ProductionNotFound); ;

            return new SuccessDataResult<Production>(result);
        }
       
    }
}
