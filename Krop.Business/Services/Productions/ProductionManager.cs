using AutoMapper;
using Krop.Business.Exceptions.Middlewares.Transaction;
using Krop.Business.Features.Employees.Constants;
using Krop.Business.Features.Employees.Rules;
using Krop.Business.Features.Productions.Constants;
using Krop.Business.Features.Productions.Rules;
using Krop.Business.Features.Productions.Validations;
using Krop.Business.Services.ProductionStockExits;
using Krop.Business.Services.StockInputs;
using Krop.Business.Services.Stocks;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Helpers.CacheHelpers;
using Krop.Common.Utilits.Business;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DataAccess.Repositories.Concretes.EntityFramework;
using Krop.DataAccess.UnitOfWork;
using Krop.DTO.Dtos.Productions;
using Krop.DTO.Dtos.StockInputs;
using Krop.DTO.Dtos.Stocks;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace Krop.Business.Services.Productions
{
    public partial class ProductionManager : IProductionService
    {
        private readonly IProductionRepository _productionRepository;
        private readonly IMapper _mapper;
        private readonly EmployeeBusinessRules _employeeBusinessRules;
        private readonly IProductReceiptRepository _productReceiptRepository;
        private readonly IStockService _stockService;
        private readonly IStockInputService _stockInputService;
        private readonly ProductionBusinessRules _productionBusinessRules;
        private readonly IProductionStockExitService _productionStockExitService;
        private readonly IStockInputRepository _stockInputRepository;
        private readonly IProductionStockExitRepository _productionStockExitRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheHelper _cacheHelper;
        private readonly IEmployeeRepository _employeeRepository;

        public ProductionManager(IProductionRepository productionRepository, IMapper mapper, EmployeeBusinessRules employeeBusinessRules,IProductReceiptRepository productReceiptRepository,IStockService stockService, IStockInputService stockInputService, ProductionBusinessRules productionBusinessRules,IProductionStockExitService productionStockExitService, IStockInputRepository stockInputRepository,IProductionStockExitRepository productionStockExitRepository,
            IUnitOfWork unitOfWork, ICacheHelper cacheHelper,IEmployeeRepository employeeRepository)
        {
            _productionRepository = productionRepository;
            _mapper = mapper;
            _employeeBusinessRules = employeeBusinessRules;
            _productReceiptRepository = productReceiptRepository;
            _stockService = stockService;
            _stockInputService = stockInputService;
            _productionBusinessRules = productionBusinessRules;
            _productionStockExitService = productionStockExitService;
            _stockInputRepository = stockInputRepository;
            _productionStockExitRepository = productionStockExitRepository;
            _unitOfWork = unitOfWork;
            _cacheHelper = cacheHelper;
            _employeeRepository = employeeRepository;
        }

        #region Add
        [TransactionScope]
        [ValidationAspect(typeof(CreateProductionValidator))]
        public async Task<IResult> AddAsync(CreateProductionDTO createProductionDTO)
        {
            var result = BusinessRules.Run(await _employeeBusinessRules.CheckEmployeeBranch(createProductionDTO.AppUserId, createProductionDTO.BranchId));//Çalışanın şube çalışıp çalışmadığı kontrolü yapılıyor.
            if (!result.Success)
                return result;

            Production production = _mapper.Map<Production>(createProductionDTO);
            await _productionRepository.AddAsync(production);

            var productionStockExits = await ProductionStockExitAdded(_mapper.Map<GetProductionDTO>(createProductionDTO), production.Id);

            await StockDeleted(productionStockExits, createProductionDTO.BranchId);

            await _stockInputService.AddAsync(new CreateStockInputDTO
            {
                BranchId = createProductionDTO.BranchId,
                ProductId = createProductionDTO.ProductId,
                AppUserId = createProductionDTO.AppUserId,
                InputDate = createProductionDTO.ProductionDate,
                Quantity = createProductionDTO.ProductionQuantity,
                ProductionId = production.Id
            });
            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                $"{ProductionCacheKeys.GetByBranchIdAsync}{createProductionDTO.BranchId}"
            });
            return new SuccessResult();
        }
        #endregion
        #region Update
        [TransactionScope]
        [ValidationAspect(typeof(UpdateProductionValidator))]
        public async Task<IResult> UpdateAsync(UpdateProductionDTO updateProductionDTO)
        {
            var businessRuleResult = BusinessRules.Run(await _employeeBusinessRules.CheckEmployeeBranch(updateProductionDTO.AppUserId, updateProductionDTO.BranchId));//Çalışanın şube çalışıp çalışmadığı kontrolü yapılıyor.
            if (!businessRuleResult.Success)
                return businessRuleResult;

            var result = await _productionRepository.GetAsync(x=>x.Id == updateProductionDTO.Id);
            if (result is null)
                return new ErrorResult(StatusCodes.Status404NotFound,ProductionMessages.ProductionNotFound);

            var oldProductionStockExits = await _productionStockExitRepository.GetAllAsync(x => x.ProductionId == updateProductionDTO.Id);//Önceki üretimde stokdan çıkarılan ürünlerin listesi getiriliyor.

            await StockAdded(oldProductionStockExits.ToList(), result.BranchId);
            await ProductionStockExitDeleted(oldProductionStockExits.ToList());

            await _stockService.StockDeleteAsync(result.BranchId, result.ProductId, result.ProductionQuantity);//Üretilen ürün stoktan düşürülüyor.

            var newProductionStockExits = await ProductionStockExitAdded(_mapper.Map<GetProductionDTO>(updateProductionDTO), result.Id);

            await StockDeleted(newProductionStockExits, updateProductionDTO.BranchId);

            await _stockService.StockAddedAsync(updateProductionDTO.BranchId, updateProductionDTO.ProductId, updateProductionDTO.ProductionQuantity);//Üretilecek ürünün miktarı stoğa ekleniyor.

            var stockInput = await _stockInputRepository.GetAsync(x => x.ProductionId == result.Id);
            stockInput.Quantity = updateProductionDTO.ProductionQuantity;
            await _stockInputRepository.UpdateAsync(stockInput);//Stok Giriş listesindeki üretimden oluşan ürün girişinin miktarı güncelleniyor.

            Production production = _mapper.Map(updateProductionDTO, result);
            await _productionRepository.UpdateAsync(production);//Üretim deki üretim miktarı güncelleniyor.

            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                $"{ProductionCacheKeys.GetByBranchIdAsync}{result.BranchId}",//old
                $"{ProductionCacheKeys.GetByBranchIdAsync}{updateProductionDTO.BranchId}",//new
                $"{ProductionCacheKeys.GetByIdAsync}{updateProductionDTO.Id}",//new
            });
            return new SuccessResult();
        }
        #endregion
        #region Delete
        [TransactionScope]
        public async Task<IResult> DeleteAsync(Guid id, Guid appUserId)
        {
            var result = await _productionRepository.GetIcludesAsync(x => x.Id == id,
                includeProperties: new Expression<Func<Production, object>>[]
                {
                    si=>si.StockInput
                });
            if (result is null)
                return new ErrorResult(StatusCodes.Status404NotFound, ProductionMessages.ProductionNotFound);

            var businessRuleResult = BusinessRules.Run(await _employeeBusinessRules.CheckEmployeeBranch(appUserId, result.BranchId));//Çalışanın şube çalışıp çalışmadığı kontrolü yapılıyor.
            if (!businessRuleResult.Success)
                return businessRuleResult;

            var productionStockExits = await _productionStockExitRepository.GetAllAsync(x => x.ProductionId == id);

            await ProductionStockExitDeleted(productionStockExits.ToList());
            await StockAdded(productionStockExits.ToList(), result.BranchId);

            await _stockInputService.DeleteAsync(result.StockInput.Id, appUserId, true);

            await _productionRepository.DeleteAsync(result);

            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                $"{ProductionCacheKeys.GetByBranchIdAsync}{result.BranchId}",
                $"{ProductionCacheKeys.GetByIdAsync}{id}"
            });
            return new SuccessResult();
        }
        #endregion
        #region List
        public async Task<IDataResult<IEnumerable<GetProductionListDTO>>> GetByBranchIdAsync(Guid appUserId)
        {
            var employee = await _employeeRepository.GetAsync(x => x.Id == appUserId);
            if (employee is null)
                return new ErrorDataResult<IEnumerable<GetProductionListDTO>>(StatusCodes.Status404NotFound, EmployeeMessages.EmployeeNotFound);

            var businessRuleResult = await _employeeBusinessRules.CheckEmployeeBranch(appUserId, (Guid)employee.BranchId);//Çalışanın şube çalışıp çalışmadığı kontrolü yapılıyor.
            if (!businessRuleResult.Success)
                return new ErrorDataResult<IEnumerable<GetProductionListDTO>>(businessRuleResult.Status, businessRuleResult.Detail);

            #region Cache
            IEnumerable<GetProductionListDTO>? getProductionListDTOs = await _cacheHelper.GetOrAddListAsync(
                ProductionCacheKeys.GetByBranchIdAsync,
                async () =>
                {
                    var result = await _productionRepository.GetAllWithIncludesAsync(x => x.BranchId == employee.BranchId, includeProperties: new Expression<Func<Production, object>>[]
                        {
                             p=>p.Product,
                             b=>b.Branch,
                             au=>au.AppUser
                         });
                    return result is null ? null : _mapper.Map<IEnumerable<GetProductionListDTO>>(result);
                },
                60
                );
            #endregion

            return new SuccessDataResult<IEnumerable<GetProductionListDTO>>(getProductionListDTOs);
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetProductionDTO>> GetByIdAsync(Guid id, Guid appUserId)
        {
            GetProductionDTO? getProductionDTO = await _cacheHelper.GetOrAddAsync(
                $"{ProductionCacheKeys.GetByIdAsync}{id}",
                async () =>
                {
                    var result = await _productionRepository.GetAsync(x => x.Id == id && x.AppUserId == appUserId);
                    return result is null ? null : _mapper.Map<GetProductionDTO>(result);
                },
                30
                );
                return getProductionDTO is null ?
                new ErrorDataResult<GetProductionDTO>(StatusCodes.Status404NotFound, ProductionMessages.ProductionNotFound):
                new SuccessDataResult<GetProductionDTO>(getProductionDTO);
        }
        #endregion
    }
    #region Custom Metot
    public partial class ProductionManager
    {
        private async Task<List<ProductionStockExit>> ProductionStockExitAdded(GetProductionDTO getProductionDTO, Guid productionId)
        {
            var productReceiptList = await _productReceiptRepository.GetAllAsync(x => x.ProduceProductId == getProductionDTO.ProductId);
            List<ProductionStockExit> productionStockExits = new();

            foreach (ProductReceipt productReceipt in productReceiptList)
            {
                int totalQuantity = productReceipt.Quantity * getProductionDTO.ProductionQuantity;
                productionStockExits.Add(new ProductionStockExit
                {
                    ProductId = productReceipt.ProductId,
                    ProductionId = productionId,
                    ExitDate = getProductionDTO.ProductionDate,
                    QuantityExit = totalQuantity
                });
            }

            await _productionStockExitRepository.AddRangeAsync(productionStockExits);

            return productionStockExits;
        }
        private async Task StockDeleted(List<ProductionStockExit> productionStockExits, Guid branchId)
        {
            foreach (ProductionStockExit productionStockExit in productionStockExits)
            {
                await _stockService.StockDeleteAsync(branchId, productionStockExit.ProductId, productionStockExit.QuantityExit);
            }
        }
        private async Task StockAdded(List<ProductionStockExit> productionStockExits, Guid branchId)
        {
            foreach (ProductionStockExit productionStockExit in productionStockExits)
            {
                await _stockService.StockAddedAsync(branchId, productionStockExit.ProductId, productionStockExit.QuantityExit);
            }
        }
        private async Task ProductionStockExitDeleted(List<ProductionStockExit> productionStockExits)
        {
            foreach (ProductionStockExit productionStockExit in productionStockExits)
            {
                await _productionStockExitService.DeleteAsync(productionStockExit.Id);
            }
        }
    }
    #endregion
}
