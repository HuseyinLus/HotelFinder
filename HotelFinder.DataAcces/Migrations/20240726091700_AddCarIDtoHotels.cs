using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelFinder.DataAcces.Migrations
{
    public partial class AddCarIDtoHotels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarID",
                table: "Hotels",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarID",
                table: "Hotels");
        }
    }
}
