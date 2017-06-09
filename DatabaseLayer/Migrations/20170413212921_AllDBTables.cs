using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DatabaseLayer.Migrations
{
    public partial class AllDBTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Books",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Books",
                newName: "Subtitle");

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Books",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Authors",
                table: "Books",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Books",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Edition",
                table: "Books",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "Books",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Page",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishDate",
                table: "Books",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Publisher",
                table: "Books",
                maxLength: 150,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Authors",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Edition",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Page",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PublishDate",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Publisher",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Books",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Subtitle",
                table: "Books",
                newName: "Author");

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Books",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}