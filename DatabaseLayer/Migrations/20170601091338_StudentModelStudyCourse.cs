using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DatabaseLayer.Migrations
{
    public partial class StudentModelStudyCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudyCourses_StudyCourseId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_Books_BookId",
                table: "Wishlists");

            migrationBuilder.DropIndex(
                name: "IX_Wishlists_BookId",
                table: "Wishlists");

            migrationBuilder.DropIndex(
                name: "IX_Students_StudyCourseId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "StudyCourseId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PublishDate",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "ISBN",
                table: "Books",
                newName: "Isbn");

            migrationBuilder.RenameColumn(
                name: "Subtitle",
                table: "Books",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "Page",
                table: "Books",
                newName: "Pages");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Books",
                newName: "OriginalTitle");

            migrationBuilder.AddColumn<Guid>(
                name: "Book",
                table: "Wishlists",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "StudyCourse",
                table: "Students",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Publisher",
                table: "Books",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Isbn",
                table: "Books",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Edition",
                table: "Books",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Books",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Authors",
                table: "Books",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GoodreadId",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Isbn13",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LargeImageUrl",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublicationDate",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Book",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "StudyCourse",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GoodreadId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Isbn13",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "LargeImageUrl",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PublicationDate",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Isbn",
                table: "Books",
                newName: "ISBN");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Books",
                newName: "Subtitle");

            migrationBuilder.RenameColumn(
                name: "Pages",
                table: "Books",
                newName: "Page");

            migrationBuilder.RenameColumn(
                name: "OriginalTitle",
                table: "Books",
                newName: "ImagePath");

            migrationBuilder.AddColumn<Guid>(
                name: "BookId",
                table: "Wishlists",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudyCourseId",
                table: "Students",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Publisher",
                table: "Books",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Books",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Edition",
                table: "Books",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Books",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Authors",
                table: "Books",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishDate",
                table: "Books",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_BookId",
                table: "Wishlists",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudyCourseId",
                table: "Students",
                column: "StudyCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudyCourses_StudyCourseId",
                table: "Students",
                column: "StudyCourseId",
                principalTable: "StudyCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_Books_BookId",
                table: "Wishlists",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}