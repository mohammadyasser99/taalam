using E_Learning.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Learning.DAL.Data.Configurations
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(e => new { e.UserId, e.CourseId });
            builder.HasOne(e => e.User).WithMany(u => u.UserEnrollments).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Course).WithMany(u => u.Enrollments).HasForeignKey(e => e.CourseId).OnDelete(DeleteBehavior.Restrict);

            //soft delete
            builder.HasQueryFilter(e => e.Course == null || !e.Course.IsDeleted);
            //Data Seeding
            //builder.HasData(
            //    new Enrollment { CourseId = 1, UserId = 3, EnrollmentDate = DateTime.Now },
            //    new Enrollment { CourseId = 2, UserId = 4, EnrollmentDate = DateTime.Now.AddHours(1) }
            //    );
        }
    }
}
