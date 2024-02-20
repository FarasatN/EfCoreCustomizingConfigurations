using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreCustomizingConfigurations.Migrations
{
    /// <inheritdoc />
    public partial class mig_seeddata_with_updatingpk_for_dependantpk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 20, 21, 31, 8, 866, DateTimeKind.Local).AddTicks(4954));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 20, 21, 31, 8, 866, DateTimeKind.Local).AddTicks(4879));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 20, 21, 31, 8, 866, DateTimeKind.Local).AddTicks(5116));

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "BlogId", "Content", "CreatedDate" },
                values: new object[] { 8, 2, "Islam and evolution", new DateTime(2024, 2, 20, 21, 31, 8, 866, DateTimeKind.Local).AddTicks(5114) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 20, 21, 23, 14, 282, DateTimeKind.Local).AddTicks(234));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 20, 21, 23, 14, 282, DateTimeKind.Local).AddTicks(221));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 20, 21, 23, 14, 282, DateTimeKind.Local).AddTicks(419));

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "BlogId", "Content", "CreatedDate" },
                values: new object[] { 1, 2, "Islam and evolution", new DateTime(2024, 2, 20, 21, 23, 14, 282, DateTimeKind.Local).AddTicks(417) });
        }
    }
}
