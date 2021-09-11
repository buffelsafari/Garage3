using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage3.Data.Migrations
{
    public partial class sk3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Garage3",
                table: "Garages",
                columns: new[] { "Id", "BasicFee", "Created", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 10m, new DateTime(2021, 9, 11, 14, 11, 31, 665, DateTimeKind.Local).AddTicks(7084), "nice garage", "SouthPark" },
                    { 2, 20m, new DateTime(2021, 9, 11, 14, 11, 31, 668, DateTimeKind.Local).AddTicks(336), "also nice garage", "NorthPark" },
                    { 3, 30m, new DateTime(2021, 9, 11, 14, 11, 31, 668, DateTimeKind.Local).AddTicks(370), "Nice view", "WestPark" },
                    { 4, 40m, new DateTime(2021, 9, 11, 14, 11, 31, 668, DateTimeKind.Local).AddTicks(378), "Close to trainstation", "EastPark" }
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
