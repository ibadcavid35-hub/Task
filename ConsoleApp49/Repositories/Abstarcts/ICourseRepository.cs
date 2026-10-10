using ConsoleApp49.DTO;
using ConsoleApp49.Generics;
using ConsoleApp49.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp49.Repositories.Abstarcts;

public interface ICourseRepository : IGenericRepository<Course>
{
    Task<List<CorseWithTeacher>> getAllCourseWithTeacherNameAsync(); 
}
