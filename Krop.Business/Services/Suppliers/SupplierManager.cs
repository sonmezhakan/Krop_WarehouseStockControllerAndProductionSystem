using AutoMapper;
using Krop.Business.Features.Suppliers.Dtos;
using Krop.Business.Features.Suppliers.ExceptionHelpers;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.Business.Services.Suppliers
{
    public class SupplierManager : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        private readonly SupplierExceptionHelper _supplierExceptionHelper;

        public SupplierManager(ISupplierRepository supplierRepository,IMapper mapper,SupplierExceptionHelper supplierExceptionHelper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
            _supplierExceptionHelper = supplierExceptionHelper;
        }
        #region Add
        public async Task<bool> AddAsync(CreateSupplierDTO createSupplierDTO)
        {
            Supplier supplier = _mapper.Map<Supplier>(createSupplierDTO);

            return await _supplierRepository.AddAsync(supplier);
        }
        #endregion
        #region Update
        public async Task<bool> UpdateAsync(UpdateSupplierDTO updateSupplierDTO)
        {
            Supplier supplier = await _supplierRepository.FindAsync(updateSupplierDTO.Id);
            if (supplier is null)
                _supplierExceptionHelper.ThrowSupplierNotFound();

            supplier = _mapper.Map(updateSupplierDTO,supplier);

            return await _supplierRepository.UpdateAsync(supplier);
        }
        #endregion
        #region Delete
        public async Task<bool> DeleteAsync(Guid id)
        {
            Supplier supplier = await _supplierRepository.FindAsync(id);
            if (supplier is null)
                _supplierExceptionHelper.ThrowSupplierNotFound();

            return await _supplierRepository.DeleteAsync(supplier);
        }
        #endregion
        #region Listed
        public async Task<IEnumerable<GetSupplierDTO>> GetAllAsync()
        {
            var result = await _supplierRepository.GetAllAsync();

            return _mapper.Map<List<GetSupplierDTO>>(result);
        }
        #endregion
        #region Search
        public async Task<GetSupplierDTO> GetByIdAsync(Guid id)
        {
            Supplier supplier = await _supplierRepository.FindAsync(id);
            if (supplier is null)
                _supplierExceptionHelper.ThrowSupplierNotFound();

            return _mapper.Map<GetSupplierDTO>(supplier);
        }
        #endregion
    }
}
