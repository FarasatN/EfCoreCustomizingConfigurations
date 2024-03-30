using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreCustomizingConfigurations.Migrations
{
    /// <inheritdoc />
    public partial class mig_store_procedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                create procedure sp_PersonOrders
                as
                select p.Name, count(*) from Persons p
                join Orders o
	                on p.PersonId = o.PersonId
                group by p.Name
                order by count(*) desc
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                 drop procedure sp_PersonOrders
            ");

        }
    }
}
