using CaseTracker.DataAccessLayer.DataContext;
using CaseTracker.DataAccessLayer.IDataServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.DataAccessLayer.DataServices
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        internal readonly ApplicationDbContext _dbContext;
        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            _ = await _dbContext.Set<TEntity>().AddAsync(entity);
            _ = await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task AddAsync(List<TEntity> entity)
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(entity);
            _ = await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _ = _dbContext.Set<TEntity>().Remove(entity);
            _ = await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(List<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
            _ = await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _ = await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<IList<TEntity>> GetAllAsync(params Expression<Func<TEntity, bool>>[] wheres)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();
            foreach (var predicate in wheres) query = query.Where(predicate);
            return await query.ToListAsync();
        }

        public virtual async Task<IList<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();
            foreach (var include in includes) query = query.Include(include);
            return await query.ToListAsync();
        }

        public virtual async Task<IList<TEntity>> GetAllAsync()
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();
            return await query.ToListAsync();
        }

        public virtual async Task<TEntity?> GetAsync(params Expression<Func<TEntity, bool>>[] wheres)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();
            foreach (var predicate in wheres) query = query.Where(predicate);
            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<TEntity?> GetAsync(params Expression<Func<TEntity, object>>[] Includes)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();
            foreach (var predicate in Includes) query = query.Include(predicate);
            return await query.FirstOrDefaultAsync();
        }
    }
}
