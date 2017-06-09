using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseLayer.Migrations
{
    public partial class StudentApiToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Students",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Students",
                newName: "ApiToken");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Students",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Students",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Students",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "ApiToken",
                table: "Students",
                newName: "FirstName");
        }
    }
}