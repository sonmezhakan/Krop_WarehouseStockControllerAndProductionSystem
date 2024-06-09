using AutoMapper;
using Krop.Business.Exceptions.Middlewares.Transaction;
using Krop.Business.Features.Employees.Rules;
using Krop.Business.Features.Productions.Rules;
using Krop.Business.Services.ProductionStockExits;
using Krop.Business.Services.StockInputs;
using Krop.Business.Services.Stocks;
using Krop.Common.Utilits.Business;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DataAccess.UnitOfWork;
using Krop.DTO.Dtos.Productions;
using Krop.DTO.Dtos.StockInputs;
using Krop.Entities.Entities;
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

        public ProductionManager(IProductionRepository productionRepository, IMapper mapper, EmployeeBusinessRules employeeBusinessRules,IProductReceiptRepository productReceiptRepository,IStockService stockService, IStockInputService stockInputService, ProductionBusinessRules productionBusinessRules,IProductionStockExitService productionStockExitService, IStockInputRepository stockInputRepository,IProductionStockExitRepository productionStockExitRepository,
            IUnitOfWork unitOfWork)
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
        }
        
        
        [TransactionScope]
        public async Task<IResult> AddAsync(CreateProductionDTO createProductionDTO)
        {
            var result = BusinessRules.Run(await _employeeBusinessRules.CheckEmployeeBranch(createProductionDTO.AppUserId, createProductionDTO.BranchId));//Çalışanın şube çalışıp çalışmadığı kontrolü yapılıyor.
            if (!result.Success)
                return result;

            Production production = _mapper.Map<Production>(createProductionDTO);
            await _productionRepository.AddAsync(production);

            var productionStockExits = await ProductionStockExitAdded(_mapper.Map<GetProductionDTO>(createProductionDTO),production.Id);

            await StockDeleted(productionStockExits,createProductionDTO.BranchId);
            
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
            return new SuccessResult();
        }

        
        
        [TransactionScope]
        public async Task<IResult> UpdateAsync(UpdateProductionDTO updateProductionDTO)
        {
            var businessRuleResult = BusinessRules.Run(await _employeeBusinessRules.CheckEmployeeBranch(updateProductionDTO.AppUserId, updateProductionDTO.BranchId));//Çalışanın şube çalışıp çalışmadığı kontrolü yapılıyor.
            if (!businessRuleResult.Success)
                return businessRuleResult;

            var result = await _productionBusinessRules.CheckByProductionId(updateProductionDTO.Id);
            if (!result.Success)
                return result;

            var oldProductionStockExits = await _productionStockExitRepository.GetAllAsync(x => x.ProductionId == updateProductionDTO.Id);//Önceki üretimde stokdan çıkarılan ürünlerin listesi getiriliyor.

            await StockAdded(oldProductionStockExits.ToList(), result.Data.BranchId);
            await ProductionStockExitDeleted(oldProductionStockExits.ToList());

            await _stockService.StockDeleteAsync(result.Data.BranchId, result.Data.ProductId, result.Data.ProductionQuantity);//Üretilen ürün stoktan düşürülüyor.

            var newProductionStockExits = await ProductionStockExitAdded(_mapper.Map<GetProductionDTO>(updateProductionDTO),result.Data.Id);

            await StockDeleted(newProductionStockExits,updateProductionDTO.BranchId);
           
            await _stockService.StockAddedAsync(updateProductionDTO.BranchId, updateProductionDTO.ProductId, updateProductionDTO.ProductionQuantity);//Üretilecek ürünün miktarı stoğa ekleniyor.

            var stockInput = await _stockInputRepository.GetAsync(x => x.ProductionId == result.Data.Id);
            stockInput.Quantity = updateProductionDTO.ProductionQuantity;
            await _stockInputRepository.UpdateAsync(stockInput);//Stok Giriş listesindeki üretimden oluşan ürün girişinin miktarı güncelleniyor.

            Production production = _mapper.Map(updateProductionDTO, result.Data);
            await _productionRepository.UpdateAsync(production);//Üretim deki üretim miktarı güncelleniyor.

            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult();
        }
        [TransactionScope]
        public async Task<IResult> DeleteAsync(Guid id, Guid appUserId)
        {
            var result = await _productionRepository.GetAsync(x => x.Id == id,
                includeProperties:new Expression<Func<Production, object>>[]
                {
                    si=>si.StockInput
                });

            var businessRuleResult = BusinessRules.Run(await _employeeBusinessRules.CheckEmployeeBranch(appUserId, result.BranchId));//Çalışanın şube çalışıp çalışmadığı kontrolü yapılıyor.
            if (!businessRuleResult.Success)
                return businessRuleResult;

            var productionStockExits = await _productionStockExitRepository.GetAllAsync(x => x.ProductionId == id);

            await ProductionStockExitDeleted(productionStockExits.ToList());
            await StockAdded(productionStockExits.ToList(),result.BranchId);

            await _stockInputService.DeleteAsync(result.StockInput.Id,appUserId,true);

            await _productionRepository.DeleteAsync(result);

            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult();
        }

        public async Task<IDataResult<IEnumerable<GetProductionListDTO>>> GetAllAsync(Guid appUserId)
        {
           var employee = await _employeeBusinessRules.CheckByEmployeeId(appUserId);
            if (!employee.Success)
                return new ErrorDataResult<IEnumerable<GetProductionListDTO>>(employee.Status, employee.Detail); ;

           var businessRuleResult = await _employeeBusinessRules.CheckEmployeeBranch(appUserId, (Guid)employee.Data.BranchId);//Çalışanın şube çalışıp çalışmadığı kontrolü yapılıyor.
            if (!businessRuleResult.Success)
                return new ErrorDataResult<IEnumerable<GetProductionListDTO>>(businessRuleResult.Status, businessRuleResult.Detail);

            var result = await _productionRepository.GetAllAsync(x=>x.BranchId == employee.Data.BranchId, includeProperties: new Expression<Func<Production, object>>[]
            {
                p=>p.Product,
                b=>b.Branch,
                au=>au.AppUser
            });

            return new SuccessDataResult<IEnumerable<GetProductionListDTO>>(
                _mapper.Map<IEnumerable<GetProductionListDTO>>(result));
        }

        public async Task<IDataResult<GetProductionDTO>> GetByIdAsync(Guid id, Guid appUserId)
        {
            var result = await _productionRepository.GetAsync(x=>x.Id == id && x.AppUserId == appUserId);

            return new SuccessDataResult<GetProductionDTO>(
                _mapper.Map<GetProductionDTO>(result));
        }

        
    }
    //custom metot
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
        private async Task StockDeleted(List<ProductionStockExit> productionStockExits,Guid branchId)
        {
            foreach (ProductionStockExit productionStockExit in productionStockExits)
            {
                await _stockService.StockDeleteAsync(branchId, productionStockExit.ProductId, productionStockExit.QuantityExit);
            }
        }
        private async Task StockAdded(List<ProductionStockExit> productionStockExits,Guid branchId)
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
}
