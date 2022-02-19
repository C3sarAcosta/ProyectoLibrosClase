﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProyectoLibros.Data;

#nullable disable

namespace ProyectoLibros.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220219165116_Libros")]
    partial class Libros
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProyectoLibros.Models.Autores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ApellidoMaterno")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ApellidoPaterno")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("Date");

                    b.Property<string>("Nacionalidad")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RFC")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("ProyectoLibros.Models.Categorias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("ProyectoLibros.Models.Libros", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AutoresId")
                        .HasColumnType("integer");

                    b.Property<int>("CategoriasId")
                        .HasColumnType("integer");

                    b.Property<string>("Editorial")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Precio")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("AutoresId");

                    b.HasIndex("CategoriasId");

                    b.ToTable("Libros");
                });

            modelBuilder.Entity("ProyectoLibros.Models.Libros", b =>
                {
                    b.HasOne("ProyectoLibros.Models.Autores", "Autores")
                        .WithMany("Libros")
                        .HasForeignKey("AutoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoLibros.Models.Categorias", "Categorias")
                        .WithMany("Libros")
                        .HasForeignKey("CategoriasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autores");

                    b.Navigation("Categorias");
                });

            modelBuilder.Entity("ProyectoLibros.Models.Autores", b =>
                {
                    b.Navigation("Libros");
                });

            modelBuilder.Entity("ProyectoLibros.Models.Categorias", b =>
                {
                    b.Navigation("Libros");
                });
#pragma warning restore 612, 618
        }
    }
}