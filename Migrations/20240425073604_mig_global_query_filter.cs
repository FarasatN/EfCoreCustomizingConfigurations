﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreCustomizingConfigurations.Migrations
{
    /// <inheritdoc />
    public partial class mig_global_query_filter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Persons",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Persons");
        }
    }
}
