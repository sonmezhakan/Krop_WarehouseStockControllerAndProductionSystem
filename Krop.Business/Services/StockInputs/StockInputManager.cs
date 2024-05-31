using AutoMapper;
using Krop.Business.Features.Branches.Rules;
using Krop.Business.Features.Employees.Rules;
using Krop.Business.Features.Products.Rules;
using Krop.Business.Features.StockInputs.Dtos;
using Krop.Business.Features.StockInputs.Rules;
using Krop.Business.Features.StockInputs.Validation;
using Krop.Business.Features.Suppliers.Rules;
using Krop.Business.Services.Stocks;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using System.Linq.Expressions;

namespace Krop.Business.Services.StockInputs
{
    public class StockInputManager : IStockInputService
    {
        private readonly IStockInputRepository _stockInputRepository;
        private readonly IMapper _mapper;
        private readonly BranchBusinessRules _branchBusinessRules;
        private readonly SupplierBusinessRules _supplierBusinessRules;
        private readonly EmployeeBusinessRules _employeeBusinessRules;
        private readonly ProductBusinessRules _productBusinessRules;
        private readonly IStockService _stockService;
        private readonly StockInputBusinessRules _stockInputBusinessRules;

        public StockInputManager(IStockInputRepository stockInputRepository,IMapper mapper,
            BranchBusinessRules branchBusinessRules,SupplierBusinessRules supplierBusinessRules, EmployeeBusinessRules employeeBusinessRules, ProductBusinessRules productBusinessRules, IStockService stockService, StockInputBusinessRules stockInputBusinessRules
            )
        {
            _stockInputRepository = stockInputRepository;
            _mapper = mapper;
            _branchBusinessRules = branchBusinessRules;
            _supplierBusinessRules = supplierBusinessRules;
            _employeeBusinessRules = employeeBusinessRules;
            _productBusinessRules = productBusinessRules;
            _stockService = stockService;
            _stockInputBusinessRules = stockInputBusinessRules;
        }
        [ValidationAspect(typeof(CreateStockInputValidator))]
        public async Task<IResult> AddAsync(CreateStockInputDTO createStockInputDTO)
        {
            await _employeeBusinessRules.CheckEmployeeBranch(createStockInputDTO.AppUserId, createStockInputDTO.BranchId);//Çalışanın bu şubede yetkisi olup olmadığı kontrol ediliyor.
            await _productBusinessRules.CheckByProductId(createStockInputDTO.ProductId);//Product Business Rule
            await _branchBusinessRules.CheckByBranchId(createStockInputDTO.BranchId);//Branch Business Rule
            await _supplierBusinessRules.CheckBySupplierId(createStockInputDTO.SupplierId);//Supplier Business Rule
            await _employeeBusinessRules.CheckByEmployeeId(createStockInputDTO.AppUserId);//Employee Business Rule
            

            await _stockService.StockInputUpdateAsync(createStockInputDTO.BranchId,createStockInputDTO.ProductId,createStockInputDTO.Quantity);//Stoğa ekliyor

            await _stockInputRepository.AddAsync(_mapper.Map<StockInput>(createStockInputDTO));

            return new SuccessResult();
        }
        [ValidationAspect(typeof(UpdateStockInputValidator))]
        public async Task<IResult> UpdateAsync(UpdateStockInputDTO updateStockInputDTO)
        {
            await _employeeBusinessRules.CheckEmployeeBranch(updateStockInputDTO.AppUserId, updateStockInputDTO.BranchId);//Çalışanın bu şubede yetkisi olup olmadığı kontrol ediliyor.
            await _productBusinessRules.CheckByProductId(updateStockInputDTO.ProductId);//Product Business Rule
            await _branchBusinessRules.CheckByBranchId(updateStockInputDTO.BranchId);//Branch Business Rule
            await _supplierBusinessRules.CheckBySupplierId(updateStockInputDTO.SupplierId);//Supplier Business Rule
            await _employeeBusinessRules.CheckByEmployeeId(updateStockInputDTO.AppUserId);//Employee Business Rule

            var result = await _stockInputBusinessRules.CheckStockInput(updateStockInputDTO.Id);//Stok Girişi yapılıp yapılmadığı kontrol ediliyor. Eğer stok giriş yapılmış ise StockInput olarak getiriyor.

            await _stockService.StockDeleteAsync(result.BranchId, result.ProductId, result.Quantity);//Şube değişikliği veya ürün değişikliği yapılırsa diye ilk önce stoktan miktarı çıkarmamız gerekiyor.
            await _stockService.StockInputUpdateAsync(updateStockInputDTO.BranchId, updateStockInputDTO.ProductId, updateStockInputDTO.Quantity);//Stoğa ekliyor

            result = _mapper.Map(updateStockInputDTO, result);//Veritabanındaki bilgileri güncellenecek bilgiler ile değiştiriyor

            await _stockInputRepository.UpdateAsync(result);//Stok girişi işlemini güncelliyor.

           return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Guid Id)
        {
            var result = await _stockInputBusinessRules.CheckStockInput(Id);//Stok Girişi yapılıp yapılmadığı kontrol ediliyor. Eğer stok giriş yapılmış ise StockInput olarak getiriyor.

            await _employeeBusinessRules.CheckEmployeeBranch(result.AppUserId, result.BranchId);//Çalışanın bu şubede yetkisi olup olmadığı kontrol ediliyor.
            await _productBusinessRules.CheckByProductId(result.ProductId);//Product Business Rule
            await _branchBusinessRules.CheckByBranchId(result.BranchId);//Branch Business Rule
            await _supplierBusinessRules.CheckBySupplierId(result.SupplierId);//Supplier Business Rule
            await _employeeBusinessRules.CheckByEmployeeId(result.AppUserId);//Employee Business Rule

            await _stockService.StockDeleteAsync(result.BranchId, result.ProductId, result.Quantity);//Şube değişikliği veya ürün değişikliği yapılırsa diye ilk önce stoktan miktarı çıkarmamız gerekiyor.

            await _stockInputRepository.DeleteAsync(result);//Stok girişinden siliyor.

            return new SuccessResult();
        }

        public async Task<IDataResult<IEnumerable<GetStockInputListDTO>>> GetAllAsync()
        {
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
