using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Learning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addcert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CertificatesOfCompletion",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "NEWID()"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    IssuedAy = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificatesOfCompletion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CertificatesOfCompletion_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CertificatesOfCompletion_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "f34fc4aa-fe52-4a05-a61c-0c2e38bf5fa9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "3a68d5b0-b04e-4c52-8a51-ca59d10ae6d7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "e9fda075-d9f5-4706-a782-3705703e55c5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "160d3456-cae4-4be2-bc53-e0b5e018becf");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 9, 16, 5, 38, 10, 887, DateTimeKind.Local).AddTicks(822));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 9, 16, 5, 38, 10, 887, DateTimeKind.Local).AddTicks(878));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 9, 16, 5, 38, 10, 887, DateTimeKind.Local).AddTicks(880));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 9, 16, 5, 38, 10, 887, DateTimeKind.Local).AddTicks(882));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2024, 9, 16, 5, 38, 10, 887, DateTimeKind.Local).AddTicks(883));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2024, 9, 16, 5, 38, 10, 887, DateTimeKind.Local).AddTicks(914));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2024, 9, 16, 5, 38, 10, 887, DateTimeKind.Local).AddTicks(916));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2024, 9, 16, 5, 38, 10, 887, DateTimeKind.Local).AddTicks(917));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationDate",
                value: new DateTime(2024, 9, 16, 5, 38, 10, 887, DateTimeKind.Local).AddTicks(919));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationDate",
                value: new DateTime(2024, 9, 16, 5, 38, 10, 887, DateTimeKind.Local).AddTicks(920));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreationDate",
                value: new DateTime(2024, 9, 16, 5, 38, 10, 887, DateTimeKind.Local).AddTicks(922));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreationDate",
                value: new DateTime(2024, 9, 16, 5, 38, 10, 887, DateTimeKind.Local).AddTicks(923));

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 1, 3 },
                column: "EnrollmentDate",
                value: new DateTime(2024, 9, 16, 5, 38, 10, 887, DateTimeKind.Local).AddTicks(7500));

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 2, 4 },
                column: "EnrollmentDate",
                value: new DateTime(2024, 9, 16, 6, 38, 10, 887, DateTimeKind.Local).AddTicks(7516));

            migrationBuilder.CreateIndex(
                name: "IX_CertificatesOfCompletion_CourseId",
                table: "CertificatesOfCompletion",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificatesOfCompletion_UserId",
                table: "CertificatesOfCompletion",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CertificatesOfCompletion");

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
                column: "CreationDate",
                value: new DateTime(2024, 9, 13, 22, 59, 32, 89, DateTimeKind.Local).AddTicks(1875));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 9, 13, 22, 59, 32, 89, DateTimeKind.Local).AddTicks(1920));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 9, 13, 22, 59, 32, 89, DateTimeKind.Local).AddTicks(1925));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 9, 13, 22, 59, 32, 89, DateTimeKind.Local).AddTicks(1928));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2024, 9, 13, 22, 59, 32, 89, DateTimeKind.Local).AddTicks(1931));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2024, 9, 13, 22, 59, 32, 89, DateTimeKind.Local).AddTicks(1934));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2024, 9, 13, 22, 59, 32, 89, DateTimeKind.Local).AddTicks(1937));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2024, 9, 13, 22, 59, 32, 89, DateTimeKind.Local).AddTicks(1940));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationDate",
                value: new DateTime(2024, 9, 13, 22, 59, 32, 89, DateTimeKind.Local).AddTicks(1944));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationDate",
                value: new DateTime(2024, 9, 13, 22, 59, 32, 89, DateTimeKind.Local).AddTicks(1947));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreationDate",
                value: new DateTime(2024, 9, 13, 22, 59, 32, 89, DateTimeKind.Local).AddTicks(1950));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreationDate",
                value: new DateTime(2024, 9, 13, 22, 59, 32, 89, DateTimeKind.Local).AddTicks(1954));

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
    }
}
