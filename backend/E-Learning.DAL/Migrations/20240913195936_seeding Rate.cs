using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Learning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seedingRate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "27562a50-fbd3-41d3-a1a1-03c23957ba2e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "1504745a-7b4a-49e2-bcf4-d1e99259ecce");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "94db6034-d8fc-40e2-9cd2-9a832272585d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "9c94a222-5b1f-43ea-bfdc-5b96fbf05ad6");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "Rate" },
                values: new object[] { new DateTime(2024, 9, 13, 22, 59, 32, 89, DateTimeKind.Local).AddTicks(1875), 1m });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "Rate" },
                values: new object[] { new DateTime(2024, 9, 13, 22, 59, 32, 89, DateTimeKind.Local).AddTicks(1920), 2m });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "Rate" },
                values: new object[] { new DateTime(2024, 9, 13, 22, 59, 32, 89, DateTimeKind.Local).AddTicks(1925), 4m });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "Rate" },
                values: new object[] { new DateTime(2024, 9, 13, 22, 59, 32, 89, DateTimeKind.Local).AddTicks(1928), 2m });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "Rate" },
                values: new object[] { new DateTime(2024, 9, 13, 22, 59, 32, 89, DateTimeKind.Local).AddTicks(1931), 2m });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "Rate" },
                values: new object[] { new DateTime(2024, 9, 13, 22, 59, 32, 89, DateTimeKind.Local).AddTicks(1934), 5m });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "Rate" },
                values: new object[] { new DateTime(2024, 9, 13, 22, 59, 32, 89, DateTimeKind.Local).AddTicks(1937), 4m });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "Rate" },
                values: new object[] { new DateTime(2024, 9, 13, 22, 59, 32, 89, DateTimeKind.Local).AddTicks(1940), 5m });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "Rate" },
                values: new object[] { new DateTime(2024, 9, 13, 22, 59, 32, 89, DateTimeKind.Local).AddTicks(1944), 3m });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreationDate", "Rate" },
                values: new object[] { new DateTime(2024, 9, 13, 22, 59, 32, 89, DateTimeKind.Local).AddTicks(1947), 1m });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreationDate", "Rate" },
                values: new object[] { new DateTime(2024, 9, 13, 22, 59, 32, 89, DateTimeKind.Local).AddTicks(1950), 4m });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreationDate", "Rate" },
                values: new object[] { new DateTime(2024, 9, 13, 22, 59, 32, 89, DateTimeKind.Local).AddTicks(1954), 1m });

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 1, 3 },
                column: "EnrollmentDate",
                value: new DateTime(2024, 9, 13, 22, 59, 32, 92, DateTimeKind.Local).AddTicks(29));

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 2, 4 },
                column: "EnrollmentDate",
                value: new DateTime(2024, 9, 13, 23, 59, 32, 92, DateTimeKind.Local).AddTicks(79));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "381d0129-d4db-4b49-a7a4-a9d21e575bdc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "b7bd9b9a-5c34-43cd-8f4d-5db7f45f71c3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "4ee3da36-f338-4567-9f3b-a1bfdaf18da4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "74640ffb-8637-487b-bf8c-6e734545658b");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "Rate" },
                values: new object[] { new DateTime(2024, 9, 13, 14, 14, 31, 567, DateTimeKind.Local).AddTicks(1237), null });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "Rate" },
                values: new object[] { new DateTime(2024, 9, 13, 14, 14, 31, 567, DateTimeKind.Local).AddTicks(1290), null });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "Rate" },
                values: new object[] { new DateTime(2024, 9, 13, 14, 14, 31, 567, DateTimeKind.Local).AddTicks(1292), null });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "Rate" },
                values: new object[] { new DateTime(2024, 9, 13, 14, 14, 31, 567, DateTimeKind.Local).AddTicks(1294), null });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "Rate" },
                values: new object[] { new DateTime(2024, 9, 13, 14, 14, 31, 567, DateTimeKind.Local).AddTicks(1295), null });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "Rate" },
                values: new object[] { new DateTime(2024, 9, 13, 14, 14, 31, 567, DateTimeKind.Local).AddTicks(1296), null });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "Rate" },
                values: new object[] { new DateTime(2024, 9, 13, 14, 14, 31, 567, DateTimeKind.Local).AddTicks(1297), null });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "Rate" },
                values: new object[] { new DateTime(2024, 9, 13, 14, 14, 31, 567, DateTimeKind.Local).AddTicks(1298), null });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "Rate" },
                values: new object[] { new DateTime(2024, 9, 13, 14, 14, 31, 567, DateTimeKind.Local).AddTicks(1300), null });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreationDate", "Rate" },
                values: new object[] { new DateTime(2024, 9, 13, 14, 14, 31, 567, DateTimeKind.Local).AddTicks(1301), null });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreationDate", "Rate" },
                values: new object[] { new DateTime(2024, 9, 13, 14, 14, 31, 567, DateTimeKind.Local).AddTicks(1302), null });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreationDate", "Rate" },
                values: new object[] { new DateTime(2024, 9, 13, 14, 14, 31, 567, DateTimeKind.Local).AddTicks(1303), null });

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 1, 3 },
                column: "EnrollmentDate",
                value: new DateTime(2024, 9, 13, 14, 14, 31, 567, DateTimeKind.Local).AddTicks(7992));

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 2, 4 },
                column: "EnrollmentDate",
                value: new DateTime(2024, 9, 13, 15, 14, 31, 567, DateTimeKind.Local).AddTicks(8007));
        }
    }
}
