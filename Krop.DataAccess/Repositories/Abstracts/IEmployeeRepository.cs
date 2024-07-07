using Krop.DataAccess.Repositories.Abstracts.BaseRepository;
using Krop.Entities.Entities;
using System.Linq.Expressions;

namespace Krop.DataAccess.Repositories.Abstracts
{
    public interface IEmployeeRepository:IBaseRepository<Employee>,IBaseRepositoryAsync<Employee>
    {
        Task<IEnumerable<Employee>> GetAllComboBoxAsync();
        Task<List<Employee>> GetAllWithIncludesAsync(Expression<Func<Employee, bool>> predicate = null,
            params Expression<Func<Employee, object>>[] includeProperties);
        Task<Employee> GetIcludesAsync(Expression<Func<Employee, bool>> predicate = null,
            params Expression<Func<Employee, object>>[] includeProperties);
    }
}
