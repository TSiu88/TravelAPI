using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelApi.Migrations
{
    public partial class RemoveVirtual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2,
                columns: new[] { "Content", "Title" },
                values: new object[] { "Very modern city with busy but nice people", "Modern City" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2,
                columns: new[] { "Content", "Title" },
                values: new object[] { "Very mordern city with busy but nice people", "Mordern City" });
        }
    }
}
