﻿// <auto-generated />
using System;
using ImageGlassWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ImageGlassWeb.Migrations
{
    [DbContext(typeof(ImageGlassContext))]
    [Migration("20231019105136_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ImageGlassWeb.Models.BinaryFileModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<string>("Architecture")
                        .HasColumnType("varchar(20)")
                        .HasColumnOrder(4);

                    b.Property<int>("Count")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnOrder(7);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnOrder(99)
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("FileType")
                        .HasColumnType("varchar(10)")
                        .HasColumnOrder(5);

                    b.Property<bool?>("IsVisible")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true)
                        .HasColumnOrder(1);

                    b.Property<string>("Link")
                        .HasColumnType("varchar(255)")
                        .HasColumnOrder(6);

                    b.Property<int>("ReleaseId")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<string>("Type")
                        .HasColumnType("varchar(50)")
                        .HasColumnOrder(3);

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnOrder(100)
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("ReleaseId");

                    b.ToTable("BinaryFiles");
                });

            modelBuilder.Entity("ImageGlassWeb.Models.ExtensionIconModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<string>("Author")
                        .HasColumnType("varchar(50)")
                        .HasColumnOrder(8);

                    b.Property<int>("Count")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnOrder(11);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnOrder(99)
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(150)")
                        .HasColumnOrder(4);

                    b.Property<string>("Email")
                        .HasColumnType("varchar(50)")
                        .HasColumnOrder(9);

                    b.Property<string>("Image")
                        .HasColumnType("varchar(255)")
                        .HasColumnOrder(5);

                    b.Property<bool?>("IsVisible")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true)
                        .HasColumnOrder(1);

                    b.Property<string>("Link")
                        .HasColumnType("varchar(255)")
                        .HasColumnOrder(6);

                    b.Property<string>("Slug")
                        .HasColumnType("varchar(80)")
                        .HasColumnOrder(2);

                    b.Property<string>("Title")
                        .HasColumnType("varchar(150)")
                        .HasColumnOrder(3);

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnOrder(100)
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Version")
                        .HasColumnType("varchar(20)")
                        .HasColumnOrder(7);

                    b.Property<string>("Website")
                        .HasColumnType("varchar(255)")
                        .HasColumnOrder(10);

                    b.HasKey("Id");

                    b.ToTable("ExtensionIcons");
                });

            modelBuilder.Entity("ImageGlassWeb.Models.NewsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnOrder(99)
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(150)")
                        .HasColumnOrder(4);

                    b.Property<string>("Image")
                        .HasColumnType("varchar(255)")
                        .HasColumnOrder(5);

                    b.Property<bool?>("IsVisible")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true)
                        .HasColumnOrder(1);

                    b.Property<string>("Slug")
                        .HasColumnType("varchar(80)")
                        .HasColumnOrder(2);

                    b.Property<string>("Title")
                        .HasColumnType("varchar(150)")
                        .HasColumnOrder(3);

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnOrder(100)
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("ImageGlassWeb.Models.ReleaseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnOrder(99)
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Image")
                        .HasColumnType("varchar(255)")
                        .HasColumnOrder(4);

                    b.Property<bool?>("IsVisible")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true)
                        .HasColumnOrder(1);

                    b.Property<int?>("NewsId")
                        .HasColumnType("int")
                        .HasColumnOrder(5);

                    b.Property<string>("ReleaseChannel")
                        .HasColumnType("varchar(50)")
                        .HasColumnOrder(7);

                    b.Property<int>("RequirementId")
                        .HasColumnType("int")
                        .HasColumnOrder(9);

                    b.Property<string>("ScreenshotsDir")
                        .HasColumnType("varchar(50)")
                        .HasColumnOrder(8);

                    b.Property<string>("Slug")
                        .HasColumnType("varchar(80)")
                        .HasColumnOrder(2);

                    b.Property<string>("Title")
                        .HasColumnType("varchar(150)")
                        .HasColumnOrder(3);

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnOrder(100)
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Version")
                        .HasColumnType("varchar(20)")
                        .HasColumnOrder(6);

                    b.HasKey("Id");

                    b.HasIndex("NewsId");

                    b.HasIndex("RequirementId");

                    b.ToTable("Releases");
                });

            modelBuilder.Entity("ImageGlassWeb.Models.RequirementModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<string>("Content")
                        .HasColumnType("text")
                        .HasColumnOrder(2);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnOrder(99)
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<bool?>("IsVisible")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true)
                        .HasColumnOrder(1);

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnOrder(100)
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.ToTable("Requirements");
                });

            modelBuilder.Entity("ImageGlassWeb.Models.ThemeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<string>("Author")
                        .HasColumnType("varchar(50)")
                        .HasColumnOrder(10);

                    b.Property<string>("Compatibility")
                        .HasColumnType("varchar(50)")
                        .HasColumnOrder(9);

                    b.Property<int>("Count")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnOrder(13);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnOrder(99)
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(300)")
                        .HasColumnOrder(4);

                    b.Property<string>("Email")
                        .HasColumnType("varchar(50)")
                        .HasColumnOrder(11);

                    b.Property<string>("Image")
                        .HasColumnType("varchar(255)")
                        .HasColumnOrder(5);

                    b.Property<bool>("IsDarkMode")
                        .HasColumnType("tinyint(1)")
                        .HasColumnOrder(7);

                    b.Property<bool?>("IsVisible")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true)
                        .HasColumnOrder(1);

                    b.Property<string>("Link")
                        .HasColumnType("varchar(255)")
                        .HasColumnOrder(6);

                    b.Property<string>("Slug")
                        .HasColumnType("varchar(80)")
                        .HasColumnOrder(2);

                    b.Property<string>("Title")
                        .HasColumnType("varchar(150)")
                        .HasColumnOrder(3);

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnOrder(100)
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Version")
                        .HasColumnType("varchar(20)")
                        .HasColumnOrder(8);

                    b.Property<string>("Website")
                        .HasColumnType("varchar(255)")
                        .HasColumnOrder(12);

                    b.HasKey("Id");

                    b.ToTable("Themes");
                });

            modelBuilder.Entity("ImageGlassWeb.Models.BinaryFileModel", b =>
                {
                    b.HasOne("ImageGlassWeb.Models.ReleaseModel", "Release")
                        .WithMany("BinaryFiles")
                        .HasForeignKey("ReleaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Release");
                });

            modelBuilder.Entity("ImageGlassWeb.Models.ReleaseModel", b =>
                {
                    b.HasOne("ImageGlassWeb.Models.NewsModel", "News")
                        .WithMany()
                        .HasForeignKey("NewsId");

                    b.HasOne("ImageGlassWeb.Models.RequirementModel", "Requirement")
                        .WithMany("Releases")
                        .HasForeignKey("RequirementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("News");

                    b.Navigation("Requirement");
                });

            modelBuilder.Entity("ImageGlassWeb.Models.ReleaseModel", b =>
                {
                    b.Navigation("BinaryFiles");
                });

            modelBuilder.Entity("ImageGlassWeb.Models.RequirementModel", b =>
                {
                    b.Navigation("Releases");
                });
#pragma warning restore 612, 618
        }
    }
}
