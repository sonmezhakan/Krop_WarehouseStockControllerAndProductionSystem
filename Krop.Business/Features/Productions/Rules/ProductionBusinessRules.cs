using Krop.DataAccess.Repositories.Abstracts;

namespace Krop.Business.Features.Productions.Rules
{
    public class ProductionBusinessRules
    {
        private readonly IProductionRepository _productionRepository;

        public ProductionBusinessRules(IProductionRepository productionRepository)
        {
            _productionRepository = productionRepository;
        }       
    }
}
