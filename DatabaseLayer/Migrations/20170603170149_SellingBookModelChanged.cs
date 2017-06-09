using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DatabaseLayer.Migrations
{
    public partial class SellingBookModelChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellingBooks_Books_BookId",
                table: "SellingBooks");

            migrationBuilder.DropIndex(
                name: "IX_SellingBooks_BookId",
                table: "SellingBooks");

            migrationBuilder.AlterColumn<string>(
                name: "BookId",
                table: "SellingBooks",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Isbn10",
                table: "SellingBooks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Isbn13",
                table: "SellingBooks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Isbn10",
                table: "SellingBooks");

            migrationBuilder.DropColumn(
                name: "Isbn13",
                table: "SellingBooks");

            migrationBuilder.AlterColumn<Guid>(
                name: "BookId",
                table: "SellingBooks",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SellingBooks_BookId",
                table: "SellingBooks",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_SellingBooks_Books_BookId",
                table: "SellingBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}