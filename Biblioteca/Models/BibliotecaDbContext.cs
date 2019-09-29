using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class BibliotecaDbContext: DbContext
    {
        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            //Property Configurations
            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasIndex(l => l.Isbn).IsUnique();
            });
            modelBuilder.Entity<LibroCategoria>().HasKey(x => new { x.Isbn, x.CategoriaId });

            modelBuilder.Entity<LibroCategoria>()
            .HasOne(lc => lc.Libro)
            .WithMany(l => l.LibroCategoria)
            .HasForeignKey(lc => lc.Isbn);

            modelBuilder.Entity<LibroCategoria>()
                .HasOne(lc => lc.Categoria)
                .WithMany(c => c.LibroCategoria)
                .HasForeignKey(lc => lc.CategoriaId);
        }

        public DbSet<Autor> Autor { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Libro> Libro { get; set; }
        public DbSet<LibroCategoria> LibroCategoria { get; set; }
    }
}
