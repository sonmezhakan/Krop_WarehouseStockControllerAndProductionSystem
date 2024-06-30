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

    }
}
