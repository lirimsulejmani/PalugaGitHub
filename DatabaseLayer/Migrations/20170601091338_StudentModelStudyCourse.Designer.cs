using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DatabaseLayer;
using DatabaseLayer.Models;

namespace DatabaseLayer.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20170601091338_StudentModelStudyCourse")]
    partial class StudentModelStudyCourse
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DatabaseLayer.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Authors");

                    b.Property<string>("Description");

                    b.Property<string>("Edition");

                    b.Property<DateTime>("EntryDate");

                    b.Property<int>("GoodreadId");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Isbn");

                    b.Property<string>("Isbn13");

                    b.Property<string>("Language");

                    b.Property<string>("LargeImageUrl");

                    b.Property<string>("OriginalTitle");

                    b.Property<int>("Pages");

                    b.Property<DateTime?>("PublicationDate");

                    b.Property<string>("Publisher");

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("DatabaseLayer.Models.BookProviderClicksLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EntryDate");

                    b.Property<string>("Name");

                    b.Property<Guid?>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("BookProviderClicksLogs");
                });

            modelBuilder.Entity("DatabaseLayer.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<DateTime>("EntryDate");

                    b.Property<Guid?>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("DatabaseLayer.Models.DegreeProgram", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("EducationDegreeId");

                    b.Property<string>("Name");

                    b.Property<Guid?>("SchoolId");

                    b.HasKey("Id");

                    b.HasIndex("EducationDegreeId");

                    b.HasIndex("SchoolId");

                    b.ToTable("DegreePrograms");
                });

            modelBuilder.Entity("DatabaseLayer.Models.EducationDegree", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ShortTitle");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("EducationDegrees");
                });

            modelBuilder.Entity("DatabaseLayer.Models.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EntryDate");

                    b.Property<int>("NotificationType");

                    b.Property<Guid?>("WishlistId");

                    b.HasKey("Id");

                    b.HasIndex("WishlistId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("DatabaseLayer.Models.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment")
                        .HasMaxLength(5000);

                    b.Property<DateTime>("EntryDate");

                    b.Property<int>("Stars");

                    b.Property<Guid?>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("DatabaseLayer.Models.School", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("DatabaseLayer.Models.SellingBook", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookCondition");

                    b.Property<Guid?>("BookId");

                    b.Property<string>("Comment")
                        .HasMaxLength(200);

                    b.Property<DateTime>("EntryDate");

                    b.Property<decimal>("Price");

                    b.Property<int>("Status");

                    b.Property<Guid?>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("StudentId");

                    b.ToTable("SellingBooks");
                });

            modelBuilder.Entity("DatabaseLayer.Models.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AcademicDiscipline");

                    b.Property<bool>("Active");

                    b.Property<string>("Address");

                    b.Property<string>("ApiToken");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<bool>("Deleted");

                    b.Property<Guid?>("EducationDegreeId");

                    b.Property<string>("Email");

                    b.Property<bool>("IsFullTime");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<Guid?>("SchoolId");

                    b.Property<string>("StudyCourse");

                    b.HasKey("Id");

                    b.HasIndex("EducationDegreeId");

                    b.HasIndex("SchoolId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("DatabaseLayer.Models.StudyCourse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("DegreeProgramId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("DegreeProgramId");

                    b.ToTable("StudyCourses");
                });

            modelBuilder.Entity("DatabaseLayer.Models.StudyCourseBook", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BookId");

                    b.Property<Guid?>("StudyCourseId");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("StudyCourseId");

                    b.ToTable("StudyCourseBooks");
                });

            modelBuilder.Entity("DatabaseLayer.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<Guid?>("SchoolId");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DatabaseLayer.Models.Wishlist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("Book");

                    b.Property<DateTime>("EntryDate");

                    b.Property<int>("NotifiedStatus");

                    b.Property<Guid?>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Wishlists");
                });

            modelBuilder.Entity("DatabaseLayer.Models.BookProviderClicksLog", b =>
                {
                    b.HasOne("DatabaseLayer.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("DatabaseLayer.Models.Comment", b =>
                {
                    b.HasOne("DatabaseLayer.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("DatabaseLayer.Models.DegreeProgram", b =>
                {
                    b.HasOne("DatabaseLayer.Models.EducationDegree", "EducationDegree")
                        .WithMany()
                        .HasForeignKey("EducationDegreeId");

                    b.HasOne("DatabaseLayer.Models.School", "School")
                        .WithMany()
                        .HasForeignKey("SchoolId");
                });

            modelBuilder.Entity("DatabaseLayer.Models.Notification", b =>
                {
                    b.HasOne("DatabaseLayer.Models.Wishlist", "Wishlist")
                        .WithMany()
                        .HasForeignKey("WishlistId");
                });

            modelBuilder.Entity("DatabaseLayer.Models.Rating", b =>
                {
                    b.HasOne("DatabaseLayer.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("DatabaseLayer.Models.SellingBook", b =>
                {
                    b.HasOne("DatabaseLayer.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("DatabaseLayer.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("DatabaseLayer.Models.Student", b =>
                {
                    b.HasOne("DatabaseLayer.Models.EducationDegree", "EducationDegree")
                        .WithMany()
                        .HasForeignKey("EducationDegreeId");

                    b.HasOne("DatabaseLayer.Models.School", "School")
                        .WithMany()
                        .HasForeignKey("SchoolId");
                });

            modelBuilder.Entity("DatabaseLayer.Models.StudyCourse", b =>
                {
                    b.HasOne("DatabaseLayer.Models.DegreeProgram", "DegreeProgram")
                        .WithMany()
                        .HasForeignKey("DegreeProgramId");
                });

            modelBuilder.Entity("DatabaseLayer.Models.StudyCourseBook", b =>
                {
                    b.HasOne("DatabaseLayer.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("DatabaseLayer.Models.StudyCourse", "StudyCourse")
                        .WithMany()
                        .HasForeignKey("StudyCourseId");
                });

            modelBuilder.Entity("DatabaseLayer.Models.User", b =>
                {
                    b.HasOne("DatabaseLayer.Models.School", "School")
                        .WithMany()
                        .HasForeignKey("SchoolId");
                });

            modelBuilder.Entity("DatabaseLayer.Models.Wishlist", b =>
                {
                    b.HasOne("DatabaseLayer.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");
                });
        }
    }
}
