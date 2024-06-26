﻿using Krop.DataAccess.Repositories.Abstracts.BaseRepository;
using Krop.Entities.Entities;

namespace Krop.DataAccess.Repositories.Abstracts
{
    public interface IBranchRepository:IBaseRepository<Branch>,IBaseRepositoryAsync<Branch>
    {
        Task<List<Guid>> GetAllBranchIdAsync();
        Task<IEnumerable<Branch>> GetAllComboBoxAsync(Func<Branch,bool> predicate = null);
    }
}
