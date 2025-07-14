using Microsoft.EntityFrameworkCore;
using StudentManagement.Api.Models;

namespace StudentManagement.Api.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Optional: Seed initial data or configure model properties
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FullName = "Ali Ahmadi", NationalCode = "1234567890", BirthDate = new DateTime(2000, 5, 15) },
                new Student { Id = 2, FullName = "Sara Karimi", NationalCode = "0987654321", BirthDate = new DateTime(2001, 8, 20) }
            );
        }
    }
}