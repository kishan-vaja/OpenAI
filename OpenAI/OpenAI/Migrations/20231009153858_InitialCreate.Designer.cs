﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpenAI.Models;

#nullable disable

namespace OpenAI.Migrations
{
    [DbContext(typeof(GenAIToolsDbContext))]
    [Migration("20231009153858_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OpenAI.Models.GenAIToolsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AnchorLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("GenAIName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImageFilename")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Like")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(Max)");

                    b.HasKey("Id");

                    b.ToTable("DbSet");
                });
#pragma warning restore 612, 618
        }
    }
}
