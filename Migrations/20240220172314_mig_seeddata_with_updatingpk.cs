using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreCustomizingConfigurations.Migrations
{
    /// <inheritdoc />
    public partial class mig_seeddata_with_updatingpk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 20, 21, 23, 14, 282, DateTimeKind.Local).AddTicks(234));

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "BlogId", "CreatedDate", "Title" },
                values: new object[] { 3, new DateTime(2024, 2, 20, 21, 23, 14, 282, DateTimeKind.Local).AddTicks(221), "Quantum" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 20, 21, 23, 14, 282, DateTimeKind.Local).AddTicks(417));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 20, 21, 23, 14, 282, DateTimeKind.Local).AddTicks(419));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 20, 21, 9, 20, 229, DateTimeKind.Local).AddTicks(8210));

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "BlogId", "CreatedDate", "Title" },
                values: new object[] { 1, new DateTime(2024, 2, 20, 21, 9, 20, 229, DateTimeKind.Local).AddTicks(8196), "Quantum" });

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
    }
}
