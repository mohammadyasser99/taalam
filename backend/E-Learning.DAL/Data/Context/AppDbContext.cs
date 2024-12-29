using E_Learning.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace E_Learning.DAL.Data.Context
{
    public class AppDbContext : IdentityDbContext<User, Role, int>
    {
        //public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<WishList> WishList { get; set; }

        public DbSet<Rating> Rating { get; set; }

        public DbSet<CompletedLesson> CompletedLessons  { get; set; }
        public DbSet<CertificateOfCompletion> CertificatesOfCompletion { get; set; }

        public DbSet<Announcement> Announcements { get; set; }

        /*------------------------------------------------------------------------*/
        // Ctor
        public AppDbContext(DbContextOptions options) : base(options) { }
        /*------------------------------------------------------------------------*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        /*------------------------------------------------------------------------*/
    }
}
