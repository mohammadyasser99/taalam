using E_Learning.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.DAL.Data.Configurations

{
    public class CertificateOfCompletionConfiguration : IEntityTypeConfiguration<CertificateOfCompletion>

    {
        public void Configure(EntityTypeBuilder<CertificateOfCompletion> builder)
        {
            builder.ToTable("CertificatesOfCompletion");


            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
            .HasDefaultValueSql("NEWID()"); 

                    builder.Property(c => c.IssuedAy)
            .HasDefaultValueSql("GETDATE()"); 

            builder.HasOne(c => c.User)
                .WithMany(u => u.CertificatesOfCompletion)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade); 

            builder.HasOne(c => c.Course)
                .WithMany(co => co.CertificatesOfCompletion)
                .HasForeignKey(c => c.CourseId)
                .OnDelete(DeleteBehavior.ClientCascade);

            //soft delete
            builder.HasQueryFilter(c => !c.Course.IsDeleted);




        }


    }
}
