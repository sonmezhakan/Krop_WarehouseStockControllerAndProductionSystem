using AutoMapper;
using Krop.Business.Features.Suppliers.Rules;
using Krop.Business.Features.Suppliers.Validations;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DataAccess.UnitOfWork;
using Krop.DTO.Dtos.Suppliers;
using Krop.Entities.Entities;

namespace Krop.Business.Services.Suppliers
{
    public class SupplierManager : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        private readonly SupplierBusinessRules _supplierBusinessRules;
        private readonly IUnitOfWork _unitOfWork;

        public SupplierManager(ISupplierRepository supplierRepository,IMapper mapper,SupplierBusinessRules supplierBusinessRules,IUnitOfWork unitOfWork)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
            _supplierBusinessRules = supplierBusinessRules;
            _unitOfWork = unitOfWork;
        }
        #region Add
       
        public async Task<IResult> AddAsync(CreateSupplierDTO createSupplierDTO)
        {
            Supplier result = _mapper.Map<Supplier>(createSupplierDTO);
            await _supplierRepository.AddAsync(result);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult();
        }
        #endregion
        #region Update
        
        public async Task<IResult> UpdateAsync(UpdateSupplierDTO updateSupplierDTO)
        {
            var result = await _supplierBusinessRules.CheckBySupplierId(updateSupplierDTO.Id);
            if (!result.Success)
                return result;

            Supplier supplier = _mapper.Map(updateSupplierDTO,result.Data);
            await _supplierRepository.UpdateAsync(supplier);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult();
        }
        #endregion
        #region Delete
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var result = await _supplierBusinessRules.CheckBySupplierId(id);
            if (!result.Success)
                return result;

            await _supplierRepository.DeleteAsync(result.Data);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult();
        }
        #endregion
        #region Listed
        public async Task<IDataResult<IEnumerable<GetSupplierDTO>>> GetAllAsync()
        {
            var result = await _supplierRepository.GetAllAsync();

            return new SuccessDataResult<IEnumerable<GetSupplierDTO>>(
                _mapper.Map<List<GetSupplierDTO>>(result));
        }

        public async Task<IDataResult<IEnumerable<GetSupplierComboBoxDTO>>> GetAllComboBoxAsync()
        {
            var result = await _supplierRepository.GetAllComboBoxAsync();
            return new SuccessDataResult<IEnumerable<GetSupplierComboBoxDTO>>(
                _mapper.Map<List<GetSupplierComboBoxDTO>>(result));
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetSupplierDTO>> GetByIdAsync(Guid id)
        {
            var result = await _supplierBusinessRules.CheckBySupplierId(id);
            if (!result.Success)
                return new ErrorDataResult<GetSupplierDTO>(result.Status,result.Detail);

            return new SuccessDataResult<GetSupplierDTO>(
                _mapper.Map<GetSupplierDTO>(result.Data));
        }
   
        #endregion
    }
}
