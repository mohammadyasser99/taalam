using E_Learning.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace E_Learning.DAL.Data.Configurations
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {

            builder.HasOne(r => r.User)
                   .WithMany(u => u.Ratings)
                   .HasForeignKey(r => r.UserId)
                   .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(r => r.Course)
                   .WithMany(c => c.Ratings)
                   .HasForeignKey(r => r.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(r => r.Description)
            .HasMaxLength(500);

            builder.HasQueryFilter(r => !r.Course.IsDeleted);

            //builder.HasData(
            //    new Rating
            //    {
            //        Id = 1,
            //        UserId = 1,
            //        CourseId = 1,
            //        Value = 5,
            //        Description = "Excellent course! Very well structured and informative."
            //    },
            //    new Rating
            //    {
            //        Id = 2,
            //        UserId = 1,
            //        CourseId = 2,
            //        Value = 4,
            //        Description = "Good course, but could use more examples."
            //    },
            //    new Rating
            //    {
            //        Id = 3,
            //        UserId = 2,
            //        CourseId = 3,
            //        Value = 3,
            //        Description = "Average course. The content was somewhat basic."
            //    },
            //    new Rating
            //    {
            //        Id = 4,
            //        UserId = 3,
            //        CourseId = 4,
            //        Value = 4,
            //        Description = "Great content, but the pace was a bit fast."
            //    },
            //    new Rating
            //    {
            //        Id = 5,
            //        UserId = 4,
            //        CourseId = 5,
            //        Value = 2,
            //        Description = "Not very helpful. The material was outdated."
            //    }
            //);
        }
    }
}
