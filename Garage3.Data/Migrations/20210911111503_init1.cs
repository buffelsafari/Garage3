using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage3.Data.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    schema: "Garage3",
            //    table: "Garages",
            //    keyColumn: "Id",
            //    keyValue: 1);

            //migrationBuilder.DeleteData(
            //    schema: "Garage3",
            //    table: "Garages",
            //    keyColumn: "Id",
            //    keyValue: 2);

            //migrationBuilder.DeleteData(
            //    schema: "Garage3",
            //    table: "Garages",
            //    keyColumn: "Id",
            //    keyValue: 3);

            //migrationBuilder.DeleteData(
            //    schema: "Garage3",
            //    table: "Garages",
            //    keyColumn: "Id",
            //    keyValue: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.InsertData(
                schema: "Garage3",
                table: "Garages",
                columns: new[] { "Id", "BasicFee", "Created", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 10m, new DateTime(2021, 9, 11, 12, 57, 56, 922, DateTimeKind.Local).AddTicks(2780), "nice garage", "SouthPark" },
                    { 2, 20m, new DateTime(2021, 9, 11, 12, 57, 56, 924, DateTimeKind.Local).AddTicks(8019), "also nice garage", "NorthPark" },
                    { 3, 30m, new DateTime(2021, 9, 11, 12, 57, 56, 924, DateTimeKind.Local).AddTicks(8061), "Nice view", "WestPark" },
                    { 4, 40m, new DateTime(2021, 9, 11, 12, 57, 56, 924, DateTimeKind.Local).AddTicks(8066), "Close to trainstation", "EastPark" }
                });
        }
    }
}
