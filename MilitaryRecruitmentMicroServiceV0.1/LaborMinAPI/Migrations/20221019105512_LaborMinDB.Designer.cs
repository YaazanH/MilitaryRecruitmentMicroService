﻿// <auto-generated />
using System;
using LaborMinAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LaborMinAPI.Migrations
{
    [DbContext(typeof(LaborMinContext))]
    [Migration("20221019105512_LaborMinDB")]
    partial class LaborMinDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LaborMinAPI.Models.Workers", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAWorker")
                        .HasColumnType("bit");

                    b.Property<DateTime>("dateofjoin")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("LaborMinDB");
                });
#pragma warning restore 612, 618
        }
    }
}