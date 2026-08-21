using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NATIVOS.Models
{
    [Table("Anuncios")]
    public class Anuncio
    {
        [Key]
        public int IdAnuncio { get; set; }

        [Required]
        public int IdNegocio { get; set; }

        [Required]
        [StringLength(150)]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        public string Contenido { get; set; } = string.Empty;

        [StringLength(255)]
        public string? ImagenDestacada { get; set; }

        public DateTime FechaPublicacion { get; set; }

        public DateTime? FechaExpiracion { get; set; }

        [Required]
        [StringLength(30)]
        public string Estado { get; set; } = "Activo";

        [ForeignKey("IdNegocio")]
        public NegocioLocal? Negocio { get; set; }
    }
}