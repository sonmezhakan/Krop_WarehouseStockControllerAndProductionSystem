using AutoMapper;
using Krop.Business.Exceptions.Middlewares.Transaction;
using Krop.Business.Features.Employees.Rules;
using Krop.Business.Features.StockTransfers.Constants;
using Krop.Business.Features.StockTransfers.Rules;
using Krop.Business.Services.Stocks;
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

        public StockTransferManager(IStockTransferRepository stockTransferRepository, IStockService stockService,IMapper mapper, EmployeeBusinessRules employeeBusinessRules,StockTransferBusinessRules stockTransferBusinessRules,IUnitOfWork unitOfWork)
        {
            _stockTransferRepository = stockTransferRepository;
            _stockService = stockService;
            _mapper = mapper;
            _employeeBusinessRules = employeeBusinessRules;
            _stockTransferBusinessRules = stockTransferBusinessRules;
            _unitOfWork = unitOfWork;
        }
        #region Add
        [TransactionScope]
        public async Task<IResult> AddAsync(CreateStockTransferDTO createStockTransferDTO)
        {
            var result = BusinessRules.Run(await _employeeBusinessRules.CheckEmployeeBranch(createStockTransferDTO.TransactorAppUserId, createStockTransferDTO.SenderBranchId));
            if (!result.Success)
                return result;

            await _stockService.StockDeleteAsync(createStockTransferDTO.SenderBranchId, createStockTransferDTO.ProductId, createStockTransferDTO.Quantity);//Gönderen Şubeden Miktar Siliniyor.
            await _stockService.StockAddedAsync(createStockTransferDTO.SentBranchId, createStockTransferDTO.ProductId, createStockTransferDTO.Quantity);//Gönderilen Şubeye Stok Ekleniyor.

            await _stockTransferRepository.AddAsync(_mapper.Map<StockTransfer>(createStockTransferDTO));
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult();
        }
        #endregion
        #region Update
        [TransactionScope]
        public async Task<IResult> UpdateAsync(UpdateStockTransferDTO updateStockTransferDTO)
        {
            var result = await _stockTransferBusinessRules.CheckByStockTransferId(updateStockTransferDTO.Id);
            if (!result.Success)
                return result;

            var businessRuleResult = BusinessRules.Run(
                await _employeeBusinessRules.CheckEmployeeBranch(updateStockTransferDTO.TransactorAppUserId, updateStockTransferDTO.SenderBranchId),//Çalışanın şube çalışıp çalışmadığı kontrolü yapılıyor.
                await _employeeBusinessRules.CheckEmployeeBranch(updateStockTransferDTO.TransactorAppUserId, result.Data.SenderBranchId)//Güncellenecek işlemdeki şubede çalışanın çalışıp çalışmadığı kontrol ediliyor.
                );
            if (!businessRuleResult.Success)
                return result;


            //Yapılmış İşlem
            await _stockService.StockDeleteAsync(result.Data.SentBranchId, result.Data.ProductId, result.Data.Quantity);//Gönderilen Şubedeki Stok Miktarı Silinir.
            await _stockService.StockAddedAsync(result.Data.SenderBranchId, result.Data.ProductId, result.Data.Quantity);//Gönderen Şubeye Tekrardan Stok Miktarı Eklenir.

            //Yeni Yapılacak İşlem
            await _stockService.StockDeleteAsync(updateStockTransferDTO.SenderBranchId, updateStockTransferDTO.ProductId, updateStockTransferDTO.Quantity);//Güncelleme işlemindeki gönderen şubenin stoğundan miktar silinir.
            await _stockService.StockAddedAsync(updateStockTransferDTO.SentBranchId, updateStockTransferDTO.ProductId, updateStockTransferDTO.Quantity);//Güncelleme işlemindeki gönderilen şubenin stoğuna miktar eklenir.

            await _stockTransferRepository.UpdateAsync(_mapper.Map(updateStockTransferDTO, result.Data));//Stok Transfer işlemi güncelleniyor.

            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult();
        }
        #endregion
        #region Delete
        [TransactionScope]
        public async Task<IResult> DeleteAsync(Guid Id, Guid appUserId)
        {
            var result = await _stockTransferBusinessRules.CheckByStockTransferId(Id);
            if (!result.Success)
                return result;

            var businessRuleResult = BusinessRules.Run(await _employeeBusinessRules.CheckEmployeeBranch(appUserId, result.Data.SenderBranchId));//İşlemi yapmak isteyenin bu şubede çalışıp çalışmadığı kontrol ediliyor.
            if (!businessRuleResult.Success)
                return businessRuleResult;

            result.Data.TransactorAppUserId = appUserId;

            await _stockService.StockDeleteAsync(result.Data.SentBranchId, result.Data.ProductId, result.Data.Quantity);//Gönderilen Şubedeki Stok Miktarı Silinir.
            await _stockService.StockAddedAsync(result.Data.SenderBranchId, result.Data.ProductId, result.Data.Quantity);//Gönderen Şubeye Tekrardan Stok Miktarı Eklenir.

            await _stockTransferRepository.DeleteAsync(result.Data);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult();
        }
        #endregion
        #region Listed
        public async Task<IDataResult<IEnumerable<GetStockTransferListDTO>>> GetAllAsync()
        {
            var result = await _stockTransferRepository.GetAllAsync(
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
        public async Task<IDataResult<IEnumerable<GetStockTransferListDTO>>> AppUserBranchGetAllAsync(Guid appUserId)
        {
            var employee = await _employeeBusinessRules.CheckByEmployeeId(appUserId);
            if (employee == null)
                return new ErrorDataResult<IEnumerable<GetStockTransferListDTO>>(employee.Status, employee.Detail);

            var result = await _stockTransferRepository.GetAllAsync(predicate: x => x.SenderBranchId == employee.Data.BranchId || x.SentBranchId == employee.Data.BranchId,
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
        #endregion
        #region Search
        public async Task<IDataResult<GetStockTransferDTO>> GetByIdAsync(Guid Id, Guid appUserId)
        {
            var result = await _stockTransferRepository.GetAsync(x => x.Id == Id);
            if (result is null)
                return new ErrorDataResult<GetStockTransferDTO>(StatusCodes.Status404NotFound, StockTransferMessages.StockTransferNotFound);

            await _employeeBusinessRules.CheckEmployeeSenderAndSentBranch(appUserId, result.SenderBranchId, result.SentBranchId);

            return new SuccessDataResult<GetStockTransferDTO>(
                _mapper.Map<GetStockTransferDTO>(result));
        }
        #endregion
    }
}
