using ChallengeMVFactory.Domain.Common;
using System.Linq.Expressions;


namespace ChallengeMVFactory.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : BaseModel
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicated);

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicated = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        string includeString = null,
                                        bool disabledTranking = true
                                        );
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicated = null,
                                      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                     List<Expression<Func<T, object>>> includes = null,
                                      bool disabledTranking = true
                                      );
        Task<T> GetByIdAsync(int id);


        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<T> DeleteAsync(T entity);
    }
}
