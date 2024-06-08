using Krop.Business.Features.Suppliers.Constants;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;

namespace Krop.Business.Features.Suppliers.Rules
{
    public class SupplierBusinessRules
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierBusinessRules(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<IDataResult<Supplier>> CheckBySupplierId(Guid id)
        {
            var result = await _supplierRepository.GetAsync(s => s.Id == id);
            if (result is null)
                return new ErrorDataResult<Supplier>(StatusCodes.Status404NotFound, SupplierMessages.SupplierNotFound);

            return new SuccessDataResult<Supplier>(result);
        }
    }
}
