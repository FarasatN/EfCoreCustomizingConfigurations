using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreCustomizingConfigurations.Migrations
{
    /// <inheritdoc />
    public partial class mig_hasdiscriminator5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ayirici",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "MyEntities");

            migrationBuilder.AddColumn<int>(
                name: "Ayirici",
                table: "MyEntities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ayirici",
                table: "MyEntities");

            migrationBuilder.AddColumn<string>(
                name: "Ayirici",
                table: "Persons",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "MyEntities",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");
        }
    }
}
