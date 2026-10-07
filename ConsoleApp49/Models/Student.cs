using ConsoleApp49.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp49.Models;

public class Student : IEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public int FacultyId { get; set; }
    public Faculty Faculty { get; set; }

    public ICollection<Course> Courses { get; set; }
}
