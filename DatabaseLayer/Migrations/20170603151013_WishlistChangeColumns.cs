using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DatabaseLayer.Migrations
{
    public partial class WishlistChangeColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Book",
                table: "Wishlists");

            migrationBuilder.AddColumn<string>(
                name: "BookISBN10",
                table: "Wishlists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookISBN13",
                table: "Wishlists",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookISBN10",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "BookISBN13",
                table: "Wishlists");

            migrationBuilder.AddColumn<Guid>(
                name: "Book",
                table: "Wishlists",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}