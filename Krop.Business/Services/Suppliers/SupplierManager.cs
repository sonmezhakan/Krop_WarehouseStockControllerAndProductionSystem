using AutoMapper;
using Krop.Business.Features.Suppliers.Rules;
using Krop.Business.Features.Suppliers.Validations;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DTO.Dtos.Suppliers;
using Krop.Entities.Entities;

namespace Krop.Business.Services.Suppliers
{
    public class SupplierManager : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        private readonly SupplierBusinessRules _supplierBusinessRules;

        public SupplierManager(ISupplierRepository supplierRepository,IMapper mapper,SupplierBusinessRules supplierBusinessRules)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
            _supplierBusinessRules = supplierBusinessRules;
        }
        #region Add
        [ValidationAspect(typeof(CreateSupplierValidation))]
        public async Task<IResult> AddAsync(CreateSupplierDTO createSupplierDTO)
        {
            Supplier result = _mapper.Map<Supplier>(createSupplierDTO);
            await _supplierRepository.AddAsync(result);

            return new SuccessResult();
        }
        #endregion
        #region Update
        [ValidationAspect(typeof(UpdateSupplierValidator))]
        public async Task<IResult> UpdateAsync(UpdateSupplierDTO updateSupplierDTO)
        {
            var supplier = await _supplierBusinessRules.CheckBySupplierId(updateSupplierDTO.Id);

            supplier = _mapper.Map(updateSupplierDTO,supplier);
            await _supplierRepository.UpdateAsync(supplier);

            return new SuccessResult();
        }
        #endregion
        #region Delete
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var supplier = await _supplierBusinessRules.CheckBySupplierId(id);

            await _supplierRepository.DeleteAsync(supplier);
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
            var supplier = await _supplierBusinessRules.CheckBySupplierId(id);

            return new SuccessDataResult<GetSupplierDTO>(
                _mapper.Map<GetSupplierDTO>(supplier));
        }
   
        #endregion
    }
}
