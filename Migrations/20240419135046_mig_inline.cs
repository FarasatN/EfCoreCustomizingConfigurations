using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreCustomizingConfigurations.Migrations
{
    /// <inheritdoc />
    public partial class mig_inline : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                create function bestSellingStaff(@totalOrderPrice int=0)
	                returns table
                as
                return 
                select top 1 p.Name, count(*) OrderCount, sum(o.Price) TotalOrderPrice from Persons p
                join Orders o
                 on p.PersonId = o.PersonId
                group by p.Name
                --having sum(o.Price)>1
                having sum(o.Price) > @totalOrderPrice
                order by OrderCount desc
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                drop function bestSellingStaff
            ");
        }
    }
}
