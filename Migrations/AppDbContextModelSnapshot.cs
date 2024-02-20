﻿// <auto-generated />
using System;
using EfCoreShadowProperties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EfCoreCustomizingConfigurations.Migrations
{
    [DbContext(typeof(Program.AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EfCoreShadowProperties.Program+Address", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId2")
                        .HasColumnType("int");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("CreatedDate")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId", "PersonId2", "AddressId");

                    b.HasIndex("PersonId", "PersonId2")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("EfCoreShadowProperties.Program+Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("CreatedDate")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("EfCoreShadowProperties.Program+Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BlogId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BlogId");

                    b.ToTable("Blogs");

                    b.HasData(
                        new
                        {
                            BlogId = 3,
                            CreatedDate = new DateTime(2024, 2, 20, 21, 31, 8, 866, DateTimeKind.Local).AddTicks(4879),
                            Title = "Quantum"
                        },
                        new
                        {
                            BlogId = 2,
                            CreatedDate = new DateTime(2024, 2, 20, 21, 31, 8, 866, DateTimeKind.Local).AddTicks(4954),
                            Title = "Evolution"
                        });
                });

            modelBuilder.Entity("EfCoreShadowProperties.Program+Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("CreatedDate")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("EfCoreShadowProperties.Program+BookAuthor", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("CreatedDate")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("BookAuthors");
                });

            modelBuilder.Entity("EfCoreShadowProperties.Program+Example", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Computed")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("int")
                        .HasComputedColumnSql("[X]+[Y]");

                    b.Property<Guid>("ExampleCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("ExampleDate")
                        .HasColumnType("datetime2(7)");

                    b.Property<int>("X")
                        .HasMaxLength(7)
                        .HasColumnType("int");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Examples");
                });

            modelBuilder.Entity("EfCoreShadowProperties.Program+MyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Ayirici")
                        .HasColumnType("int");

                    b.Property<string>("X")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MyEntities");

                    b.HasDiscriminator<int>("Ayirici").HasValue(3);

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EfCoreShadowProperties.Program+Person", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId2")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("CreatedDate")
                        .HasDefaultValueSql("GETDATE()")
                        .HasComment("bu yaradilacaq obyektin tarixini ozunde tutur");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.Property<string>("Surname")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("PersonId", "PersonId2");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("EfCoreShadowProperties.Program+Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostId"));

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PostId");

                    b.HasIndex("BlogId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            PostId = 8,
                            BlogId = 2,
                            Content = "Islam and evolution",
                            CreatedDate = new DateTime(2024, 2, 20, 21, 31, 8, 866, DateTimeKind.Local).AddTicks(5114)
                        },
                        new
                        {
                            PostId = 2,
                            BlogId = 1,
                            Content = "Schrodinger's cat",
                            CreatedDate = new DateTime(2024, 2, 20, 21, 31, 8, 866, DateTimeKind.Local).AddTicks(5116)
                        });
                });

            modelBuilder.Entity("EfCoreShadowProperties.Program+A", b =>
                {
                    b.HasBaseType("EfCoreShadowProperties.Program+MyEntity");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("EfCoreShadowProperties.Program+B", b =>
                {
                    b.HasBaseType("EfCoreShadowProperties.Program+MyEntity");

                    b.Property<int>("Z")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("EfCoreShadowProperties.Program+Address", b =>
                {
                    b.HasOne("EfCoreShadowProperties.Program+Person", "Person")
                        .WithOne("Address")
                        .HasForeignKey("EfCoreShadowProperties.Program+Address", "PersonId", "PersonId2")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("EfCoreShadowProperties.Program+BookAuthor", b =>
                {
                    b.HasOne("EfCoreShadowProperties.Program+Author", "Author")
                        .WithMany("BookAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfCoreShadowProperties.Program+Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("EfCoreShadowProperties.Program+Post", b =>
                {
                    b.HasOne("EfCoreShadowProperties.Program+Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("EfCoreShadowProperties.Program+Author", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("EfCoreShadowProperties.Program+Blog", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("EfCoreShadowProperties.Program+Book", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("EfCoreShadowProperties.Program+Person", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
