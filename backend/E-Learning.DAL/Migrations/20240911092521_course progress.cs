using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Learning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class courseprogress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompletedLessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    EnrollmentCourseId = table.Column<int>(type: "int", nullable: true),
                    EnrollmentUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedLessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompletedLessons_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompletedLessons_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompletedLessons_Enrollments_EnrollmentUserId_EnrollmentCourseId",
                        columns: x => new { x.EnrollmentUserId, x.EnrollmentCourseId },
                        principalTable: "Enrollments",
                        principalColumns: new[] { "UserId", "CourseId" });
                    table.ForeignKey(
                        name: "FK_CompletedLessons_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "76ca856a-3b15-438b-bd1b-40069c220d81");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "221fcc8a-ff87-49c8-ae66-a3dd65cf1f6a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "138b65c1-e900-44bc-a8bf-56ba71147be5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "a0684875-bf07-428f-b60a-a3f4521c3ac2");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 9, 11, 12, 25, 21, 209, DateTimeKind.Local).AddTicks(9015));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 9, 11, 12, 25, 21, 209, DateTimeKind.Local).AddTicks(9115));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 9, 11, 12, 25, 21, 209, DateTimeKind.Local).AddTicks(9118));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 9, 11, 12, 25, 21, 209, DateTimeKind.Local).AddTicks(9119));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2024, 9, 11, 12, 25, 21, 209, DateTimeKind.Local).AddTicks(9120));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2024, 9, 11, 12, 25, 21, 209, DateTimeKind.Local).AddTicks(9122));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2024, 9, 11, 12, 25, 21, 209, DateTimeKind.Local).AddTicks(9123));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2024, 9, 11, 12, 25, 21, 209, DateTimeKind.Local).AddTicks(9124));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationDate",
                value: new DateTime(2024, 9, 11, 12, 25, 21, 209, DateTimeKind.Local).AddTicks(9126));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationDate",
                value: new DateTime(2024, 9, 11, 12, 25, 21, 209, DateTimeKind.Local).AddTicks(9127));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreationDate",
                value: new DateTime(2024, 9, 11, 12, 25, 21, 209, DateTimeKind.Local).AddTicks(9128));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreationDate",
                value: new DateTime(2024, 9, 11, 12, 25, 21, 209, DateTimeKind.Local).AddTicks(9130));

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 1, 3 },
                column: "EnrollmentDate",
                value: new DateTime(2024, 9, 11, 12, 25, 21, 210, DateTimeKind.Local).AddTicks(7865));

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 2, 4 },
                column: "EnrollmentDate",
                value: new DateTime(2024, 9, 11, 13, 25, 21, 210, DateTimeKind.Local).AddTicks(7880));

            migrationBuilder.CreateIndex(
                name: "IX_CompletedLessons_CourseId",
                table: "CompletedLessons",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedLessons_EnrollmentUserId_EnrollmentCourseId",
                table: "CompletedLessons",
                columns: new[] { "EnrollmentUserId", "EnrollmentCourseId" });

            migrationBuilder.CreateIndex(
                name: "IX_CompletedLessons_LessonId",
                table: "CompletedLessons",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedLessons_UserId",
                table: "CompletedLessons",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompletedLessons");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e48441d0-a250-420c-82ce-5abb58936422");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "a53a387d-86ba-4145-93de-4ea30bf9a7ce");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "b0e861b5-47e0-4b30-9006-ea35e18a37e6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "bf72d091-fdf4-41d1-bd2f-aceb70ed29af");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 9, 7, 23, 55, 14, 409, DateTimeKind.Local).AddTicks(9487));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 9, 7, 23, 55, 14, 409, DateTimeKind.Local).AddTicks(9543));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 9, 7, 23, 55, 14, 409, DateTimeKind.Local).AddTicks(9544));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 9, 7, 23, 55, 14, 409, DateTimeKind.Local).AddTicks(9546));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2024, 9, 7, 23, 55, 14, 409, DateTimeKind.Local).AddTicks(9547));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2024, 9, 7, 23, 55, 14, 409, DateTimeKind.Local).AddTicks(9548));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2024, 9, 7, 23, 55, 14, 409, DateTimeKind.Local).AddTicks(9549));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2024, 9, 7, 23, 55, 14, 409, DateTimeKind.Local).AddTicks(9550));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationDate",
                value: new DateTime(2024, 9, 7, 23, 55, 14, 409, DateTimeKind.Local).AddTicks(9551));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationDate",
                value: new DateTime(2024, 9, 7, 23, 55, 14, 409, DateTimeKind.Local).AddTicks(9553));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreationDate",
                value: new DateTime(2024, 9, 7, 23, 55, 14, 409, DateTimeKind.Local).AddTicks(9554));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreationDate",
                value: new DateTime(2024, 9, 7, 23, 55, 14, 409, DateTimeKind.Local).AddTicks(9555));

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 1, 3 },
                column: "EnrollmentDate",
                value: new DateTime(2024, 9, 7, 23, 55, 14, 410, DateTimeKind.Local).AddTicks(2872));

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 2, 4 },
                column: "EnrollmentDate",
                value: new DateTime(2024, 9, 8, 0, 55, 14, 410, DateTimeKind.Local).AddTicks(2889));
        }
    }
}
