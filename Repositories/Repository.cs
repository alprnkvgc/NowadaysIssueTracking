using Microsoft.EntityFrameworkCore;
using NowadaysIssueTracking.Interfaces;

namespace NowadaysIssueTracking.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly NowadaysDbContext _context;

    public Repository(NowadaysDbContext context)
    {
        _context = context;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<IList<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
}