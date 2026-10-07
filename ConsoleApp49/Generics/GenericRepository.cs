using ConsoleApp49.Models.BaseEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp49.Generics;

public class GenericRepository<T> : IGenericRepossitory<T> where T : class, IEntity
{
    protected readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var existingData = await _dbSet.FindAsync(id);
        if (existingData == null) return;
        _dbSet.Remove(existingData);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task UpdateAsync(T entity)
    {
        var existingData = await _dbSet.FindAsync(entity.Id);
        if (existingData == null) return;

        _context.Entry(existingData).CurrentValues.SetValues(entity);
    }
}
