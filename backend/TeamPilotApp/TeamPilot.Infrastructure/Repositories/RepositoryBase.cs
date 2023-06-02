using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TeamPilot.Application.Interfaces.Repositories;
using TeamPilot.Infrastructure.DataAccess;

namespace TeamPilot.Infrastructure.Repositories;

public abstract class RepositoryBase<T> : IRepository<T> where T : class
{
    protected TeamPilotDbContext _context;

    public RepositoryBase(TeamPilotDbContext context)
    {
        _context = context;
    }

    public virtual async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public virtual async Task<T?> FirstOrDefaultAsync()
    {
        return await _context.Set<T>().FirstOrDefaultAsync();
    }

    public virtual async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(predicate);
    }

    public virtual async Task<List<T>> FindManyAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().Where(predicate).ToListAsync();
    }

    public virtual async Task InsertAsync(T item)
    {
        _context.Set<T>().Add(item);
        await _context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(T item)
    {
        _context.Set<T>().Update(item);
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T item)
    {
        _context.Set<T>().Remove(item);
        await _context.SaveChangesAsync();
    }
}
