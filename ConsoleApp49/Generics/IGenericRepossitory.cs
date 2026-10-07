using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp49.Generics;

public interface IGenericRepossitory<T>
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T student);
    Task UpdateAsync(T student);
    Task DeleteAsync(int id);
}
