using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreCustomizingConfigurations.Migrations
{
    /// <inheritdoc />
    public partial class mig_seeddata_with_foreignkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 20, 21, 9, 20, 229, DateTimeKind.Local).AddTicks(8196));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 20, 21, 9, 20, 229, DateTimeKind.Local).AddTicks(8210));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 20, 21, 9, 20, 229, DateTimeKind.Local).AddTicks(8366));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 20, 21, 9, 20, 229, DateTimeKind.Local).AddTicks(8369));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 20, 21, 8, 55, 574, DateTimeKind.Local).AddTicks(6863));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 20, 21, 8, 55, 574, DateTimeKind.Local).AddTicks(6864));
        }
    }
}
