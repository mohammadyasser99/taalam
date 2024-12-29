using E_Learning.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.DAL.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
        {
            //Data Seeding
            //builder.HasData(
            //    new Category { Id = 1, Name = "Programming" },
            //    new Category { Id = 2, Name = "Sporting" }
            //);
        }
    }
}
