using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage3.Data.Migrations
{
    public partial class hasdata2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Garage3",
                table: "Garages",
                columns: new[] { "Id", "BasicFee", "Created", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 10m, new DateTime(2021, 9, 10, 18, 5, 42, 193, DateTimeKind.Local).AddTicks(7405), "nice garage", "SouthPark" },
                    { 2, 10m, new DateTime(2021, 9, 10, 18, 5, 42, 196, DateTimeKind.Local).AddTicks(4536), "also nice garage", "NorthPark" },
                    { 3, 10m, new DateTime(2021, 9, 10, 18, 5, 42, 196, DateTimeKind.Local).AddTicks(4581), "Nice view", "WestPark" },
                    { 4, 10m, new DateTime(2021, 9, 10, 18, 5, 42, 196, DateTimeKind.Local).AddTicks(4585), "Close to trainstation", "EastPark" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Garage3",
                table: "Garages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Garage3",
                table: "Garages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Garage3",
                table: "Garages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Garage3",
                table: "Garages",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
