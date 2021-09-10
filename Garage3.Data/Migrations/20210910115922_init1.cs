using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage3.Data.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BasicFee",
                schema: "Garage3",
                table: "Garages",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BasicFee",
                schema: "Garage3",
                table: "Garages");
        }
    }
}
