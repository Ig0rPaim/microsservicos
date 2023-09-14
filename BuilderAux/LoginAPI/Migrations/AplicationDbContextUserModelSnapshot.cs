﻿// <auto-generated />
using System;
using LoginAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LoginAPI.Migrations
{
    [DbContext(typeof(AplicationDbContextUser))]
    partial class AplicationDbContextUserModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LoginAPI.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataCadastro = new DateTime(2023, 9, 14, 11, 53, 38, 95, DateTimeKind.Local).AddTicks(1999),
                            Email = "igorpaimdeoliveira@gmail.com",
                            Nome = "Igor Paim de Oliveira",
                            Password = "password",
                            Phone = "71999434958"
                        },
                        new
                        {
                            Id = 2,
                            DataCadastro = new DateTime(2023, 9, 14, 11, 53, 38, 95, DateTimeKind.Local).AddTicks(2026),
                            Email = "Rogeriodeoliveira@gmail.com",
                            Nome = "Rogerio Oliveira",
                            Password = "password",
                            Phone = "71999434958"
                        },
                        new
                        {
                            Id = 3,
                            DataCadastro = new DateTime(2023, 9, 14, 11, 53, 38, 95, DateTimeKind.Local).AddTicks(2033),
                            Email = "Magnopaim@gmail.com",
                            Nome = "Magno Paim",
                            Password = "password",
                            Phone = "71999434958"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
