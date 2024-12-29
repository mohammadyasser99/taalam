using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Learning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class finallltaalam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WishList",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "WishList",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Description", "Email", "EmailConfirmed", "FName", "Facebook", "GitHub", "LName", "Linkedin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "RefreshToken", "RefreshTokenExpirationDateTime", "SecurityStamp", "Twitter", "TwoFactorEnabled", "UserName", "Youtube" },
                values: new object[,]
                {
                    { 1, 0, "3a90b2df-c1fc-4028-becc-86fbf5b7d128", null, "AbdallahShatta@gmail.com", false, "Abdallah", "https://www.facebook.com/abdalah.shatta", null, "Shatta", "https://www.linkedin.com/in/abdallah-shatta55/", false, null, null, null, null, null, false, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTAM-SBzUfYOMhwc0o76MpvR7N4Yi43lcYt5g&s", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null },
                    { 2, 0, "7c30d691-8544-4f29-9499-5cdfe53536c7", null, "MohamedErbahim@gmail.com", false, "Mohamed", "https://www.facebook.com/mido.ebrahim.9699/", null, "Ebrahim", "https://www.linkedin.com/in/mohamed-abdelslam210/", false, null, null, null, null, null, false, "https://pbs.twimg.com/profile_images/1745781333400399872/MN7Wm4Ya_400x400.jpg", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null },
                    { 3, 0, "cc18f740-ad3e-4caf-946d-8f0406f22d4a", null, "MohsemTayseer@gmail.com", false, "Mohsen", null, null, "Tayseer", null, false, null, null, null, null, null, false, "", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null },
                    { 4, 0, "57e879ba-0d92-4c45-9d35-2d2049af3225", null, "MarwaElkasaby@gmail.com", false, "Marwa", null, null, "Elkasaby", null, false, null, null, null, null, null, false, "", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Programming" },
                    { 2, "Sporting" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CoverPicture", "CreationDate", "Description", "Duration", "IsDeleted", "LessonsNo", "Price", "Rate", "SectionsNo", "Title", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQPvJBvVedFjpONzC1ZOR-YSWauBp9ZKK6ydA&s", new DateTime(2024, 9, 18, 21, 40, 3, 335, DateTimeKind.Local).AddTicks(5026), null, null, false, 0, 0m, 1m, 0, "C# From Zero To SuperHero", null, 1 },
                    { 2, 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS2o9_OmdunGnBKDIiSGo3uLYvA8vySqQ-M9fyVT_nys9HMMbZJv8cU8YtPkPbexgrf3J8&usqp=CAU", new DateTime(2024, 9, 18, 21, 40, 3, 335, DateTimeKind.Local).AddTicks(5081), null, null, false, 0, 0m, 2m, 0, "Data Strcutre", null, 1 },
                    { 3, 2, "https://dynamic.brandcrowd.com/template/preview/design/90728fda-b283-4797-973e-9a0775dec439?v=4&designTemplateVersion=5&size=design-preview-standalone-1x", new DateTime(2024, 9, 18, 21, 40, 3, 335, DateTimeKind.Local).AddTicks(5084), null, null, false, 0, 0m, 4m, 0, "Diet", null, 2 },
                    { 4, 2, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSo1cHnjZlK64h9Pc5OvWCYfYWYexByKhPpeg&s", new DateTime(2024, 9, 18, 21, 40, 3, 335, DateTimeKind.Local).AddTicks(5088), null, null, false, 0, 0m, 2m, 0, "GYM", null, 2 },
                    { 5, 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQCmO_j4YW82XwWIM-_Fo6afxyuN2pSGoZMBQ&s", new DateTime(2024, 9, 18, 21, 40, 3, 335, DateTimeKind.Local).AddTicks(5090), null, null, false, 0, 0m, 2m, 0, "Alogrithms", null, 1 },
                    { 6, 1, "https://d1jnx9ba8s6j9r.cloudfront.net/imgver.1551437392/img/co_img_1539_1633434090.png", new DateTime(2024, 9, 18, 21, 40, 3, 335, DateTimeKind.Local).AddTicks(5093), null, null, false, 0, 0m, 5m, 0, "Introduction to C++", null, 1 },
                    { 7, 1, "https://static.gunnarpeipman.com/wp-content/uploads/2019/12/ef-core-featured.png", new DateTime(2024, 9, 18, 21, 40, 3, 335, DateTimeKind.Local).AddTicks(5096), null, null, false, 0, 0m, 4m, 0, "EF Core", null, 1 },
                    { 8, 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTKIa50KjBUhvtvuMbOaL_QtJrzstWIQA3YSg&s", new DateTime(2024, 9, 18, 21, 40, 3, 335, DateTimeKind.Local).AddTicks(5098), null, null, false, 0, 0m, 5m, 0, "Database Using SQL Server", null, 1 },
                    { 9, 1, "https://www.construx.com/wp-content/uploads/2018/08/design-pattern-essentials-course-image.jpg", new DateTime(2024, 9, 18, 21, 40, 3, 335, DateTimeKind.Local).AddTicks(5101), null, null, false, 0, 0m, 3m, 0, "Design Pattern", null, 1 },
                    { 10, 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS-HJM_i7rOg2yY9OgpVPYRLL4fYjA9CTfEoQ&s", new DateTime(2024, 9, 18, 21, 40, 3, 335, DateTimeKind.Local).AddTicks(5103), null, null, false, 0, 0m, 1m, 0, "SOLID Principle", null, 1 },
                    { 11, 2, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQtx7PjCp_KBWQZtHauOWMG2WiRpXxjpbYf3w&s", new DateTime(2024, 9, 18, 21, 40, 3, 335, DateTimeKind.Local).AddTicks(5105), null, null, false, 0, 0m, 4m, 0, "How To Train", null, 2 },
                    { 12, 2, "https://static.vecteezy.com/system/resources/previews/024/700/836/non_2x/fitness-gym-training-social-media-timeline-cover-and-video-thumbnail-and-web-banner-design-free-vector.jpg", new DateTime(2024, 9, 18, 21, 40, 3, 335, DateTimeKind.Local).AddTicks(5108), null, null, false, 0, 0m, 1m, 0, "Life Coach", null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "CourseId", "UserId" },
                values: new object[,]
                {
                    { 3, 3 },
                    { 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "CourseId", "UserId", "CompletedLessons", "EnrollmentDate", "ProgressPercentage" },
                values: new object[,]
                {
                    { 1, 3, null, new DateTime(2024, 9, 18, 21, 40, 3, 336, DateTimeKind.Local).AddTicks(7641), null },
                    { 2, 4, null, new DateTime(2024, 9, 18, 22, 40, 3, 336, DateTimeKind.Local).AddTicks(7664), null }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "CourseId", "Description", "UserId", "Value" },
                values: new object[,]
                {
                    { 1, 1, "Excellent course! Very well structured and informative.", 1, 5 },
                    { 2, 2, "Good course, but could use more examples.", 1, 4 },
                    { 3, 3, "Average course. The content was somewhat basic.", 2, 3 },
                    { 4, 4, "Great content, but the pace was a bit fast.", 3, 4 },
                    { 5, 5, "Not very helpful. The material was outdated.", 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "CourseId", "LessonsNo", "SectionNumber", "Title" },
                values: new object[,]
                {
                    { 1, 1, 3, 1, "intro" },
                    { 2, 1, 5, 2, "OOP" },
                    { 3, 2, 3, 1, "Binary search" },
                    { 4, 3, 4, 1, "Nutrition" },
                    { 5, 4, 3, 1, "General" }
                });

            migrationBuilder.InsertData(
                table: "WishList",
                columns: new[] { "CourseId", "UserId", "Id" },
                values: new object[,]
                {
                    { 3, 1, 0 },
                    { 4, 2, 0 }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "Content", "Duration", "SectionId", "Title" },
                values: new object[,]
                {
                    { 1, "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4", null, 1, "orientation" },
                    { 2, "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4", null, 1, "introduction" },
                    { 3, "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerBlazes.mp4", null, 2, "Encapsulation" },
                    { 4, "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerEscapes.mp4", null, 2, "inheritance" },
                    { 5, "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerFun.mp4", null, 2, "abstraction" },
                    { 6, "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerJoyrides.mp4", null, 2, "polymorphism" },
                    { 7, "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerMeltdowns.mp4", null, 3, "introduction" },
                    { 8, "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/Sintel.mp4", null, 3, "Binary tree" },
                    { 9, "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/SubaruOutbackOnStreetAndDirt.mp4", null, 4, "introduction" },
                    { 10, "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/TearsOfSteel.mp4", null, 4, "hum ya gamal" },
                    { 11, "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4", null, 4, "calories" },
                    { 12, "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4", null, 5, "3ash ya wa7sh" },
                    { 13, "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerBlazes.mp4", null, 5, "el3ab sa7" }
                });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "Grade", "SectionId", "Title" },
                values: new object[,]
                {
                    { 1, 0, 1, "Quiz1" },
                    { 2, 0, 2, "Quiz2" },
                    { 3, 0, 3, "Quiz3" },
                    { 4, 0, 4, "Quiz4" },
                    { 5, 0, 5, "Quiz5" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Body", "ModelAnswer", "QuizId" },
                values: new object[,]
                {
                    { 1, "Question1", 1, 1 },
                    { 2, "Question2", 2, 2 },
                    { 3, "Question3", 3, 3 },
                    { 4, "Question4", 2, 4 },
                    { 5, "Question5", 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Body", "QuestionId" },
                values: new object[,]
                {
                    { 1, "option1", 1 },
                    { 2, "option2", 1 },
                    { 3, "option3", 1 },
                    { 4, "option1", 2 },
                    { 5, "option2", 2 },
                    { 6, "option3", 2 },
                    { 7, "option1", 3 },
                    { 8, "option2", 3 },
                    { 9, "option3", 3 },
                    { 10, "option1", 4 },
                    { 11, "option2", 4 },
                    { 12, "option3", 4 },
                    { 13, "option1", 5 },
                    { 14, "option2", 5 },
                    { 15, "option3", 5 }
                });
        }
    }
}
