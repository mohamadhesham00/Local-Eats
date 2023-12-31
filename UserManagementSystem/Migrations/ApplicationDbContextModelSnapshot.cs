﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UserManagementSystem.Src.Infrastructure.Db;

#nullable disable

namespace UserManagementSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UserManagementSystem.Src.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("64973898-05bd-42b5-b10c-3b9ab8bcffff"),
                            Email = "mohamed@localeats.com",
                            FirstName = "Mohamed",
                            LastName = "Hesham",
                            Password = "$2a$11$tNIisxr8dllvFKUW.d5if.o1sonXfU.EaxFmAqxlOYMlWtqNdLXau"
                        },
                        new
                        {
                            Id = new Guid("58cd96c2-6a4c-494a-ad7c-090022a0710b"),
                            Email = "abdelrahman@localeats.com",
                            FirstName = "Abdelrahman",
                            LastName = "Omran",
                            Password = "$2a$11$yoy18ypb41gPTqASazMbG.qRhUD6V57GLhDLJh7nBrpn9NJvkTzHG"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
