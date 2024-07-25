using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelFinder.DataAcces.Migrations
{
    public partial class RenameidToID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Hotels",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Hotels",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Hotels",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Hotels",
                newName: "country");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Hotels",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Hotels",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Hotels",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Hotels",
                newName: "id");
        }
    }
}
