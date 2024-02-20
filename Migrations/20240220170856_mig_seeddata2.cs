using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EfCoreCustomizingConfigurations.Migrations
{
    /// <inheritdoc />
    public partial class mig_seeddata2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 20, 21, 8, 55, 574, DateTimeKind.Local).AddTicks(6652));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 20, 21, 8, 55, 574, DateTimeKind.Local).AddTicks(6665));

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "BlogId", "Content", "CreatedDate" },
                values: new object[,]
                {
                    { 1, 2, "Islam and evolution", new DateTime(2024, 2, 20, 21, 8, 55, 574, DateTimeKind.Local).AddTicks(6863) },
                    { 2, 1, "Schrodinger's cat", new DateTime(2024, 2, 20, 21, 8, 55, 574, DateTimeKind.Local).AddTicks(6864) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 20, 20, 54, 39, 334, DateTimeKind.Local).AddTicks(1230));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 20, 20, 54, 39, 334, DateTimeKind.Local).AddTicks(1241));
        }
    }
}
