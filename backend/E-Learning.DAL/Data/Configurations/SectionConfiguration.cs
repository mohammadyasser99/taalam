using E_Learning.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace E_Learning.DAL.Data.Configurations
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.Property(s => s.Title).IsRequired().HasMaxLength(100);
            builder.HasOne(s => s.Course).WithMany(c => c.Sections).HasForeignKey(s => s.CourseId);

            builder.HasQueryFilter(s => !s.Course.IsDeleted);
            ////Data Seeding
            //builder.HasData(new Section { Id = 1, CourseId = 1, SectionNumber=1, Title = "intro", LessonsNo = 3 },
            //                new Section { Id = 2, CourseId = 1, SectionNumber=2, Title = "OOP", LessonsNo = 5 },
            //                new Section { Id = 3, CourseId = 2, SectionNumber =1, Title = "Binary search", LessonsNo = 3 },
            //                new Section { Id = 4, CourseId = 3, SectionNumber=1, Title = "Nutrition", LessonsNo = 4 },
            //                new Section { Id = 5, CourseId = 4, SectionNumber=1, Title = "General", LessonsNo = 3 }
            //    );

        }
    }
}