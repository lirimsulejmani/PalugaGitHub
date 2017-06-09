using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DatabaseLayer;

namespace DatabaseLayer.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20170413212921_AllDBTables")]
    partial class AllDBTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DatabaseLayer.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Authors")
                        .HasMaxLength(500);

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<string>("Edition")
                        .HasMaxLength(50);

                    b.Property<DateTime>("EntryDate");

                    b.Property<string>("ISBN")
                        .HasMaxLength(50);

                    b.Property<string>("ImagePath");

                    b.Property<int>("Page");

                    b.Property<DateTime>("PublishDate");

                    b.Property<string>("Publisher")
                        .HasMaxLength(150);

                    b.Property<string>("Subtitle");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("DatabaseLayer.Models.School", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Schools");
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

            modelBuilder.Entity("DatabaseLayer.Models.User", b =>
                {
                    b.HasOne("DatabaseLayer.Models.School", "School")
                        .WithMany()
                        .HasForeignKey("SchoolId");
                });
        }
    }
}
