using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidades
{
    [Table("Libro", Schema = "dbo")]
    public class Libro
    {
        public Libro()
        {
            LibroCategoria = new List<LibroCategoria>();
        }

        [Key]
        [Required]
        [Column(TypeName = "varchar(13)")]
        public string Isbn { get; set; }
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string NombreLibro { get; set; }
        public int AutorId { get; set; }
        [ForeignKey("AutorId")]
        public Autor Autor { get; set; }
        public List<LibroCategoria> LibroCategoria { get; set; }
    }
}
