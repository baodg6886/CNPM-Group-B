using Koi.Repositories.Base;
using Koi.Repositories.Models;
using Microsoft.EntityFrameworkCore;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly KoiFishGameContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(KoiFishGameContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        try
        {
            return await _dbSet.FindAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception("Error occurred while fetching entity", ex);
        }
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        try
        {
            return await _dbSet.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Error occurred while fetching all entities", ex);
        }
    }

    public async Task AddAsync(T entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Error occurred while adding the entity", ex);
        }
    }

    public async Task UpdateAsync(T entity)
    {
        try
        {
            var existingEntity = await _dbSet.FindAsync(entity);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException("Entity not found");
            }

            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Error occurred while updating the entity", ex);
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error occurred while deleting the entity", ex);
        }
    }
}
