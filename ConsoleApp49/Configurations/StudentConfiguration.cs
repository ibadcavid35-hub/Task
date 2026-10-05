using ConsoleApp49.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp49.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(s => s.LastName)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasOne(s => s.Faculty)
            .WithMany(f => f.Students)
            .HasForeignKey(s => s.FacultyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(s => s.Courses)
            .WithMany(c => c.Students);
    }
}