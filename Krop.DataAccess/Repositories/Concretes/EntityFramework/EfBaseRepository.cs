﻿using Krop.Common.Helpers.IpAddress;
using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts.BaseRepository;
using Krop.Entities.Entities;
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
        public void Add(T entity)
        {
            ShadowPropertyAdd(entity); //ShadowPropertylerin değerleri atanıyor.

            _entities.Add(entity);
        }

        /// <summary>
        /// Liste halinde yeni nesne ekleme.
        /// </summary>
        /// <param name="entities">Eklenecek nesneler.</param>
        public void AddRange(List<T> entities)
        {

            entities.ForEach(e => { ShadowPropertyAdd(e); }); //ShadowPropertylerin değerleri atanıyor.

            _entities.AddRange(entities);
        }
        #endregion
        #region Update
        /// <summary>
        /// Nesne güncelleme işlemi.
        /// </summary>
        /// <param name="entity">Güncellenecek nesne.</param>
        public void Update(T entity)
        {
            ShadowPropertyUpdated(entity); //ShadowPropertylerin değerleri atanıyor.

            _entities.Update(entity);
        }

        /// <summary>
        /// Liste halinde güncelleme işlemi.
        /// </summary>
        /// <param name="entities">Güncellenecek nesneler.</param>
        public void UpdateRange(List<T> entities)
        {
            entities.ForEach(e => { ShadowPropertyUpdated(e); }); //ShadowPropertylerin değerleri atanıyor.

            _entities.UpdateRange(entities);
        }
        #endregion
        #region Delete
        /// <summary>
        /// Nesne silme işlemi. Silme işlemleri Soft Delete olarak yapılmaktadır.
        /// </summary>
        /// <param name="entity">Silinecek nesne.</param>
        public void Delete(T entity)
        {
            ShadowPropertyDeleted(entity); //ShadowPropertylerin değerleri atanıyor.

            _entities.Update(entity);
        }

        /// <summary>
        /// Nesne silme işlemi. Silme işlemleri Soft Delete olarak yapılmaktadır.
        /// </summary>
        /// <param name="entities">Silinecek nesneler.</param>
        public void DeleteRange(List<T> entities)
        {
            entities.ForEach(e => { ShadowPropertyDeleted(e); }); //ShadowPropertylerin değerleri atanıyor.

            _entities.UpdateRange(entities);
        }
        #endregion
        #region GetAll
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            IQueryable<T> query = _entities;
            return predicate is null ?
                 query.ToList() :
             query.Where(predicate).AsNoTracking().ToList();
        }
        #endregion
        #region Find
        public T Find(Guid id)
            => _entities.Find(id);
        #endregion
        #region Predicate Search
        public T Get(Expression<Func<T, bool>> predicate = null)
        {
            IQueryable<T> query = _entities;

            return query.FirstOrDefault(predicate);
        }

        public bool Any(Expression<Func<T, bool>> predicate)
            => _entities.Any(predicate);
        #endregion

    }

    //Asenkron olan BaseRepository
    public partial class EfBaseRepository<T> : IBaseRepositoryAsync<T> where T : class, IEntity<Guid>, new()
    {
        #region AddAsync
        public async Task AddAsync(T entity)
        {
            ShadowPropertyAdd(entity); //ShadowPropertylerin değerleri atanıyor.

            await _entities.AddAsync(entity);
            //await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(List<T> entities)
        {
            entities.ForEach(e => { ShadowPropertyAdd(e); }); //ShadowPropertylerin değerleri atanıyor.

            await _entities.AddRangeAsync(entities);
            //await _context.SaveChangesAsync();
        }
        #endregion
        #region UpdateAsync
        /// <summary>
        /// Nesne güncelleme işlemi.
        /// </summary>
        /// <param name="entity">Güncellenecek nesne.</param>
        public async Task UpdateAsync(T entity)
        {
            ShadowPropertyUpdated(entity);//ShadowPropertylerin değerleri atanıyor.

            _entities.Update(entity);
            //await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Liste halinde güncelleme işlemi.
        /// </summary>
        /// <param name="entities">Güncellenecek nesneler.</param>
        public async Task UpdateRangeAsync(List<T> entities)
        {
            entities.ForEach(e => { ShadowPropertyUpdated(e); });//ShadowPropertylerin değerleri atanıyor.

            _entities.UpdateRange(entities);
            // await _context.SaveChangesAsync();
        }
        #endregion
        #region DeleteAsync
        /// <summary>
        /// Nesne silme işlemi. Silme işlemleri Soft Delete olarak yapılmaktadır.
        /// </summary>
        /// <param name="entity">Silinecek nesne.</param>
        public async Task DeleteAsync(T entity)
        {
            ShadowPropertyDeleted(entity);

            _entities.Update(entity);
            //await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Nesne silme işlemi. Silme işlemleri Soft Delete olarak yapılmaktadır.
        /// </summary>
        /// <param name="entities">Silinecek nesneler.</param>
        public async Task DeleteRangeAsync(List<T> entities)
        {
            entities.ForEach(e => { ShadowPropertyDeleted(e); });

            _entities.UpdateRange(entities);
            // await _context.SaveChangesAsync();
        }
        #endregion
        #region GetAllAsync
        public async Task<IEnumerable<T>> GetAllWithIncludesAsync(Expression<Func<T, bool>> predicate = null,
            params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queries = _entities
                .IgnoreQueryFilters()
                .Where(p => EF.Property<DataStatu>(p, "DataStatu") != DataStatu.Deleted);

            foreach (var includeProperty in includeProperties)
            {
                queries = queries.Include(includeProperty);
            }
            return predicate != null ?
               await queries.Where(predicate).AsNoTracking().ToListAsync():
               await queries.AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            IQueryable<T> queries = _entities;

            return predicate != null ?
               await queries.Where(predicate).AsNoTracking().ToListAsync() :
               await queries.AsNoTracking().ToListAsync();
        }
        #endregion
        #region FindAsync
        public async Task<T> FindAsync(Guid id)
         => await _entities.FindAsync(id);
        #endregion
        #region Predicate Search
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate = null)
            => await _entities.AnyAsync(predicate);

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate = null)
        {
            IQueryable<T> query = _entities;

            return await query.FirstOrDefaultAsync(predicate);
        }
        public async Task<T> GetIcludesAsync(Expression<Func<T, bool>> predicate = null,
            params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queries = _entities
                .IgnoreQueryFilters()
                .Where(p => EF.Property<DataStatu>(p, "DataStatu") != DataStatu.Deleted);
            foreach (var includeProperty in includeProperties)
            {
                queries = queries.Include(includeProperty);
            }

            return await queries.FirstOrDefaultAsync(predicate);
        }
        #endregion

    }

    //Custom Metot
    public partial class EfBaseRepository<T>
    {
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
