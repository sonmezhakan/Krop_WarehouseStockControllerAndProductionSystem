using Krop.DataAccess.Repositories.Abstracts.BaseRepository;
using Krop.Entities.Entities;

namespace Krop.DataAccess.Repositories.Abstracts
{
    public interface ICustomerRepository:IBaseRepository<Customer>,IBaseRepositoryAsync<Customer>
    {
        Task<IEnumerable<Customer>> GetAllComboBoxAsync();
    }
}
