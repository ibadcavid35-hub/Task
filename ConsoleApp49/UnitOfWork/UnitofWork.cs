using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp49.Context;
using ConsoleApp49.Generics;
using ConsoleApp49.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace ConsoleApp49.UnitofWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly UniversityDbContext _context;
    private IDbContextTransaction? _transaction;

    public IGenericRepository<Student> Students { get; }
    public IGenericRepository<Faculty> Faculties { get; }
    public IGenericRepository<Course> Courses { get; }
    public IGenericRepository<Teacher> Teachers { get; }

    public UnitOfWork(
        UniversityDbContext context,
        IGenericRepository<Student> students,
        IGenericRepository<Faculty> faculties,
        IGenericRepository<Course> courses,
        IGenericRepository<Teacher> teachers)
    {
        _context = context;

        Students = students;
        Faculties = faculties;
        Courses = courses;
        Teachers = teachers;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    
    }
    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }
    public async Task CommitAsync()
    {
        if(_transaction != null)
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task RollbackAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
    }
}
