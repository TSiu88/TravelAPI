using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelApi.Migrations
{
    public partial class CountryReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Reviews",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CountryId",
                table: "Reviews",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Countries_CountryId",
                table: "Reviews",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Countries_CountryId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_CountryId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Reviews");
        }
    }
}
