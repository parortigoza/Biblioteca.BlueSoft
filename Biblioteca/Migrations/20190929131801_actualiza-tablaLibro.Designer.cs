﻿// <auto-generated />
using System;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Biblioteca.Migrations
{
    [DbContext(typeof(BibliotecaDbContext))]
    [Migration("20190929131801_actualiza-tablaLibro")]
    partial class actualizatablaLibro
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entidades.Autor", b =>
                {
                    b.Property<int>("AutorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("AutorId");

                    b.ToTable("Autor","dbo");
                });

            modelBuilder.Entity("Entidades.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria","dbo");
                });

            modelBuilder.Entity("Entidades.Libro", b =>
                {
                    b.Property<string>("Isbn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(13)");

                    b.Property<int>("Fk_AutorInfo");

                    b.Property<string>("NombreLibro")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Isbn");

                    b.HasIndex("Fk_AutorInfo");

                    b.HasIndex("Isbn")
                        .IsUnique();

                    b.ToTable("Libro","dbo");
                });

            modelBuilder.Entity("Entidades.LibroCategoria", b =>
                {
                    b.Property<string>("Isbn");

                    b.Property<int>("CategoriaId");

                    b.HasKey("Isbn", "CategoriaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("LibroCategoria","dbo");
                });

            modelBuilder.Entity("Entidades.Libro", b =>
                {
                    b.HasOne("Entidades.Autor", "Autor")
                        .WithMany()
                        .HasForeignKey("Fk_AutorInfo")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entidades.LibroCategoria", b =>
                {
                    b.HasOne("Entidades.Categoria", "Categorias")
                        .WithMany("Libros")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entidades.Libro", "Libros")
                        .WithMany()
                        .HasForeignKey("Isbn")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
