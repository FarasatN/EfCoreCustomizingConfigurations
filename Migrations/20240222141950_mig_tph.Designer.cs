﻿// <auto-generated />
using EfCoreShadowProperties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EfCoreCustomizingConfigurations.Migrations
{
    [DbContext(typeof(Program.AppDbContext))]
    [Migration("20240222141950_mig_tph")]
    partial class mig_tph
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EfCoreShadowProperties.Program+Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EfCoreShadowProperties.Program+Customer", b =>
                {
                    b.HasBaseType("EfCoreShadowProperties.Program+Person");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("EfCoreShadowProperties.Program+Employee", b =>
                {
                    b.HasBaseType("EfCoreShadowProperties.Program+Person");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("EfCoreShadowProperties.Program+Technician", b =>
                {
                    b.HasBaseType("EfCoreShadowProperties.Program+Employee");

                    b.Property<string>("Branch")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Technician");
                });
#pragma warning restore 612, 618
        }
    }
}
