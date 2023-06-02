using System.Linq.Expressions;

namespace TeamPilot.Application.Interfaces.Repositories;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T?> FirstOrDefaultAsync();
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    Task<List<T>> FindManyAsync(Expression<Func<T, bool>> predicate);
    Task InsertAsync(T item);
    Task UpdateAsync(T item);
    Task DeleteAsync(T item);
}
