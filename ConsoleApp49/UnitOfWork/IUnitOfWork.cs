using ConsoleApp49.Generics;
using ConsoleApp49.Models;
using ConsoleApp49.Repositories.Abstarcts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp49.UnitofWork;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Student> Students { get; }
    IGenericRepository<Faculty> Faculties { get; }
    IGenericRepository<Course> Courses { get; }
    IGenericRepository<Teacher> Teachers { get; }
    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
}
