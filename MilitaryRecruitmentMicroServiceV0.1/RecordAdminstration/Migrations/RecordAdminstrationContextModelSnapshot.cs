﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecordAdminstrationAPI.Data;

namespace RecordAdminstrationAPI.Migrations
{
    [DbContext(typeof(RecordAdminstrationContext))]
    partial class RecordAdminstrationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RecordAdminstrationAPI.Models.Brothers", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrotherId")
                        .HasColumnType("int");

                    b.Property<int>("Personid")
                        .HasColumnType("int");

                    b.Property<int?>("RecordsAdminstrationid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("RecordsAdminstrationid");

                    b.ToTable("BrothersDB");
                });

            modelBuilder.Entity("RecordAdminstrationAPI.Models.RecordsAdminstration", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<bool>("Death")
                        .HasColumnType("bit");

                    b.Property<string>("FathersName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MothersName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("MinistryOfForeignAffairsDB");
                });

            modelBuilder.Entity("RecordAdminstrationAPI.Models.Brothers", b =>
                {
                    b.HasOne("RecordAdminstrationAPI.Models.RecordsAdminstration", null)
                        .WithMany("Brothers")
                        .HasForeignKey("RecordsAdminstrationid");
                });

            modelBuilder.Entity("RecordAdminstrationAPI.Models.RecordsAdminstration", b =>
                {
                    b.Navigation("Brothers");
                });
#pragma warning restore 612, 618
        }
    }
}