using ConsoleApp49.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp49.Context;

public class UniversityDbContext : DbContext
{
    public UniversityDbContext() { }

    public UniversityDbContext(DbContextOptions options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configRoot = new ConfigurationBuilder()
                    .AddJsonFile($"appsettings.json", true, true)
                    .Build();

        var connectionString = configRoot.GetConnectionString("SqlServer");

        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        optionsBuilder.UseSqlServer(connectionString);

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UniversityDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
}
