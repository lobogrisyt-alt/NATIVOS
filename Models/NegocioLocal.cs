using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NATIVOS.Models
{
    [Table("NegociosLocales")]
    public class NegocioLocal
    {
        [Key]
        public int IdNegocio { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(150)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Descripcion { get; set; }

        [StringLength(200)]
        public string? Ubicacion { get; set; }

        [Required]
        [StringLength(50)]
        public string EstadoVerificacion { get; set; } = "Pendiente";

        public DateTime FechaCreacion { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }

        public ICollection<Experiencia>? Experiencias { get; set; }

        public ICollection<Anuncio>? Anuncios { get; set; }

        public ICollection<ValidacionNegocio>? Validaciones { get; set; }
    }
}