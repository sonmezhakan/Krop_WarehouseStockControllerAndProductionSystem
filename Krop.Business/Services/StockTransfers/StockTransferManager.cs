using AutoMapper;
using Krop.Business.Features.Branches.Rules;
using Krop.Business.Features.Employees.Rules;
using Krop.Business.Features.Products.Rules;
using Krop.Business.Features.StockTransfers.Rules;
using Krop.Business.Services.Stocks;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DTO.Dtos.StockTransfers;
using Krop.Entities.Entities;
using System.Linq.Expressions;

namespace Krop.Business.Services.StockTransfers
{
    public class StockTransferManager : IStockTransferService
    {
        private readonly IStockTransferRepository _stockTransferRepository;
        private readonly IStockService _stockService;
        private readonly IMapper _mapper;
        private readonly BranchBusinessRules _branchBusinessRules;
        private readonly EmployeeBusinessRules _employeeBusinessRules;
        private readonly ProductBusinessRules _productBusinessRules;
        private readonly StockTransferBusinessRules _stockTransferBusinessRules;

        public StockTransferManager(IStockTransferRepository stockTransferRepository, IStockService stockService,IMapper mapper, BranchBusinessRules branchBusinessRules,EmployeeBusinessRules employeeBusinessRules,ProductBusinessRules productBusinessRules,StockTransferBusinessRules stockTransferBusinessRules)
        {
            _stockTransferRepository = stockTransferRepository;
            _stockService = stockService;
            _mapper = mapper;
            _branchBusinessRules = branchBusinessRules;
            _employeeBusinessRules = employeeBusinessRules;
            _productBusinessRules = productBusinessRules;
            _stockTransferBusinessRules = stockTransferBusinessRules;
        }
        public async Task<IResult> AddAsync(CreateStockTransferDTO createStockTransferDTO)
        {
            await _employeeBusinessRules.CheckEmployeeBranch(createStockTransferDTO.TransactorAppUserId, createStockTransferDTO.SenderBranchId);//Çalışanın şube çalışıp çalışmadığı kontrolü yapılıyor.

            await _stockService.StockDeleteAsync(createStockTransferDTO.SenderBranchId, createStockTransferDTO.ProductId, createStockTransferDTO.Quantity);//Gönderen Şubeden Miktar Siliniyor.
            await _stockService.StockAddedAsync(createStockTransferDTO.SentBranchId, createStockTransferDTO.ProductId, createStockTransferDTO.Quantity);//Gönderilen Şubeye Stok Ekleniyor.

            await _stockTransferRepository.AddAsync(_mapper.Map<StockTransfer>(createStockTransferDTO));

            return new SuccessResult();
        }
        public async Task<IResult> UpdateAsync(UpdateStockTransferDTO updateStockTransferDTO)
        {
            var result = await _stockTransferBusinessRules.CheckByStockTransferId(updateStockTransferDTO.Id);

            await _employeeBusinessRules.CheckEmployeeBranch(updateStockTransferDTO.TransactorAppUserId, updateStockTransferDTO.TransactorAppUserId);//Çalışanın şube çalışıp çalışmadığı kontrolü yapılıyor.

            //Yapılmış İşlem
            await _stockService.StockDeleteAsync(result.SentBranchId,result.ProductId,result.Quantity);//Gönderilen Şubedeki Stok Miktarı Silinir.
            await _stockService.StockAddedAsync(result.SenderBranchId,result.ProductId,result.Quantity);//Gönderen Şubeye Tekrardan Stok Miktarı Eklenir.

            //Yeni Yapılacak İşlem
            await _stockService.StockDeleteAsync(updateStockTransferDTO.SenderBranchId, updateStockTransferDTO.ProductId, updateStockTransferDTO.Quantity);//Güncelleme işlemindeki gönderen şubenin stoğundan miktar silinir.
            await _stockService.StockAddedAsync(updateStockTransferDTO.SentBranchId,updateStockTransferDTO.ProductId,updateStockTransferDTO.Quantity);//Güncelleme işlemindeki gönderilen şubenin stoğuna miktar eklenir.

            await _stockTransferRepository.UpdateAsync(_mapper.Map(updateStockTransferDTO, result));//Stok Transfer işlemi güncelleniyor.

            return new SuccessResult();

        }
        public async Task<IResult> DeleteAsync(Guid Id, Guid appUserId)
        {
            var result = await _stockTransferBusinessRules.CheckByStockTransferId(Id);

            await _employeeBusinessRules.CheckEmployeeBranch(appUserId, result.SenderBranchId);//İşlemi yapmak isteyenin bu şubede çalışıp çalışmadığı kontrol ediliyor.

            result.TransactorAppUserId = appUserId;

            await _stockService.StockDeleteAsync(result.SentBranchId, result.ProductId, result.Quantity);//Gönderilen Şubedeki Stok Miktarı Silinir.
            await _stockService.StockAddedAsync(result.SenderBranchId, result.ProductId, result.Quantity);//Gönderen Şubeye Tekrardan Stok Miktarı Eklenir.

            await _stockTransferRepository.DeleteAsync(result);

            return new SuccessResult();
        }

        public async Task<IDataResult<IEnumerable<GetStockTransferListDTO>>> GetAllAsync()
        {
            var result = await _stockTransferRepository.GetAllAsync(
                includeProperties:new Expression<Func<StockTransfer, object>>[]
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
           var employee= await _employeeBusinessRules.CheckByEmployeeId(appUserId);

            var result = await _stockTransferRepository.GetAllAsync(predicate:x=>x.SenderBranchId == employee.BranchId || x.SentBranchId == employee.BranchId,
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
        public async Task<IDataResult<GetStockTransferDTO>> GetByIdAsync(Guid Id,Guid appUserId)
        {
            var result = await _stockTransferRepository.GetAsync(x => x.Id == Id);

            await _employeeBusinessRules.CheckEmployeeSenderAndSentBranch(appUserId,result.SenderBranchId,result.SentBranchId);

            return new SuccessDataResult<GetStockTransferDTO>(
                _mapper.Map<GetStockTransferDTO>(result));
        }        
    }
}
