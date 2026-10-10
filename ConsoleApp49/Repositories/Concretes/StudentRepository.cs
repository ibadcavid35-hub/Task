using ConsoleApp49.DTO;
using ConsoleApp49.Generics;
using ConsoleApp49.Models;
using ConsoleApp49.Repositories.Abstarcts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp49.Repositories.Concretes;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    public StudentRepository(DbContext context) : base(context)
    {
    }

    public async Task<List<StudentWithFaculty>> getAllStudentsWithFacultyNameAsync() { 

        var students = await _dbSet
        .Include(x => x.Faculty)
        .ToListAsync();

        var result = students.Select(x => new StudentWithFaculty()
        {
            Firstname = x.FirstName,
            Lastname = x.LastName,
            Facultyname = x.Faculty.Name
        }).ToList();

        return result;
    }
}
