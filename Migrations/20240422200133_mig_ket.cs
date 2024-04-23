using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreCustomizingConfigurations.Migrations
{
    /// <inheritdoc />
    public partial class mig_ket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                create view vw_PersonOrderCount
                as
	                select p.Name, count(*) [Count] from Persons p
	                join Orders o
	                on p.PersonId = o.PersonId
	                group by p.Name
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                drop view vw_PersonOrderCount
            ");
        }
    }
}
