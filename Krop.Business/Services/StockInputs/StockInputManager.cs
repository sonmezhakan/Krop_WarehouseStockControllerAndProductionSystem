using AutoMapper;
using Krop.Business.Exceptions.Middlewares.Transaction;
using Krop.Business.Features.Employees.Constants;
using Krop.Business.Features.Employees.Rules;
using Krop.Business.Features.StockInputs.Constants;
using Krop.Business.Features.StockInputs.Rules;
using Krop.Business.Features.StockInputs.Validation;
using Krop.Business.Services.Stocks;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Helpers.CacheHelpers;
using Krop.Common.Utilits.Business;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DataAccess.UnitOfWork;
using Krop.DTO.Dtos.StockInputs;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace Krop.Business.Services.StockInputs
{
    public class StockInputManager : IStockInputService
    {
        private readonly IStockInputRepository _stockInputRepository;
        private readonly IMapper _mapper;
        private readonly EmployeeBusinessRules _employeeBusinessRules;
        private readonly IStockService _stockService;
        private readonly StockInputBusinessRules _stockInputBusinessRules;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheHelper _cacheHelper;
        private readonly IEmployeeRepository _employeeRepository;

        public StockInputManager(IStockInputRepository stockInputRepository, IMapper mapper,
            EmployeeBusinessRules employeeBusinessRules, IStockService stockService, StockInputBusinessRules stockInputBusinessRules, IUnitOfWork unitOfWork, ICacheHelper cacheHelper, IEmployeeRepository employeeRepository
            )
        {
            _stockInputRepository = stockInputRepository;
            _mapper = mapper;
            _employeeBusinessRules = employeeBusinessRules;
            _stockService = stockService;
            _stockInputBusinessRules = stockInputBusinessRules;
            _unitOfWork = unitOfWork;
            _cacheHelper = cacheHelper;
            _employeeRepository = employeeRepository;
        }
        #region Add
        [TransactionScope]
        [ValidationAspect(typeof(UpdateStockInputValidator))]
        public async Task<IResult> AddAsync(CreateStockInputDTO createStockInputDTO)
        {
            var result = BusinessRules.Run(await _employeeBusinessRules.CheckEmployeeBranch(createStockInputDTO.AppUserId, createStockInputDTO.BranchId));//Çalışanın şube çalışıp çalışmadığı kontrolü yapılıyor. 
            if (!result.Success)
                return result;

            await _stockService.StockAddedAsync(createStockInputDTO.BranchId, createStockInputDTO.ProductId, createStockInputDTO.Quantity);//Stoğa ekliyor

            await _stockInputRepository.AddAsync(
                _mapper.Map<StockInput>(createStockInputDTO));
            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                $"{StockInputCacheKeys.GetByAppUserBranchIdAsync}{createStockInputDTO.BranchId}",
            });
            return new SuccessResult();
        }
        #endregion
        #region Update
        [TransactionScope]
        [ValidationAspect(typeof(UpdateStockInputValidator))]
        public async Task<IResult> UpdateAsync(UpdateStockInputDTO updateStockInputDTO, bool productionUpdated = false)
        {
            var result = await _stockInputRepository.GetAsync(x=>x.Id == updateStockInputDTO.Id);//Stok Girişi yapılıp yapılmadığı kontrol ediliyor. Eğer stok giriş yapılmış ise StockInput olarak getiriyor.
            if (result is null)
                return new ErrorResult(StatusCodes.Status404NotFound, StockInputMessages.StockInputNotFound);

            //stok girişi ekranında işlem güncellenmeye çalışılırsa ve işlem üretimden giriş yapıldıysa işlemin yapılması engelleniyor. Eğer işlem üretim tarafından yapılıyor ise işlemi yapmaya izin verir.
            if (result.ProductionId != null && result.ProductionId != Guid.Empty)
                return new ErrorResult(StatusCodes.Status400BadRequest, StockInputMessages.ProductionEntryCannotBeChangedOrDeleted);

            var businessRuleResult = BusinessRules.Run(
               await _employeeBusinessRules.CheckEmployeeBranch(updateStockInputDTO.AppUserId, updateStockInputDTO.BranchId)//Çalışanın şube çalışıp çalışmadığı kontrolü yapılıyor.
               );
            if (!businessRuleResult.Success)
                return businessRuleResult;

            await _stockService.StockDeleteAsync(result.BranchId, result.ProductId, result.Quantity);//Şube değişikliği veya ürün değişikliği yapılırsa diye ilk önce stoktan miktarı çıkarmamız gerekiyor.
            await _stockService.StockAddedAsync(updateStockInputDTO.BranchId, updateStockInputDTO.ProductId, updateStockInputDTO.Quantity);//Stoğa ekliyor

            StockInput stockInput = _mapper.Map(updateStockInputDTO, result);//Veritabanındaki bilgileri güncellenecek bilgiler ile değiştiriyor

            await _stockInputRepository.UpdateAsync(stockInput);//Stok girişi işlemini güncelliyor.

            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                $"{StockInputCacheKeys.GetByAppUserBranchIdAsync}{result.BranchId}",
                $"{StockInputCacheKeys.GetByIdAsync}{updateStockInputDTO.Id}"
            });
            return new SuccessResult();
        }
        #endregion
        #region Delete
        [TransactionScope]
        public async Task<IResult> DeleteAsync(Guid id, Guid appUserId, bool productionDeleted = false)
        {
            var result = await _stockInputRepository.GetAsync(x => x.Id == id);//Stok Girişi yapılıp yapılmadığı kontrol ediliyor. Eğer stok giriş yapılmış ise StockInput olarak getiriyor.
            if (result is null)
                return new ErrorResult(StatusCodes.Status404NotFound, StockInputMessages.StockInputNotFound);

            //stok girişi ekranında işlem silinmeye çalışılırsa ve işlem üretimden giriş yapıldıysa işlemin yapılması engelleniyor. Eğer işlem üretim tarafından yapılıyor ise işlemi yapmaya izin verir.
            if (result.ProductionId != null && result.ProductionId != Guid.Empty)
                return new ErrorResult(StatusCodes.Status400BadRequest, StockInputMessages.ProductionEntryCannotBeChangedOrDeleted);

            var businessRuleResult = BusinessRules.Run(
               await _employeeBusinessRules.CheckEmployeeBranch(appUserId, result.BranchId)//Çalışanın şube çalışıp çalışmadığı kontrolü yapılıyor.
               );
            if (!businessRuleResult.Success)
                return businessRuleResult;

            await _stockService.StockDeleteAsync(result.BranchId, result.ProductId, result.Quantity);//Şube değişikliği veya ürün değişikliği yapılırsa diye ilk önce stoktan miktarı çıkarmamız gerekiyor.

            await _stockInputRepository.DeleteAsync(result);//Stok girişinden siliyor.

            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                $"{StockInputCacheKeys.GetByAppUserBranchIdAsync}{result.BranchId}",
                $"{StockInputCacheKeys.GetByIdAsync}{id}"
            });
            return new SuccessResult();
        }
        #endregion
        #region Listed
        public async Task<IDataResult<IEnumerable<GetStockInputListDTO>>> GetByAppUserBranchIdAsync(Guid appUserId)
        {
            var employee = await _employeeRepository.GetAsync(x=>x.AppUserId == appUserId);
            if (employee is null)
                return new ErrorDataResult<IEnumerable<GetStockInputListDTO>>(StatusCodes.Status404NotFound, EmployeeMessages.EmployeeNotFound);

            var businessRuleResult = BusinessRules.Run(await _employeeBusinessRules.CheckEmployeeBranch(appUserId, (Guid)employee.BranchId));//Çalışanın şube çalışıp çalışmadığı kontrolü yapılıyor.
            if (!businessRuleResult.Success)
                return new ErrorDataResult<IEnumerable<GetStockInputListDTO>>(businessRuleResult.Status, businessRuleResult.Detail);

            IEnumerable<GetStockInputListDTO>? getStockInputListDTOs = await _cacheHelper.GetOrAddListAsync(
                $"{StockInputCacheKeys.GetByAppUserBranchIdAsync}{employee.BranchId}",
                async () =>
                {
                    var result = await _stockInputRepository.GetAllWithIncludesAsync(predicate: x => x.BranchId == employee.BranchId,
                includeProperties: new Expression<Func<StockInput, object>>[]
            {
                p=>p.Product,
                s=>s.Supplier,
                b=>b.Branch,
                au=>au.AppUser
            });
                    return result is null ? null : _mapper.Map<IEnumerable<GetStockInputListDTO>>(result);
                },
                10
                );

            return new SuccessDataResult<IEnumerable<GetStockInputListDTO>>(getStockInputListDTOs.OrderByDescending(x=>x.InputDate));
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetStockInputDTO>> GetByIdAsync(Guid id)
        {
            GetStockInputDTO? getStockInputDTO = await _cacheHelper.GetOrAddAsync(
                $"{StockInputCacheKeys.GetByIdAsync}{id}",
                async () =>
                {
                    var result = await _stockInputRepository.GetAsync(x=>x.Id == id);
                    return result is null ? null : _mapper.Map<GetStockInputDTO>(result);
                },
                10
                ); 
                return getStockInputDTO is null ?
                    new ErrorDataResult<GetStockInputDTO>(StatusCodes.Status404NotFound, StockInputMessages.StockInputNotFound):
                     new SuccessDataResult<GetStockInputDTO>(getStockInputDTO);
        }
        #endregion
    }
}
