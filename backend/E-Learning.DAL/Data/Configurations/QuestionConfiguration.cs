using E_Learning.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Learning.DAL.Data.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(q => q.Body).IsRequired();
            builder.Property(q => q.ModelAnswer).IsRequired();

            ////Data Seeding
            //builder.HasData(
            //        new Question { Id = 1, QuizId = 1, Body = "Question1", ModelAnswer = 1 },
            //        new Question { Id = 2, QuizId = 2, Body = "Question2", ModelAnswer = 2 },
            //        new Question { Id = 3, QuizId = 3, Body = "Question3", ModelAnswer = 3 },
            //        new Question { Id = 4, QuizId = 4, Body = "Question4", ModelAnswer = 2 },
            //        new Question { Id = 5, QuizId = 5, Body = "Question5", ModelAnswer = 1 }
            //    );
        }
    }
}
