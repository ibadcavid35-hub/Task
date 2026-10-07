using ConsoleApp49.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp49.Models;

public class Faculty : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Student> Students { get; set; }
}
