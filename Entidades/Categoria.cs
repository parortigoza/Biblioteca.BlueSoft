using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidades
{
    [Table("Categoria", Schema = "dbo")]
    public class Categoria
    {
        public Categoria()
        {
            LibroCategoria = new List<LibroCategoria>();
        }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoriaId { get; set; }
        [Required]
        [Column(TypeName = "varchar(150)")]
        [Display(Name = "Categoria")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Descripcion { get; set; }
        public List<LibroCategoria> LibroCategoria { get; set; }
    }
}
