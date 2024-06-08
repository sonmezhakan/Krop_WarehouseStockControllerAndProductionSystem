using AutoMapper;
using Krop.Business.Exceptions.Middlewares.Transaction;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DTO.Dtos.ProductionStockExit;
using Krop.Entities.Entities;

namespace Krop.Business.Services.ProductionStockExits
{
    public class ProductionStockExitManager : IProductionStockExitService
    {
        private readonly IProductionStockExitRepository _productionStockExitRepository;
        private readonly IMapper _mapper;

        public ProductionStockExitManager(IProductionStockExitRepository productionStockExitRepository,IMapper mapper)
        {
            _productionStockExitRepository = productionStockExitRepository;
            _mapper = mapper;
        }
        [TransactionScope]
        public async Task<IResult> AddRangeAsync(List<CreateProductionStockExitDTO> createProductionStockExitDTOs)
        {
           await _productionStockExitRepository.AddRangeAsync(
                _mapper.Map<List<ProductionStockExit>>(createProductionStockExitDTOs));

            return new SuccessResult();
        }
        [TransactionScope]
        public async Task<IResult> UpdateRangeAsync(List<UpdateProductionStockExitDTO> updateProductionStockExitDTOs)
        {
            var result = _mapper.Map<List<ProductionStockExit>>(updateProductionStockExitDTOs);
            await _productionStockExitRepository.UpdateRangeAsync(
                result);

            return new SuccessResult();
        }
        [TransactionScope]
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var result = await _productionStockExitRepository.GetAsync(x => x.Id == id);

            await _productionStockExitRepository.DeleteAsync(result);

            return new SuccessResult();
        }

        public async Task<IDataResult<GetProductionStockExitDTO>> GetByIdAsync(Guid Id)
        {
            var result = await _productionStockExitRepository.GetAsync(x => x.Id == Id);

            return new SuccessDataResult<GetProductionStockExitDTO>(
                _mapper.Map<GetProductionStockExitDTO>(result));
        }

        public async Task<IDataResult<IEnumerable<GetProductionStockExitDTO>>> GetByProductionIdAllAsync(Guid productionId)
        {
            var result = await _productionStockExitRepository.GetAsync(x => x.ProductionId == productionId);

            return new SuccessDataResult<IEnumerable<GetProductionStockExitDTO>>(
                _mapper.Map<IEnumerable<GetProductionStockExitDTO>>(result));
        }

        
    }
}
