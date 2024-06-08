using AutoMapper;
using Krop.Business.Exceptions.Middlewares.Transaction;
using Krop.Business.Features.Employees.Rules;
using Krop.Business.Features.StockInputs.Constants;
using Krop.Business.Features.StockInputs.Rules;
using Krop.Business.Features.StockInputs.Validation;
using Krop.Business.Services.Stocks;
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

        public StockInputManager(IStockInputRepository stockInputRepository, IMapper mapper,
            EmployeeBusinessRules employeeBusinessRules, IStockService stockService, StockInputBusinessRules stockInputBusinessRules, IUnitOfWork unitOfWork
            )
        {
            _stockInputRepository = stockInputRepository;
            _mapper = mapper;
            _employeeBusinessRules = employeeBusinessRules;
            _stockService = stockService;
            _stockInputBusinessRules = stockInputBusinessRules;
            _unitOfWork = unitOfWork;
        }
        #region Add
       
        [TransactionScope]
        public async Task<IResult> AddAsync(CreateStockInputDTO createStockInputDTO)
        {
            var result = BusinessRules.Run(await _employeeBusinessRules.CheckEmployeeBranch(createStockInputDTO.AppUserId, createStockInputDTO.BranchId));//Çalışanın şube çalışıp çalışmadığı kontrolü yapılıyor. 
            if (!result.Success)
                return result;

            await _stockService.StockAddedAsync(createStockInputDTO.BranchId, createStockInputDTO.ProductId, createStockInputDTO.Quantity);//Stoğa ekliyor
            
            await _stockInputRepository.AddAsync(
                _mapper.Map<StockInput>(createStockInputDTO));
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult();
        }
        #endregion
        #region Update
        
        [TransactionScope]
        public async Task<IResult> UpdateAsync(UpdateStockInputDTO updateStockInputDTO)
        {
            var result = await _stockInputBusinessRules.CheckStockInput(updateStockInputDTO.Id);//Stok Girişi yapılıp yapılmadığı kontrol ediliyor. Eğer stok giriş yapılmış ise StockInput olarak getiriyor.
            if (result is null)
                return new ErrorResult(StatusCodes.Status404NotFound, StockInputMessages.StockInputNotFound);

            var businessRuleResult = BusinessRules.Run(
               await _employeeBusinessRules.CheckEmployeeBranch(updateStockInputDTO.AppUserId, updateStockInputDTO.BranchId),//Çalışanın şube çalışıp çalışmadığı kontrolü yapılıyor.
               await _stockInputBusinessRules.CheckIfStockInputProduction(result.Data)
               );
            if (!businessRuleResult.Success)
                return businessRuleResult;

            await _stockService.StockDeleteAsync(result.Data.BranchId, result.Data.ProductId, result.Data.Quantity);//Şube değişikliği veya ürün değişikliği yapılırsa diye ilk önce stoktan miktarı çıkarmamız gerekiyor.
            await _stockService.StockAddedAsync(updateStockInputDTO.BranchId, updateStockInputDTO.ProductId, updateStockInputDTO.Quantity);//Stoğa ekliyor

            StockInput stockInput = _mapper.Map(updateStockInputDTO, result.Data);//Veritabanındaki bilgileri güncellenecek bilgiler ile değiştiriyor

            await _stockInputRepository.UpdateAsync(stockInput);//Stok girişi işlemini güncelliyor.

            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult();
        }
        #endregion
        #region Delete
        [TransactionScope]
        public async Task<IResult> DeleteAsync(Guid id, Guid appUserId)
        {
            var result = await _stockInputBusinessRules.CheckStockInput(id);//Stok Girişi yapılıp yapılmadığı kontrol ediliyor. Eğer stok giriş yapılmış ise StockInput olarak getiriyor.
            if (!result.Success)
                return result;

            var businessRuleResult = BusinessRules.Run(
               await _employeeBusinessRules.CheckEmployeeBranch(appUserId, result.Data.BranchId),//Çalışanın şube çalışıp çalışmadığı kontrolü yapılıyor.
               await _stockInputBusinessRules.CheckIfStockInputProduction(result.Data)
               );
            if (!businessRuleResult.Success)
                return businessRuleResult;

            await _stockService.StockDeleteAsync(result.Data.BranchId, result.Data.ProductId, result.Data.Quantity);//Şube değişikliği veya ürün değişikliği yapılırsa diye ilk önce stoktan miktarı çıkarmamız gerekiyor.

            await _stockInputRepository.DeleteAsync(result.Data);//Stok girişinden siliyor.

            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult();
        }
        #endregion
        #region Listed
        public async Task<IDataResult<IEnumerable<GetStockInputListDTO>>> GetAllAsync(Guid appUserId)
        {
            var employee = await _employeeBusinessRules.CheckByEmployeeId(appUserId);
            if (!employee.Success)
                return new ErrorDataResult<IEnumerable<GetStockInputListDTO>>(employee.Status, employee.Detail);

            var businessRuleResult = BusinessRules.Run(await _employeeBusinessRules.CheckEmployeeBranch(appUserId, (Guid)employee.Data.BranchId));//Çalışanın şube çalışıp çalışmadığı kontrolü yapılıyor.
            if (!businessRuleResult.Success)
                return new ErrorDataResult<IEnumerable<GetStockInputListDTO>>(businessRuleResult.Status, businessRuleResult.Detail);

            var result = await _stockInputRepository.GetAllAsync(predicate: x=>x.BranchId == employee.Data.BranchId,
                includeProperties: new Expression<Func<StockInput, object>>[]
            {
                p=>p.Product,
                s=>s.Supplier,
                b=>b.Branch,
                au=>au.AppUser
            });

            return new SuccessDataResult<IEnumerable<GetStockInputListDTO>>(
                _mapper.Map<IEnumerable<GetStockInputListDTO>>(result));
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetStockInputDTO>> GetByIdAsync(Guid id)
        {
            var result = await _stockInputBusinessRules.CheckStockInput(id);//Stok Girişi yapılıp yapılmadığı kontrol ediliyor.
            if (!result.Success)
                return new ErrorDataResult<GetStockInputDTO>(result.Status, result.Detail);

            return new SuccessDataResult<GetStockInputDTO>(
                _mapper.Map<GetStockInputDTO>(result.Data));
        }
        #endregion
    }
}
