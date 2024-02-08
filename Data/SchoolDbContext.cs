using Individuellt_databasprojekt.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individuellt_databasprojekt.Data
{
    internal class SchoolDbContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<CourseStudentConnection> CourseStudentConnection { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source = JOHNSDATOR;Initial Catalog = SchoolDb;Integrated Security=True;TrustServerCertificate=Yes;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseStudentConnection>().HasKey(c => new { c.StudentId, c.CourseId, c.CourseStart }); // Define composite primary key using Fluent API
        }
    }
}
