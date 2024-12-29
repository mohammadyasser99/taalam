using E_Learning.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace E_Learning.DAL.Data.Configurations
{
    public class CompletedLessonConfiguration: IEntityTypeConfiguration<CompletedLesson>

    {
        public void Configure(EntityTypeBuilder<CompletedLesson> builder)
        {


            builder.ToTable("CompletedLessons");

            builder.HasKey(cl => cl.Id);

            builder.HasOne(cl => cl.User)
                .WithMany(u => u.CompletedLessonsList)
                .HasForeignKey(cl => cl.UserId)
                .OnDelete(DeleteBehavior.ClientCascade);  // Ensure that deleting a user will delete their completed lessons

            builder.HasOne(cl => cl.Lesson)
                .WithMany()
                .HasForeignKey(cl => cl.LessonId)
                .OnDelete(DeleteBehavior.ClientCascade);  // Ensure that deleting a lesson will delete related completed lessons

            builder.HasOne(cl => cl.Course) 
            .WithMany()
            .HasForeignKey(cl => cl.CourseId)
            .OnDelete(DeleteBehavior.ClientCascade);

            builder.Property(cl => cl.CompletedDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            //soft delete
            builder.HasQueryFilter(cl => !cl.Course.IsDeleted);
        }
        

    }
}
