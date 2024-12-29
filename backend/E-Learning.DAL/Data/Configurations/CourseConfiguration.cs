using E_Learning.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace E_Learning.DAL.Data.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasOne(c => c.User).WithMany(i => i.OwnedCourses).HasForeignKey(c => c.UserId);
            builder.Property(c => c.Title).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Price).IsRequired();

            //soft delete
            builder.HasQueryFilter(c => !c.IsDeleted);


            ////Data Seeding
            //builder.HasData(
            //    new Course { Id = 1, Title = "C# From Zero To SuperHero", CategoryId = 1, UserId = 1, CoverPicture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQPvJBvVedFjpONzC1ZOR-YSWauBp9ZKK6ydA&s", Rate = 1 },
            //    new Course { Id = 2, Title = "Data Strcutre", CategoryId = 1, UserId = 1, CoverPicture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS2o9_OmdunGnBKDIiSGo3uLYvA8vySqQ-M9fyVT_nys9HMMbZJv8cU8YtPkPbexgrf3J8&usqp=CAU", Rate = 2 },

            //    new Course { Id = 3, Title = "Diet", CategoryId = 2, UserId = 2, CoverPicture = "https://dynamic.brandcrowd.com/template/preview/design/90728fda-b283-4797-973e-9a0775dec439?v=4&designTemplateVersion=5&size=design-preview-standalone-1x", Rate = 4 },
            //    new Course { Id = 4, Title = "GYM", CategoryId = 2, UserId = 2, CoverPicture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSo1cHnjZlK64h9Pc5OvWCYfYWYexByKhPpeg&s", Rate = 2 },

            //    new Course { Id = 5, Title = "Alogrithms", CategoryId = 1, UserId = 1, CoverPicture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQCmO_j4YW82XwWIM-_Fo6afxyuN2pSGoZMBQ&s", Rate = 2 },
            //    new Course { Id = 6, Title = "Introduction to C++", CategoryId = 1, UserId = 1, CoverPicture = "https://d1jnx9ba8s6j9r.cloudfront.net/imgver.1551437392/img/co_img_1539_1633434090.png", Rate = 5 },
            //    new Course { Id = 7, Title = "EF Core", CategoryId = 1, UserId = 1, CoverPicture = "https://static.gunnarpeipman.com/wp-content/uploads/2019/12/ef-core-featured.png", Rate = 4 },
            //    new Course { Id = 8, Title = "Database Using SQL Server", CategoryId = 1, UserId = 1, CoverPicture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTKIa50KjBUhvtvuMbOaL_QtJrzstWIQA3YSg&s", Rate = 5},
            //    new Course { Id = 9, Title = "Design Pattern", CategoryId = 1, UserId = 1, CoverPicture = "https://www.construx.com/wp-content/uploads/2018/08/design-pattern-essentials-course-image.jpg", Rate = 3 },
            //    new Course { Id = 10, Title = "SOLID Principle", CategoryId = 1, UserId = 1, CoverPicture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS-HJM_i7rOg2yY9OgpVPYRLL4fYjA9CTfEoQ&s", Rate = 1 },

            //    new Course { Id = 11, Title = "How To Train", CategoryId = 2, UserId = 2, CoverPicture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQtx7PjCp_KBWQZtHauOWMG2WiRpXxjpbYf3w&s", Rate = 4 },
            //    new Course { Id = 12, Title = "Life Coach", CategoryId = 2, UserId = 2, CoverPicture = "https://static.vecteezy.com/system/resources/previews/024/700/836/non_2x/fitness-gym-training-social-media-timeline-cover-and-video-thumbnail-and-web-banner-design-free-vector.jpg", Rate = 1 }
            //    );
        }
    }
}