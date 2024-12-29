using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Learning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FName", "LName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "16f9870b-7871-4af0-82c8-c9314dc492be", "AbdallahShatta@gmail.com", false, "Abdallah", "Shatta", false, null, null, null, null, null, false, "", null, false, null },
                    { 2, 0, "270ef7d7-a81d-4178-97cc-012d7789c47d", "MohamedErbahim@gmail.com", false, "Mohamed", "Ebrahim", false, null, null, null, null, null, false, "", null, false, null },
                    { 3, 0, "045869af-88b2-4047-b3a3-8eaebd16c868", "MohsemTayseer@gmail.com", false, "Mohsen", "Tayseer", false, null, null, null, null, null, false, "", null, false, null },
                    { 4, 0, "590ad4e1-5afc-4c4a-bb7e-7d3dd5550477", "MarwaElkasaby@gmail.com", false, "Marwa", "Elkasaby", false, null, null, null, null, null, false, "", null, false, null }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CoverPicture", "CreationDate", "Description", "Duration", "LessonsNo", "Price", "Rate", "SectionsNo", "Title", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2024, 9, 2, 20, 21, 11, 373, DateTimeKind.Local).AddTicks(7386), null, null, 0, 0m, null, 0, "C# From Zero To SuperHero", null, 1 },
                    { 2, 1, null, new DateTime(2024, 9, 2, 20, 21, 11, 373, DateTimeKind.Local).AddTicks(7438), null, null, 0, 0m, null, 0, "Data Strcutre", null, 1 },
                    { 3, 2, null, new DateTime(2024, 9, 2, 20, 21, 11, 373, DateTimeKind.Local).AddTicks(7441), null, null, 0, 0m, null, 0, "Diet", null, 2 },
                    { 4, 2, null, new DateTime(2024, 9, 2, 20, 21, 11, 373, DateTimeKind.Local).AddTicks(7445), null, null, 0, 0m, null, 0, "GYM", null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "CourseId", "UserId", "Id" },
                values: new object[,]
                {
                    { 3, 3, 0 },
                    { 4, 4, 0 }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "CourseId", "UserId", "CompletedLessons", "EnrollmentDate", "ProgressPercentage" },
                values: new object[,]
                {
                    { 1, 3, null, new DateTime(2024, 9, 2, 20, 21, 11, 374, DateTimeKind.Local).AddTicks(9138), null },
                    { 2, 4, null, new DateTime(2024, 9, 2, 21, 21, 11, 374, DateTimeKind.Local).AddTicks(9183), null }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "CourseId", "LessonsNo", "Title" },
                values: new object[,]
                {
                    { 1, 1, 3, "intro" },
                    { 2, 1, 5, "OOP" },
                    { 3, 2, 3, "Binary search" },
                    { 4, 3, 4, "Nutrition" },
                    { 5, 4, 3, "General" }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "Content", "Duration", "SectionId", "Title" },
                values: new object[,]
                {
                    { 1, "https://", null, 1, "orientation" },
                    { 2, "https://", null, 1, "introduction" },
                    { 3, "https://", null, 2, "Encpsulation" },
                    { 4, "https://", null, 2, "inheritance" },
                    { 5, "https://", null, 2, "abstraction" },
                    { 6, "https://", null, 2, "polymorphism" },
                    { 7, "https://", null, 3, "intoduction" },
                    { 8, "https://", null, 3, "Binary tree" },
                    { 9, "https://", null, 4, "introduction" },
                    { 10, "https://", null, 4, "hum ya gamal" },
                    { 11, "https://", null, 4, "calories" },
                    { 12, "https://", null, 5, "3ash ya wa7sh" },
                    { 13, "https://", null, 5, "el3ab sa7" }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "Cart",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Cart",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 4, 4 });

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
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4);

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
        }
    }
}
