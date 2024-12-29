using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Learning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DataSeedingCoverPictures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "ProfilePicture" },
                values: new object[] { "a42fd417-36f1-49cf-8801-1753b8ff40c7", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTAM-SBzUfYOMhwc0o76MpvR7N4Yi43lcYt5g&s" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "ProfilePicture" },
                values: new object[] { "b4625f63-ad5f-4849-adb0-2be1498d2666", "https://pbs.twimg.com/profile_images/1745781333400399872/MN7Wm4Ya_400x400.jpg" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "56873a5a-0f87-4aef-8505-e6c3310ca085");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "66577466-f86b-48e8-af4c-1fc6c0ec43a7");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CoverPicture", "CreationDate" },
                values: new object[] { "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQPvJBvVedFjpONzC1ZOR-YSWauBp9ZKK6ydA&s", new DateTime(2024, 9, 5, 6, 50, 27, 175, DateTimeKind.Local).AddTicks(5432) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CoverPicture", "CreationDate" },
                values: new object[] { "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS2o9_OmdunGnBKDIiSGo3uLYvA8vySqQ-M9fyVT_nys9HMMbZJv8cU8YtPkPbexgrf3J8&usqp=CAU", new DateTime(2024, 9, 5, 6, 50, 27, 175, DateTimeKind.Local).AddTicks(5480) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CoverPicture", "CreationDate" },
                values: new object[] { "https://dynamic.brandcrowd.com/template/preview/design/90728fda-b283-4797-973e-9a0775dec439?v=4&designTemplateVersion=5&size=design-preview-standalone-1x", new DateTime(2024, 9, 5, 6, 50, 27, 175, DateTimeKind.Local).AddTicks(5483) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CoverPicture", "CreationDate" },
                values: new object[] { "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSo1cHnjZlK64h9Pc5OvWCYfYWYexByKhPpeg&s", new DateTime(2024, 9, 5, 6, 50, 27, 175, DateTimeKind.Local).AddTicks(5486) });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CoverPicture", "CreationDate", "Description", "Duration", "LessonsNo", "Price", "Rate", "SectionsNo", "Title", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 5, 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQCmO_j4YW82XwWIM-_Fo6afxyuN2pSGoZMBQ&s", new DateTime(2024, 9, 5, 6, 50, 27, 175, DateTimeKind.Local).AddTicks(5489), null, null, 0, 0m, null, 0, "Alogrithms", null, 1 },
                    { 6, 1, "https://d1jnx9ba8s6j9r.cloudfront.net/imgver.1551437392/img/co_img_1539_1633434090.png", new DateTime(2024, 9, 5, 6, 50, 27, 175, DateTimeKind.Local).AddTicks(5492), null, null, 0, 0m, null, 0, "Introduction to C++", null, 1 },
                    { 7, 1, "https://static.gunnarpeipman.com/wp-content/uploads/2019/12/ef-core-featured.png", new DateTime(2024, 9, 5, 6, 50, 27, 175, DateTimeKind.Local).AddTicks(5495), null, null, 0, 0m, null, 0, "EF Core", null, 1 },
                    { 8, 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTKIa50KjBUhvtvuMbOaL_QtJrzstWIQA3YSg&s", new DateTime(2024, 9, 5, 6, 50, 27, 175, DateTimeKind.Local).AddTicks(5497), null, null, 0, 0m, null, 0, "Database Using SQL Server", null, 1 },
                    { 9, 1, "https://www.construx.com/wp-content/uploads/2018/08/design-pattern-essentials-course-image.jpg", new DateTime(2024, 9, 5, 6, 50, 27, 175, DateTimeKind.Local).AddTicks(5500), null, null, 0, 0m, null, 0, "Design Pattern", null, 1 },
                    { 10, 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS-HJM_i7rOg2yY9OgpVPYRLL4fYjA9CTfEoQ&s", new DateTime(2024, 9, 5, 6, 50, 27, 175, DateTimeKind.Local).AddTicks(5502), null, null, 0, 0m, null, 0, "SOLID Principle", null, 1 },
                    { 11, 2, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQtx7PjCp_KBWQZtHauOWMG2WiRpXxjpbYf3w&s", new DateTime(2024, 9, 5, 6, 50, 27, 175, DateTimeKind.Local).AddTicks(5505), null, null, 0, 0m, null, 0, "How To Train", null, 2 },
                    { 12, 2, "https://static.vecteezy.com/system/resources/previews/024/700/836/non_2x/fitness-gym-training-social-media-timeline-cover-and-video-thumbnail-and-web-banner-design-free-vector.jpg", new DateTime(2024, 9, 5, 6, 50, 27, 175, DateTimeKind.Local).AddTicks(5508), null, null, 0, 0m, null, 0, "Life Coach", null, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 1, 3 },
                column: "EnrollmentDate",
                value: new DateTime(2024, 9, 5, 6, 50, 27, 176, DateTimeKind.Local).AddTicks(5684));

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 2, 4 },
                column: "EnrollmentDate",
                value: new DateTime(2024, 9, 5, 7, 50, 27, 176, DateTimeKind.Local).AddTicks(5725));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "ProfilePicture" },
                values: new object[] { "78f4a6bc-f110-496c-9238-675210250dfa", "" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "ProfilePicture" },
                values: new object[] { "e6ab065c-6113-462e-b1aa-003a98cf6243", "" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "24e2f6b1-0ac0-4b79-a275-101022c907df");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "c5e7a6ec-d236-44bc-873e-610f53d290cc");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CoverPicture", "CreationDate" },
                values: new object[] { null, new DateTime(2024, 9, 2, 22, 47, 50, 931, DateTimeKind.Local).AddTicks(1441) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CoverPicture", "CreationDate" },
                values: new object[] { null, new DateTime(2024, 9, 2, 22, 47, 50, 931, DateTimeKind.Local).AddTicks(1517) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CoverPicture", "CreationDate" },
                values: new object[] { null, new DateTime(2024, 9, 2, 22, 47, 50, 931, DateTimeKind.Local).AddTicks(1523) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CoverPicture", "CreationDate" },
                values: new object[] { null, new DateTime(2024, 9, 2, 22, 47, 50, 931, DateTimeKind.Local).AddTicks(1527) });

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 1, 3 },
                column: "EnrollmentDate",
                value: new DateTime(2024, 9, 2, 22, 47, 50, 933, DateTimeKind.Local).AddTicks(1867));

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 2, 4 },
                column: "EnrollmentDate",
                value: new DateTime(2024, 9, 2, 23, 47, 50, 933, DateTimeKind.Local).AddTicks(1958));
        }
    }
}
