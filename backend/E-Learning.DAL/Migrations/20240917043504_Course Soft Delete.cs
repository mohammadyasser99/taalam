using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Learning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CourseSoftDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "8bf240cc-bc18-4dd4-9c8f-9718529ae531");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "63d56bc9-5d02-45f7-9081-5740f3a2ee56");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "e46b03c2-b3e2-4022-96ac-05ab9065b918");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "311fb445-12e8-4309-ba42-99b2d5a87405");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "IsDeleted" },
                values: new object[] { new DateTime(2024, 9, 17, 7, 35, 3, 990, DateTimeKind.Local).AddTicks(9915), false });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "IsDeleted" },
                values: new object[] { new DateTime(2024, 9, 17, 7, 35, 3, 990, DateTimeKind.Local).AddTicks(9970), false });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "IsDeleted" },
                values: new object[] { new DateTime(2024, 9, 17, 7, 35, 3, 990, DateTimeKind.Local).AddTicks(9971), false });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "IsDeleted" },
                values: new object[] { new DateTime(2024, 9, 17, 7, 35, 3, 990, DateTimeKind.Local).AddTicks(9973), false });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "IsDeleted" },
                values: new object[] { new DateTime(2024, 9, 17, 7, 35, 3, 990, DateTimeKind.Local).AddTicks(9974), false });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "IsDeleted" },
                values: new object[] { new DateTime(2024, 9, 17, 7, 35, 3, 990, DateTimeKind.Local).AddTicks(9976), false });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "IsDeleted" },
                values: new object[] { new DateTime(2024, 9, 17, 7, 35, 3, 990, DateTimeKind.Local).AddTicks(9977), false });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "IsDeleted" },
                values: new object[] { new DateTime(2024, 9, 17, 7, 35, 3, 991, DateTimeKind.Local).AddTicks(4), false });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "IsDeleted" },
                values: new object[] { new DateTime(2024, 9, 17, 7, 35, 3, 991, DateTimeKind.Local).AddTicks(6), false });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreationDate", "IsDeleted" },
                values: new object[] { new DateTime(2024, 9, 17, 7, 35, 3, 991, DateTimeKind.Local).AddTicks(7), false });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreationDate", "IsDeleted" },
                values: new object[] { new DateTime(2024, 9, 17, 7, 35, 3, 991, DateTimeKind.Local).AddTicks(8), false });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreationDate", "IsDeleted" },
                values: new object[] { new DateTime(2024, 9, 17, 7, 35, 3, 991, DateTimeKind.Local).AddTicks(10), false });

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 1, 3 },
                column: "EnrollmentDate",
                value: new DateTime(2024, 9, 17, 7, 35, 3, 991, DateTimeKind.Local).AddTicks(7205));

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 2, 4 },
                column: "EnrollmentDate",
                value: new DateTime(2024, 9, 17, 8, 35, 3, 991, DateTimeKind.Local).AddTicks(7221));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Courses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "c44972fd-99b6-40cf-8f32-5b6b8a1deb7b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "abc50908-cc36-4725-a4c3-335837f8e92c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "09b9d887-8637-46cd-8dd7-446716676a3c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "7e27a56f-74ff-48db-902c-a12ea21bd15b");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 9, 14, 22, 6, 2, 556, DateTimeKind.Local).AddTicks(1249));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 9, 14, 22, 6, 2, 556, DateTimeKind.Local).AddTicks(1300));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 9, 14, 22, 6, 2, 556, DateTimeKind.Local).AddTicks(1303));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 9, 14, 22, 6, 2, 556, DateTimeKind.Local).AddTicks(1306));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2024, 9, 14, 22, 6, 2, 556, DateTimeKind.Local).AddTicks(1308));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2024, 9, 14, 22, 6, 2, 556, DateTimeKind.Local).AddTicks(1310));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2024, 9, 14, 22, 6, 2, 556, DateTimeKind.Local).AddTicks(1313));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2024, 9, 14, 22, 6, 2, 556, DateTimeKind.Local).AddTicks(1315));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationDate",
                value: new DateTime(2024, 9, 14, 22, 6, 2, 556, DateTimeKind.Local).AddTicks(1317));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationDate",
                value: new DateTime(2024, 9, 14, 22, 6, 2, 556, DateTimeKind.Local).AddTicks(1319));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreationDate",
                value: new DateTime(2024, 9, 14, 22, 6, 2, 556, DateTimeKind.Local).AddTicks(1321));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreationDate",
                value: new DateTime(2024, 9, 14, 22, 6, 2, 556, DateTimeKind.Local).AddTicks(1323));

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 1, 3 },
                column: "EnrollmentDate",
                value: new DateTime(2024, 9, 14, 22, 6, 2, 557, DateTimeKind.Local).AddTicks(2029));

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 2, 4 },
                column: "EnrollmentDate",
                value: new DateTime(2024, 9, 14, 23, 6, 2, 557, DateTimeKind.Local).AddTicks(2047));
        }
    }
}
