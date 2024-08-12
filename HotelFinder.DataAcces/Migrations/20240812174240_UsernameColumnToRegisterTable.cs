using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelFinder.DataAcces.Migrations
{
    public partial class UsernameColumnToRegisterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Registers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Registers");
        }
    }
}
