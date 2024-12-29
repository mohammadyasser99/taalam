using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using E_Learning.DAL.Models;

namespace E_Learning.DAL.Data.Configurations
{
    public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.Property(q => q.Title).IsRequired();

            ////Data Seeding
            //builder.HasData(
            //        new Quiz { Id = 1, SectionId = 1, Title = "Quiz1" },
            //        new Quiz { Id = 2, SectionId = 2, Title = "Quiz2" },
            //        new Quiz { Id = 3, SectionId = 3, Title = "Quiz3" },
            //        new Quiz { Id = 4, SectionId = 4, Title = "Quiz4" },
            //        new Quiz { Id = 5, SectionId = 5, Title = "Quiz5" }
            //    );
        }
    }
}
