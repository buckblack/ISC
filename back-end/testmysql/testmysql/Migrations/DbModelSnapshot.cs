﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using testmysql.Models;

namespace testmysql.Migrations
{
    [DbContext(typeof(Db))]
    partial class DbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("testmysql.Models.Major", b =>
                {
                    b.Property<int>("MajorID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("MajorID");

                    b.ToTable("Majors");
                });

            modelBuilder.Entity("testmysql.Models.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<int>("MajorID");

                    b.Property<string>("Name")
                        .HasColumnName("StudentName")
                        .HasMaxLength(100);

                    b.HasKey("StudentID");

                    b.HasIndex("MajorID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("testmysql.Models.Student", b =>
                {
                    b.HasOne("testmysql.Models.Major", "Major")
                        .WithMany()
                        .HasForeignKey("MajorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}