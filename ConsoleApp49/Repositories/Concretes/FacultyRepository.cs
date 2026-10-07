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

public class FacultyRepository : GenericRepository<Faculty>, IFacultyRepository
{
    public FacultyRepository(DbContext context) : base(context)
    {
    }
}
