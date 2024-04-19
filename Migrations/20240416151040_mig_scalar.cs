using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreCustomizingConfigurations.Migrations
{
    /// <inheritdoc />
    public partial class mig_scalar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                create function getPersonTotalOrderPrice(@personId int)
	                returns int 
                as
                begin
	                declare @totalPrice int
	                select @totalPrice = sum(o.Price) from Persons p
	                join Orders o
		                on o.PersonId = p.PersonId
	                where p.PersonId = @personId
	                return @totalPrice
                end
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                drop function getPersonTotalOrderPrice
            ");
        }
    }
}
