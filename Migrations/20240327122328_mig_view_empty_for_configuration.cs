using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreCustomizingConfigurations.Migrations
{
    /// <inheritdoc />
    public partial class mig_view_empty_for_configuration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                create view vm_PersonOrders
                as
                select top 1000 p.Name, count(*) [Count] from Persons p
                inner join Orders o
	                on p.PersonId = o.PersonId
                group by p.Name
                order by [Count] desc
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                drop view vm_PersonOrders
            ");
        }
    }
}
