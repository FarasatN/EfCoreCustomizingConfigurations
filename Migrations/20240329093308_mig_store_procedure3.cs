using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreCustomizingConfigurations.Migrations
{
    /// <inheritdoc />
    public partial class mig_store_procedure3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                create procedure sp_BestSellingStaff
                as
	                declare @name nvarchar(max), @count int
	                select @name = p.Name, @count = count(*) from Persons p
	                join Orders o
		                on p.PersonId = o.PersonId
	                group by p.Name
	                order by count(*) desc
	                return @name
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"drop procedure sp_BestSellingStaff");

        }
    }
}
