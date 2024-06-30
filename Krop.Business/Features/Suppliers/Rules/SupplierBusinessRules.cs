using Krop.DataAccess.Repositories.Abstracts;

namespace Krop.Business.Features.Suppliers.Rules
{
    public class SupplierBusinessRules
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierBusinessRules(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
    }
}
