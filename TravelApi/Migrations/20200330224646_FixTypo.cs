using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelApi.Migrations
{
    public partial class FixTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 3,
                column: "CityName",
                value: "Singapore");

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "CityId", "Content", "CountryId", "Date", "Rating", "Title", "UserName" },
                values: new object[] { 7, 6, "Very large and very crowded", null, new DateTime(2020, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.0, "Forbidden City", "Mari" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 3,
                column: "CityName",
                value: "Singapore ");
        }
    }
}
