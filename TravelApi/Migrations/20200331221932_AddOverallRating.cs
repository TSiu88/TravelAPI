using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelApi.Migrations
{
    public partial class AddOverallRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "OverallRating",
                table: "Cities",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OverallRating",
                table: "Cities");
        }
    }
}
