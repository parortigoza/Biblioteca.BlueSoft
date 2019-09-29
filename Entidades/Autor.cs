using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    [Table("Autor", Schema = "dbo")]
    public class Autor
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AutorId { get; set; }
        [Required]
        [Column(TypeName = "varchar(150)")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [Column(TypeName = "varchar(150)")]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }
        [Required]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
    }
}
