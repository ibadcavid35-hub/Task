using ConsoleApp49.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp49.Models;

public class Course : IEntity
{
    public string Name { get; set; }

    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }

    public ICollection<Student> Students { get; set; }
    public int Id { get; set; }
}
