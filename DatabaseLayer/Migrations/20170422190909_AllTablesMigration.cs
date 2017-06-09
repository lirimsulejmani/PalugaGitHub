using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DatabaseLayer.Migrations
{
    public partial class AllTablesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EducationDegrees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ShortTitle = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationDegrees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DegreePrograms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EducationDegreeId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SchoolId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreePrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DegreePrograms_EducationDegrees_EducationDegreeId",
                        column: x => x.EducationDegreeId,
                        principalTable: "EducationDegrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DegreePrograms_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudyCourses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DegreeProgramId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyCourses_DegreePrograms_DegreeProgramId",
                        column: x => x.DegreeProgramId,
                        principalTable: "DegreePrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AcademicDiscipline = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    EducationDegreeId = table.Column<Guid>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    IsFullTime = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    SchoolId = table.Column<Guid>(nullable: true),
                    StudyCourseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_EducationDegrees_EducationDegreeId",
                        column: x => x.EducationDegreeId,
                        principalTable: "EducationDegrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_StudyCourses_StudyCourseId",
                        column: x => x.StudyCourseId,
                        principalTable: "StudyCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudyCourseBooks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BookId = table.Column<Guid>(nullable: true),
                    StudyCourseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyCourseBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyCourseBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudyCourseBooks_StudyCourses_StudyCourseId",
                        column: x => x.StudyCourseId,
                        principalTable: "StudyCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookProviderClicksLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StudentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookProviderClicksLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookProviderClicksLogs_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Body = table.Column<string>(nullable: true),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Comment = table.Column<string>(maxLength: 5000, nullable: true),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    Stars = table.Column<int>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SellingBooks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BookCondition = table.Column<int>(nullable: false),
                    BookId = table.Column<Guid>(nullable: true),
                    Comment = table.Column<string>(maxLength: 200, nullable: true),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellingBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellingBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SellingBooks_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wishlists",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BookId = table.Column<Guid>(nullable: true),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    NotifiedStatus = table.Column<int>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wishlists_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wishlists_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    NotificationType = table.Column<int>(nullable: false),
                    WishlistId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Wishlists_WishlistId",
                        column: x => x.WishlistId,
                        principalTable: "Wishlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookProviderClicksLogs_StudentId",
                table: "BookProviderClicksLogs",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_StudentId",
                table: "Comments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_DegreePrograms_EducationDegreeId",
                table: "DegreePrograms",
                column: "EducationDegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_DegreePrograms_SchoolId",
                table: "DegreePrograms",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_WishlistId",
                table: "Notifications",
                column: "WishlistId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_StudentId",
                table: "Ratings",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingBooks_BookId",
                table: "SellingBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingBooks_StudentId",
                table: "SellingBooks",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_EducationDegreeId",
                table: "Students",
                column: "EducationDegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolId",
                table: "Students",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudyCourseId",
                table: "Students",
                column: "StudyCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyCourses_DegreeProgramId",
                table: "StudyCourses",
                column: "DegreeProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyCourseBooks_BookId",
                table: "StudyCourseBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyCourseBooks_StudyCourseId",
                table: "StudyCourseBooks",
                column: "StudyCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_BookId",
                table: "Wishlists",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_StudentId",
                table: "Wishlists",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookProviderClicksLogs");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "SellingBooks");

            migrationBuilder.DropTable(
                name: "StudyCourseBooks");

            migrationBuilder.DropTable(
                name: "Wishlists");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "StudyCourses");

            migrationBuilder.DropTable(
                name: "DegreePrograms");

            migrationBuilder.DropTable(
                name: "EducationDegrees");
        }
    }
}