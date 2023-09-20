using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.Common.Interfaces;
using GalaxySMS.Data.NetCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using GCS.Core.Common.Contracts;

namespace GalaxySMS.Data.NetCore.Repositories
{
    public class EfcRepository<TDbContext> : IEfcRepository where TDbContext : GalaxySMSDbContext//DbContext
    {
        protected TDbContext dbContext;
        private ICurrentUserService _currentUserService;
        public EfcRepository(TDbContext context, ICurrentUserService currentUserService)
        {
            dbContext = context;
            _currentUserService = currentUserService;
        }

        public async Task<T> CreateAsync<T>(T entity, bool saveAuditTrail = true) where T : class
        {
            var addedEntity = this.dbContext.Set<T>().Add(entity);

            _ = await this.dbContext.SaveChangesAsync(_currentUserService?.UserId, saveAuditTrail);
            return addedEntity.Entity;
        }

        public async Task DeleteAsync<T>(T entity, bool saveAuditTrail = true) where T : class
        {
            this.dbContext.Set<T>().Remove(entity);

            _ = await this.dbContext.SaveChangesAsync(_currentUserService?.UserId, saveAuditTrail);
        }

        public async Task<IList<T>> SelectAllAsync<T>() where T : class
        {
            return await this.dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> SelectByIdAsync<T>(object id) where T : class
        {
            //      return await this.dbContext.Set<T>().FindAsync(id);
            var item = await this.dbContext.Set<T>().FindAsync(id);
            if (item != null)
                dbContext.Entry<T>(item).State = EntityState.Detached;
            return item;
        }

        public async Task<T> UpdateAsync<T>(T entity, bool saveAuditTrail = true) where T : class
        {
            var updatedEntity = this.dbContext.Set<T>().Update(entity);

            _ = await this.dbContext.SaveChangesAsync(_currentUserService?.UserId, saveAuditTrail);
            return updatedEntity.Entity;
        }
    }

    //public class EfcRepositoryAsync<T, TId> : IEfcRepositoryAsync<T, TId> where T : TableEntityBase<TId>, Interfaces.IEntity<TId>
    //{
    //    private readonly GalaxySMSDbContext _dbContext;

    //    public EfcRepositoryAsync(GalaxySMSDbContext dbContext)
    //    {
    //        _dbContext = dbContext;
    //    }

    //    public IQueryable<T> Entities => _dbContext.Set<T>();

    //    public async Task<T> AddAsync(T entity)
    //    {
    //        var e = await _dbContext.Set<T>().AddAsync(entity);
    //        return e.Entity;
    //    }

    //    public Task DeleteAsync(T entity)
    //    {
    //        _dbContext.Set<T>().Remove(entity);
    //        return Task.CompletedTask;
    //    }

    //    public async Task<IList<T>> GetAllAsync()
    //    {
    //        return await _dbContext
    //            .Set<T>()
    //            .ToListAsync();
    //    }

    //    public async Task<T> GetByIdAsync(TId id)
    //    {
    //        return await _dbContext.Set<T>().FindAsync(id);
    //    }

    //    public async Task<IList<T>> GetPagedResponseAsync(int pageNumber, int pageSize)
    //    {
    //        return await _dbContext
    //            .Set<T>()
    //            .Skip((pageNumber - 1) * pageSize)
    //            .Take(pageSize)
    //            .AsNoTracking()
    //            .ToListAsync();
    //    }

    //    public Task UpdateAsync(T entity)
    //    {
    //        T exist = _dbContext.Set<T>().Find(entity.Id);
    //        _dbContext.Entry(exist).CurrentValues.SetValues(entity);

    //        return Task.CompletedTask;
    //    }
    //}

}
