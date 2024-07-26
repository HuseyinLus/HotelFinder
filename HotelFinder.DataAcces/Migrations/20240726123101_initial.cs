using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelFinder.DataAcces.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cars_HotelId",
                table: "Cars",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Hotels_HotelId",
                table: "Cars",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Hotels_HotelId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_HotelId",
                table: "Cars");
        }
    }
}
