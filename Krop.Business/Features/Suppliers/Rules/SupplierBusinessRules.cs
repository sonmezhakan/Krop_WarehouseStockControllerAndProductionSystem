using Krop.Business.Features.Suppliers.ExceptionHelpers;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.Business.Features.Suppliers.Rules
{
    public class SupplierBusinessRules
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly SupplierExceptionHelper _supplierExceptionHelper;

        public SupplierBusinessRules(ISupplierRepository supplierRepository,SupplierExceptionHelper supplierExceptionHelper)
        {
            _supplierRepository = supplierRepository;
            _supplierExceptionHelper = supplierExceptionHelper;
        }

        public async Task<Supplier> CheckBySupplierId(Guid id)
        {
            var result = await _supplierRepository.GetAsync(s => s.Id == id);
            if (result is null)
                _supplierExceptionHelper.ThrowSupplierNotFound();

            return result;
        }
    }
}
