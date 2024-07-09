using Krop.DataAccess.Repositories.Abstracts.BaseRepository;
using Krop.Entities.Entities;
using System.Linq.Expressions;

namespace Krop.DataAccess.Repositories.Abstracts
{
    public interface IEmployeeRepository:IBaseRepository<Employee>,IBaseRepositoryAsync<Employee>
    {
        Task<IEnumerable<Employee>> GetAllComboBoxAsync();
    }
}
