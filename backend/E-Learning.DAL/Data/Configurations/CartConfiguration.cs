using E_Learning.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Learning.DAL.Data.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(c => new { c.UserId, c.CourseId });
            builder.HasOne(c => c.Course).WithMany(c => c.Carts).HasForeignKey(c => c.CourseId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.User).WithMany(c => c.CartItems).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Restrict);

            //soft delete
            builder.HasQueryFilter(e => e.Course == null || !e.Course.IsDeleted);
            //Data Seeding
            //builder.HasData(
            //    new Cart { CourseId = 3, UserId = 3 },
            //    new Cart { CourseId = 4, UserId = 4 }
            //    );

        }
    }
}
