using AutoMapper;
using Krop.Business.Exceptions.Middlewares.Transaction;
using Krop.Business.Features.Employees.Constants;
using Krop.Business.Features.Employees.Rules;
using Krop.Business.Features.StockTransfers.Constants;
using Krop.Business.Features.StockTransfers.Rules;
using Krop.Business.Features.StockTransfers.Validations;
using Krop.Business.Services.Stocks;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Helpers.CacheHelpers;
using Krop.Common.Utilits.Business;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DataAccess.UnitOfWork;
using Krop.DTO.Dtos.StockTransfers;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace Krop.Business.Services.StockTransfers
{
    public class StockTransferManager : IStockTransferService
    {
        private readonly IStockTransferRepository _stockTransferRepository;
        private readonly IStockService _stockService;
        private readonly IMapper _mapper;
        private readonly EmployeeBusinessRules _employeeBusinessRules;
        private readonly StockTransferBusinessRules _stockTransferBusinessRules;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheHelper _cacheHelper;
        private readonly IEmployeeRepository _employeeRepository;

        public StockTransferManager(IStockTransferRepository stockTransferRepository, IStockService stockService,IMapper mapper, EmployeeBusinessRules employeeBusinessRules,StockTransferBusinessRules stockTransferBusinessRules,IUnitOfWork unitOfWork,ICacheHelper cacheHelper, IEmployeeRepository employeeRepository)
        {
            _stockTransferRepository = stockTransferRepository;
            _stockService = stockService;
            _mapper = mapper;
            _employeeBusinessRules = employeeBusinessRules;
            _stockTransferBusinessRules = stockTransferBusinessRules;
            _unitOfWork = unitOfWork;
            _cacheHelper = cacheHelper;
            _employeeRepository = employeeRepository;
        }
        #region Add
        [TransactionScope]
        [ValidationAspect(typeof(CreateStockTransferValidator))]
        public async Task<IResult> AddAsync(CreateStockTransferDTO createStockTransferDTO)
        {
            var result = BusinessRules.Run(await _employeeBusinessRules.CheckEmployeeBranch(createStockTransferDTO.TransactorAppUserId, createStockTransferDTO.SenderBranchId),
                await _stockTransferBusinessRules.SenderBranchAndSentBranchExists(createStockTransferDTO.SenderBranchId,createStockTransferDTO.SentBranchId));
            if (!result.Success)
                return result;

            await _stockService.StockDeleteAsync(createStockTransferDTO.SenderBranchId, createStockTransferDTO.ProductId, createStockTransferDTO.Quantity);//Gönderen Şubeden Miktar Siliniyor.
            await _stockService.StockAddedAsync(createStockTransferDTO.SentBranchId, createStockTransferDTO.ProductId, createStockTransferDTO.Quantity);//Gönderilen Şubeye Stok Ekleniyor.

            await _stockTransferRepository.AddAsync(_mapper.Map<StockTransfer>(createStockTransferDTO));
            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                $"{StockTransferCacheKeys.GetAppUserBranchIdListAsync}{createStockTransferDTO.SenderBranchId}",
                $"{StockTransferCacheKeys.GetAppUserBranchIdListAsync}{createStockTransferDTO.SentBranchId}"
            });
            return new SuccessResult();
        }
        #endregion
        #region Update
        [TransactionScope]
        [ValidationAspect(typeof(UpdateStockTransferValidator))]
        public async Task<IResult> UpdateAsync(UpdateStockTransferDTO updateStockTransferDTO)
        {
            var result = await _stockTransferRepository.GetAsync(x=>x.Id == updateStockTransferDTO.Id);
            if (result is null)
                return new ErrorResult(StatusCodes.Status404NotFound, StockTransferMessages.StockTransferNotFound);

            var businessRuleResult = BusinessRules.Run(
                await _employeeBusinessRules.CheckEmployeeBranch(updateStockTransferDTO.TransactorAppUserId, updateStockTransferDTO.SenderBranchId),//Çalışanın şube çalışıp çalışmadığı kontrolü yapılıyor.
                await _employeeBusinessRules.CheckEmployeeBranch(updateStockTransferDTO.TransactorAppUserId, result.SenderBranchId),//Güncellenecek işlemdeki şubede çalışanın çalışıp çalışmadığı kontrol ediliyor.
                await _stockTransferBusinessRules.SenderBranchAndSentBranchExists(updateStockTransferDTO.SenderBranchId, updateStockTransferDTO.SentBranchId)
                );
            if (!businessRuleResult.Success)
                return businessRuleResult;


            //Yapılmış İşlem
            await _stockService.StockDeleteAsync(result.SentBranchId, result.ProductId, result.Quantity);//Gönderilen Şubedeki Stok Miktarı Silinir.
            await _stockService.StockAddedAsync(result.SenderBranchId, result.ProductId, result.Quantity);//Gönderen Şubeye Tekrardan Stok Miktarı Eklenir.

            //Yeni Yapılacak İşlem
            await _stockService.StockDeleteAsync(updateStockTransferDTO.SenderBranchId, updateStockTransferDTO.ProductId, updateStockTransferDTO.Quantity);//Güncelleme işlemindeki gönderen şubenin stoğundan miktar silinir.
            await _stockService.StockAddedAsync(updateStockTransferDTO.SentBranchId, updateStockTransferDTO.ProductId, updateStockTransferDTO.Quantity);//Güncelleme işlemindeki gönderilen şubenin stoğuna miktar eklenir.

            await _stockTransferRepository.UpdateAsync(_mapper.Map(updateStockTransferDTO, result));//Stok Transfer işlemi güncelleniyor.

            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                $"{StockTransferCacheKeys.GetByIdAsync}{updateStockTransferDTO.Id}",
                $"{StockTransferCacheKeys.GetAppUserBranchIdListAsync}{result.SenderBranchId}",
                $"{StockTransferCacheKeys.GetAppUserBranchIdListAsync}{result.SentBranchId}"
            });
            return new SuccessResult();
        }
        #endregion
        #region Delete
        [TransactionScope]
        public async Task<IResult> DeleteAsync(Guid Id, Guid appUserId)
        {
            var result = await _stockTransferRepository.GetAsync(x => x.Id == Id);
            if (result is null)
                return new ErrorResult(StatusCodes.Status404NotFound, StockTransferMessages.StockTransferNotFound);

            var businessRuleResult = BusinessRules.Run(await _employeeBusinessRules.CheckEmployeeBranch(appUserId, result.SenderBranchId));//İşlemi yapmak isteyenin bu şubede çalışıp çalışmadığı kontrol ediliyor.
            if (!businessRuleResult.Success)
                return businessRuleResult;

            result.TransactorAppUserId = appUserId;

            await _stockService.StockDeleteAsync(result.SentBranchId, result.ProductId, result.Quantity);//Gönderilen Şubedeki Stok Miktarı Silinir.
            await _stockService.StockAddedAsync(result.SenderBranchId, result.ProductId, result.Quantity);//Gönderen Şubeye Tekrardan Stok Miktarı Eklenir.

            await _stockTransferRepository.DeleteAsync(result);
            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                $"{StockTransferCacheKeys.GetByIdAsync}{Id}",
                $"{StockTransferCacheKeys.GetAppUserBranchIdListAsync}{result.SenderBranchId}",
                $"{StockTransferCacheKeys.GetAppUserBranchIdListAsync}{result.SentBranchId}"
            });
            return new SuccessResult();
        }
        #endregion
        #region Listed
        public async Task<IDataResult<IEnumerable<GetStockTransferListDTO>>> GetAllAsync()
        {
            var result = await _stockTransferRepository.GetAllWithIncludesAsync(
                includeProperties: new Expression<Func<StockTransfer, object>>[]
                {
                   senderBranch=>senderBranch.SenderBranch,
                    sentBranch =>sentBranch.SentBranch,
                    p=>p.Product,
                    ap=>ap.AppUser
                });

            return new SuccessDataResult<IEnumerable<GetStockTransferListDTO>>(
                _mapper.Map<IEnumerable<GetStockTransferListDTO>>(result.OrderByDescending(x => x.TransferDate)));
        }
        
        public async Task<IDataResult<IEnumerable<GetStockTransferListDTO>>> GetAppUserBranchIdListAsync(Guid appUserId)
        {
            var employee = await _employeeRepository.GetAsync(x=>x.AppUserId == appUserId);
            if (employee is null)
                return new ErrorDataResult<IEnumerable<GetStockTransferListDTO>>(StatusCodes.Status404NotFound, EmployeeMessages.EmployeeNotFound);

            IEnumerable<GetStockTransferListDTO>? getStockTransferListDTOs = await _cacheHelper.GetOrAddListAsync(
               $"{StockTransferCacheKeys.GetAppUserBranchIdListAsync}{employee.BranchId}",
               async () =>
               {
                   var result = await _stockTransferRepository.GetAllWithIncludesAsync(predicate: x => x.SenderBranchId == employee.BranchId || x.SentBranchId == employee.BranchId,
            includeProperties: new Expression<Func<StockTransfer, object>>[]
                {
                    senderBranch=>senderBranch.SenderBranch,
                    sentBranch =>sentBranch.SentBranch,
                    p=>p.Product,
                    ap=>ap.AppUser
                });

                   return result is null ? null : _mapper.Map<IEnumerable<GetStockTransferListDTO>>(result.OrderByDescending(x=>x.TransferDate));
               },
               30
                );

            return new SuccessDataResult<IEnumerable<GetStockTransferListDTO>>(getStockTransferListDTOs);
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetStockTransferDTO>> GetByIdAsync(Guid Id, Guid appUserId)
        {
            GetStockTransferDTO? getStockTransferDTO = await _cacheHelper.GetOrAddAsync(
                $"{StockTransferCacheKeys.GetByIdAsync}{Id}",
                async () =>
                {
                    var result = await _stockTransferRepository.GetAsync(x => x.Id == Id);
                    return result is null ? null : _mapper.Map<GetStockTransferDTO>(result);
                },
                30
                );
           
            if (getStockTransferDTO is null)
                return new ErrorDataResult<GetStockTransferDTO>(StatusCodes.Status404NotFound, StockTransferMessages.StockTransferNotFound);

            var result = BusinessRules.Run(
                await _employeeBusinessRules.CheckEmployeeBranch(appUserId,getStockTransferDTO.SenderBranchId)
                );
            if (!result.Success)
                return new ErrorDataResult<GetStockTransferDTO>(result.Status,result.Detail);


            return new SuccessDataResult<GetStockTransferDTO>(getStockTransferDTO);
        }
        #endregion
    }
}
