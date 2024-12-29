using E_Learning.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Learning.DAL.Data.Configurations
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        /*------------------------------------------------------------------------*/
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.Property(a => a.Body).IsRequired();

            ////Data Seeding
            //builder.HasData(
            //        new Answer { Id = 1, QuestionId = 1, Body = "option1" },
            //        new Answer { Id = 2, QuestionId = 1, Body = "option2" },
            //        new Answer { Id = 3, QuestionId = 1, Body = "option3" },

            //        new Answer { Id = 4, QuestionId = 2, Body = "option1" },
            //        new Answer { Id = 5, QuestionId = 2, Body = "option2" },
            //        new Answer { Id = 6, QuestionId = 2, Body = "option3" },

            //        new Answer { Id = 7, QuestionId = 3, Body = "option1" },
            //        new Answer { Id = 8, QuestionId = 3, Body = "option2" },
            //        new Answer { Id = 9, QuestionId = 3, Body = "option3" },

            //        new Answer { Id = 10, QuestionId = 4, Body = "option1" },
            //        new Answer { Id = 11, QuestionId = 4, Body = "option2" },
            //        new Answer { Id = 12, QuestionId = 4, Body = "option3" },

            //        new Answer { Id = 13, QuestionId = 5, Body = "option1" },
            //        new Answer { Id = 14, QuestionId = 5, Body = "option2" },
            //        new Answer { Id = 15, QuestionId = 5, Body = "option3" }
            //    );
        }       
        /*------------------------------------------------------------------------*/
    }
}
