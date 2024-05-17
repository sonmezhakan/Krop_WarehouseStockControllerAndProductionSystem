using Krop.Common.Helpers.IpAddress;
using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts.BaseRepository;
using Krop.Entities.Enums;
using Krop.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Krop.DataAccess.Repositories.Concretes.EntityFramework
{
    //Asenkron olmayan BaseRepository
    public partial class EfBaseRepository<T> : IBaseRepository<T> where T : class, IEntity<Guid>, new()
    {
        private readonly KropContext _context;
        private readonly DbSet<T> _entities;

        public EfBaseRepository(KropContext context)
        {
            _context = context;
            _entities = context.Set<T>();//Generic olan nesnenin tipini _entities fieldına aktarıyoruz.
        }

        #region Add
        /// <summary>
        /// Yeni bir nesne ekleme.
        /// </summary>
        /// <param name="entity">Eklenecek nesne.</param>
        /// <returns>İşlem başarılı ise True, başarısız ise False döner.</returns>
        public bool Add(T entity)
        {
            ShadowPropertyAdd(entity); //ShadowPropertylerin değerleri atanıyor.
            
            _entities.Add(entity);
            return ResultReturn(_context.SaveChanges());
        }

        /// <summary>
        /// Liste halinde yeni nesne ekleme.
        /// </summary>
        /// <param name="entities">Eklenecek nesneler.</param>
        /// <returns>İşlem başarılı ise True, başarısız ise False döner.</returns>
        public bool AddRange(List<T> entities)
        {

            entities.ForEach(e => { ShadowPropertyAdd(e); }); //ShadowPropertylerin değerleri atanıyor.

            _entities.AddRange(entities);
            return ResultReturn(_context.SaveChanges());
        }
        #endregion
        #region Update
        /// <summary>
        /// Nesne güncelleme işlemi.
        /// </summary>
        /// <param name="entity">Güncellenecek nesne.</param>
        /// <returns>Güncelleme başarılı ise True, başarısız ise false döner.</returns>
        public bool Update(T entity)
        {
            ShadowPropertyUpdated(entity); //ShadowPropertylerin değerleri atanıyor.

            _entities.Update(entity);
            return ResultReturn(_context.SaveChanges());
        }

        /// <summary>
        /// Liste halinde güncelleme işlemi.
        /// </summary>
        /// <param name="entities">Güncellenecek nesneler.</param>
        /// <returns>Güncelleme başarılı ise True, başarısız ise false döner.</returns>
        public bool UpdateRange(List<T> entities)
        {
            entities.ForEach(e=> { ShadowPropertyUpdated(e); }); //ShadowPropertylerin değerleri atanıyor.

            _entities.UpdateRange(entities);
            return ResultReturn(_context.SaveChanges());
        }
        #endregion
        #region Delete
        /// <summary>
        /// Nesne silme işlemi. Silme işlemleri Soft Delete olarak yapılmaktadır.
        /// </summary>
        /// <param name="entity">Silinecek nesne.</param>
        /// <returns>Silme başarılı ise True, başarısız ise false döner.</returns>
        public bool Delete(T entity)
        {
            ShadowPropertyDeleted(entity); //ShadowPropertylerin değerleri atanıyor.

            _entities.Remove(entity);
            return ResultReturn(_context.SaveChanges());
        }

        /// <summary>
        /// Nesne silme işlemi. Silme işlemleri Soft Delete olarak yapılmaktadır.
        /// </summary>
        /// <param name="entities">Silinecek nesneler.</param>
        /// <returns>Silme başarılı ise True, başarısız ise false döner.</returns>
        public bool DeleteRange(List<T> entities)
        {
            entities.ForEach(e=> { ShadowPropertyDeleted(e); }); //ShadowPropertylerin değerleri atanıyor.

            _entities.RemoveRange(entities);
            return ResultReturn(_context.SaveChanges());
        }
        #endregion
        #region GetAll
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null,
            params Expression<Func<T, object>>[] includeProperties)
        {
           IQueryable<T> query =  _entities;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            if (predicate is null)
                return query.ToList();
            return query.Where(predicate).AsNoTracking().ToList();
        }
        #endregion
        #region Find
        public T Find(Guid id)
            => _entities.Find(id);
        #endregion
        #region Predicate Search
        public T Get(Expression<Func<T, bool>> predicate = null)
            => _entities.FirstOrDefault(predicate);

        public bool Any(Expression<Func<T, bool>> predicate)
            => _entities.Any(predicate);
        #endregion
  
    }

    //Asenkron olan BaseRepository
    public partial class EfBaseRepository<T> : IBaseRepositoryAsync<T> where T : class, IEntity<Guid>, new()
    {
        #region AddAsync
        public async Task<bool> AddAsync(T entity)
        {
            ShadowPropertyAdd(entity); //ShadowPropertylerin değerleri atanıyor.

            await _entities.AddAsync(entity);

            return ResultReturn(await _context.SaveChangesAsync());
        }

        public async Task<bool> AddRangeAsync(List<T> entities)
        {
            entities.ForEach(e=> { ShadowPropertyAdd(e); }); //ShadowPropertylerin değerleri atanıyor.

            await _entities.AddRangeAsync(entities);

            return ResultReturn(await _context.SaveChangesAsync());
        }
        #endregion
        #region UpdateAsync
        /// <summary>
        /// Nesne güncelleme işlemi.
        /// </summary>
        /// <param name="entity">Güncellenecek nesne.</param>
        /// <returns>Güncelleme başarılı ise True, başarısız ise false döner.</returns>
        public async Task<bool> UpdateAsync(T entity)
        {
            ShadowPropertyUpdated(entity);//ShadowPropertylerin değerleri atanıyor.

            _entities.Update(entity);
            return ResultReturn(await _context.SaveChangesAsync());
        }

        /// <summary>
        /// Liste halinde güncelleme işlemi.
        /// </summary>
        /// <param name="entities">Güncellenecek nesneler.</param>
        /// <returns>Güncelleme başarılı ise True, başarısız ise false döner.</returns>
        public async Task<bool> UpdateRangeAsync(List<T> entities)
        {
            entities.ForEach(e=> { ShadowPropertyUpdated(e); });//ShadowPropertylerin değerleri atanıyor.

            _entities.UpdateRange(entities);
            return ResultReturn(await _context.SaveChangesAsync());
        }
        #endregion
        #region DeleteAsync
        /// <summary>
        /// Nesne silme işlemi. Silme işlemleri Soft Delete olarak yapılmaktadır.
        /// </summary>
        /// <param name="entity">Silinecek nesne.</param>
        /// <returns>Silme başarılı ise True, başarısız ise false döner.</returns>
        public async Task<bool> DeleteAsync(T entity)
        {
            ShadowPropertyDeleted(entity);

            _entities.Update(entity);
            return ResultReturn(await _context.SaveChangesAsync());
        }

        /// <summary>
        /// Nesne silme işlemi. Silme işlemleri Soft Delete olarak yapılmaktadır.
        /// </summary>
        /// <param name="entities">Silinecek nesneler.</param>
        /// <returns>Silme başarılı ise True, başarısız ise false döner.</returns>
        public async Task<bool> DeleteRangeAsync(List<T> entities)
        {
            entities.ForEach(e=> { ShadowPropertyDeleted(e); });

            _entities.UpdateRange(entities);
            return ResultReturn(await _context.SaveChangesAsync());
        }
        #endregion
        #region GetAllAsync
        public  async  Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,
            params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _entities;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            if (predicate is null)
                return await query.ToListAsync();

            return await query.Where(predicate).AsNoTracking().ToListAsync();
        }
        #endregion
        #region FindAsync
        public  async Task<T> FindAsync(Guid id)
         => await _entities.FindAsync(id);
        #endregion
        #region Predicate Search
        public  async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate = null)
            => await _entities.AnyAsync(predicate);

        public  async Task<T> GetAsync(Expression<Func<T, bool>> predicate = null)
            => await _entities.FirstOrDefaultAsync(predicate);

        #endregion

    }

    //Custom Metot
    public partial class EfBaseRepository<T>
    {
        private bool ResultReturn(int saveChange)
        {
            return saveChange switch
            {
                1 => true,
                -1 => false
            };
        }

        private void ShadowPropertyAdd(T entity)
        {
            var entityEntry = _entities.Entry(entity);

            entityEntry.Property("CreatedDate").CurrentValue
                = _context.Database.SqlQuery<DateTime>($"SELECT GETDATE() as Value").First();

            entityEntry.Property<string>("CreatedComputerName").CurrentValue = Environment.MachineName;
            entityEntry.Property<string>("CreatedIpAddress").CurrentValue = IPAddressFinder.GetHostName();
            entityEntry.Property<DataStatu>("DataStatu").CurrentValue = DataStatu.Added;
        }

        private void ShadowPropertyUpdated(T entity)
        {
            var entityEntry = _entities.Entry(entity);

            entityEntry.Property("UpdatedDate").CurrentValue
                = _context.Database.SqlQuery<DateTime>($"SELECT GETDATE() as Value").First();

            entityEntry.Property("UpdatedComputerName").CurrentValue = Environment.MachineName;
            entityEntry.Property("UpdatedIpAddress").CurrentValue = IPAddressFinder.GetHostName();
            entityEntry.Property("DataStatu").CurrentValue = DataStatu.Updated;
        }

        private void ShadowPropertyDeleted(T entity)
        {
            var entityEntry = _entities.Entry(entity);

            entityEntry.Property("DeletedDate").CurrentValue
                = _context.Database.SqlQuery<DateTime>($"SELECT GETDATE() as Value").First();

            entityEntry.Property("DeletedComputerName").CurrentValue = Environment.MachineName;
            entityEntry.Property("DeletedIpAddress").CurrentValue = IPAddressFinder.GetHostName();
            entityEntry.Property("DataStatu").CurrentValue = DataStatu.Deleted;
        }
    }
}
