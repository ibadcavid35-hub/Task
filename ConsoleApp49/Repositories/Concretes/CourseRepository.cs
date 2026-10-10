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

public class CourseRepository : GenericRepository<Course>, ICourseRepository
{
    public CourseRepository(DbContext context) : base(context)
    {
    }

    public async Task<List<CorseWithTeacher>> getAllCourseWithTeacherNameAsync()
    {
        var courses = await _dbSet.Include(x=>x.Teacher).ToListAsync();

        var result = courses.Select(x => new CorseWithTeacher()
        {
            Firstname = x.Teacher.FirstName,
            Lastname = x.Teacher.LastName,
            Coursename = x.Name
        }).ToList();
        
        return result;
    }
}
