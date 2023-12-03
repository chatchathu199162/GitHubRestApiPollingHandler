﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PollingScheduler.DataBase;

#nullable disable

namespace DeveloperProductivityTracker.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20231127124031_yy")]
    partial class yy
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DeveloperProductivityTracker.DataBase.Models.CommitsHistory", b =>
                {
                    b.Property<int>("CommitsHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommitsHistoryId"), 1L, 1);

                    b.Property<string>("Addition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContributorId")
                        .HasColumnType("int");

                    b.Property<string>("Deletion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WeekNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommitsHistoryId");

                    b.ToTable("CommitsHistory");
                });

            modelBuilder.Entity("DeveloperProductivityTracker.DataBase.Models.Contributor", b =>
                {
                    b.Property<int>("ContributorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContributorId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserLogin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContributorId");

                    b.ToTable("Contributors");
                });
#pragma warning restore 612, 618
        }
    }
}
