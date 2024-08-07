using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelFinder.DataAcces.Migrations
{
    public partial class RenameUserIdToId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "UserLocation");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "UserLastName");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Users",
                newName: "UserEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "UserLocation",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "UserLastName",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Users",
                newName: "Country");
        }
    }
}
