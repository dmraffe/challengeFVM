using ChallengeMVFactory.Application.Contracts.Persistence;
using ChallengeMVFactory.Domain.Common;
using ChallengeMVFactory.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ChallengeMVFactory.Infrastructure.Repository
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : BaseModel
    {
        protected readonly MVFactoryDbContext _mvfactoryDbContext;

        public BaseRepository(MVFactoryDbContext mvfactoryDbContext)
        {
            this._mvfactoryDbContext = mvfactoryDbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            _mvfactoryDbContext.Set<T>().Add(entity);
            await _mvfactoryDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            _mvfactoryDbContext.Set<T>().Remove(entity);
            await _mvfactoryDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _mvfactoryDbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicated)
        {
            return await _mvfactoryDbContext.Set<T>().Where(predicated).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicated = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disabledTranking = true)
        {
            IQueryable<T> query = _mvfactoryDbContext.Set<T>();
            if (disabledTranking) query = query.AsNoTracking();

            if (!string.IsNullOrEmpty(includeString)) query = query.Include(includeString);

            if (predicated != null) query = query.Where(predicated);

            if (orderBy != null) return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicated = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disabledTranking = true)
        {
            IQueryable<T> query = _mvfactoryDbContext.Set<T>();
            if (disabledTranking) query = query.AsNoTracking();

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicated != null) query = query.Where(predicated);

            if (orderBy != null) return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _mvfactoryDbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _mvfactoryDbContext.Set<T>().Update(entity);
            await _mvfactoryDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
