using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidades
{
    [Table("LibroCategoria", Schema = "dbo")]
    public class LibroCategoria
    {
        public string Isbn { get; set; }
        public int CategoriaId { get; set; }
        public virtual Libro Libro { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
