using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace CoursesDAL
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlServer(@"Data Source=.,5433;User Id=sa;Password=putyourpassword;Initial Catalog=CoursesDB");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            //CourseInstructor table has a primary key with two fields
            modelBuilder.Entity<CourseInstructor>().HasKey( ci => new {ci.CourseId, ci.InstructorId} );
        }
        
        public DbSet<Course> Course { get; set; }
        public DbSet<Price> Price { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<CourseInstructor> CourseInstructor { get; set; }
    }
}