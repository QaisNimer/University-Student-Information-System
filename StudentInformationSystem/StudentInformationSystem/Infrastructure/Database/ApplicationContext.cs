using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Infrastructure.Entities;
using System.Security;

namespace StudentInformationSystem.Infrastructure.Database
{
    public class ApplicationContext : IdentityDbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users {  get; set; }
        public DbSet<Student> Students {  get; set; }
        public DbSet<Course> Courses {  get; set; }
        public DbSet<Department> Departments {  get; set; }
        public DbSet<Semester> Semester {  get; set; }
        public DbSet<RegisteredCourses> RegisteredCourses {  get; set; }
        public DbSet<Marks> Marks {  get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships for User entity
            base.OnModelCreating(modelBuilder);
            new DatabaseInitializer(modelBuilder).DataBaseSeed();
        }
    }
}
