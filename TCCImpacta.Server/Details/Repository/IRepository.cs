using System.Linq.Expressions;

namespace YogaCommerce.Application.Details.Repository;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task SaveChangesAsync();
    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
}
