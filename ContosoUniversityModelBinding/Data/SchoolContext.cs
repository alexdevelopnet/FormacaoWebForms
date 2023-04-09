using ContosoUniversityModelBinding.Models;
using System.Data.Entity;

namespace ContosoUniversityModelBinding.Data
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
