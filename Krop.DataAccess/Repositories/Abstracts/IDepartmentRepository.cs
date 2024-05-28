using Krop.DataAccess.Repositories.Abstracts.BaseRepository;
using Krop.Entities.Entities;

namespace Krop.DataAccess.Repositories.Abstracts
{
    public interface IDepartmentRepository:IBaseRepository<Department>,IBaseRepositoryAsync<Department>
    {
        Task<IEnumerable<Department>> GetAllComboBoxAsync();
    }
}
