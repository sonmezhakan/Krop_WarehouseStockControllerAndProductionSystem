using AutoMapper;
using Krop.Business.Features.Employees.Rules;
using Krop.Business.Features.StockInputs.Rules;
using Krop.Business.Features.StockInputs.Validation;
using Krop.Business.Services.Stocks;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DTO.Dtos.StockInputs;
using Krop.Entities.Entities;
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

        public StockInputManager(IStockInputRepository stockInputRepository,IMapper mapper,
            EmployeeBusinessRules employeeBusinessRules, IStockService stockService, StockInputBusinessRules stockInputBusinessRules
            )
        {
            _stockInputRepository = stockInputRepository;
            _mapper = mapper;
            _employeeBusinessRules = employeeBusinessRules;
            _stockService = stockService;
            _stockInputBusinessRules = stockInputBusinessRules;
        }
        [ValidationAspect(typeof(CreateStockInputValidator))]
        public async Task<IResult> AddAsync(CreateStockInputDTO createStockInputDTO)
        {
            await _employeeBusinessRules.CheckEmployeeBranch(createStockInputDTO.AppUserId, createStockInputDTO.BranchId);//Çalışanın şube çalışıp çalışmadığı kontrolü yapılıyor. 

            await _stockService.StockAddedAsync(createStockInputDTO.BranchId,createStockInputDTO.ProductId,createStockInputDTO.Quantity);//Stoğa ekliyor

            await _stockInputRepository.AddAsync(
                _mapper.Map<StockInput>(createStockInputDTO));

            return new SuccessResult();
        }
        [ValidationAspect(typeof(UpdateStockInputValidator))]
        public async Task<IResult> UpdateAsync(UpdateStockInputDTO updateStockInputDTO)
        {
            var result = await _stockInputBusinessRules.CheckStockInput(updateStockInputDTO.Id);//Stok Girişi yapılıp yapılmadığı kontrol ediliyor. Eğer stok giriş yapılmış ise StockInput olarak getiriyor.

            await _employeeBusinessRules.CheckEmployeeBranch(updateStockInputDTO.AppUserId, updateStockInputDTO.BranchId);//Çalışanın şube çalışıp çalışmadığı kontrolü yapılıyor.


            await _stockService.StockDeleteAsync(result.BranchId, result.ProductId, result.Quantity);//Şube değişikliği veya ürün değişikliği yapılırsa diye ilk önce stoktan miktarı çıkarmamız gerekiyor.
            await _stockService.StockAddedAsync(updateStockInputDTO.BranchId, updateStockInputDTO.ProductId, updateStockInputDTO.Quantity);//Stoğa ekliyor

            result = _mapper.Map(updateStockInputDTO, result);//Veritabanındaki bilgileri güncellenecek bilgiler ile değiştiriyor

            await _stockInputRepository.UpdateAsync(result);//Stok girişi işlemini güncelliyor.

           return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Guid id, Guid appUserId)
        {
            var result = await _stockInputBusinessRules.CheckStockInput(id);//Stok Girişi yapılıp yapılmadığı kontrol ediliyor. Eğer stok giriş yapılmış ise StockInput olarak getiriyor.

            await _employeeBusinessRules.CheckEmployeeBranch(appUserId, result.BranchId);//Çalışanın şube çalışıp çalışmadığı kontrolü yapılıyor.

            await _stockService.StockDeleteAsync(result.BranchId, result.ProductId, result.Quantity);//Şube değişikliği veya ürün değişikliği yapılırsa diye ilk önce stoktan miktarı çıkarmamız gerekiyor.

            await _stockInputRepository.DeleteAsync(result);//Stok girişinden siliyor.

            return new SuccessResult();
        }

        public async Task<IDataResult<IEnumerable<GetStockInputListDTO>>> GetAllAsync(Guid appUserId)
        {
            var employee =await _employeeBusinessRules.CheckByEmployeeId(appUserId);
            await _employeeBusinessRules.CheckEmployeeBranch(appUserId, (Guid)employee.BranchId);
            var result = await _stockInputRepository.GetAllAsync(includeProperties:new Expression<Func<StockInput, object>>[]
            {
                p=>p.Product,
                s=>s.Supplier,
                b=>b.Branch,
                au=>au.AppUser
            });

            return new SuccessDataResult<IEnumerable<GetStockInputListDTO>>(
                _mapper.Map<IEnumerable<GetStockInputListDTO>>(result));
        }

        public async Task<IDataResult<GetStockInputDTO>> GetByIdAsync(Guid id)
        {
            var result = await _stockInputBusinessRules.CheckStockInput(id);//Stok Girişi yapılıp yapılmadığı kontrol ediliyor. Eğer stok giriş yapılmış ise StockInput olarak getiriyor.

            return new SuccessDataResult<GetStockInputDTO>(
                _mapper.Map<GetStockInputDTO>(result));
        }
    }
}
