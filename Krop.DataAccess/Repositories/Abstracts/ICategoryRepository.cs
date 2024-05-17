using Krop.DataAccess.Repositories.Abstracts.BaseRepository;
using Krop.Entities.Entities;

namespace Krop.DataAccess.Repositories.Abstracts
{
    public interface ICategoryRepository:IBaseRepository<Category>,IBaseRepositoryAsync<Category>
    {
    }
}
