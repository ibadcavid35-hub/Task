using ConsoleApp49.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp49.Models;

public class Teacher : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public ICollection<Course> Courses { get; set; }
}