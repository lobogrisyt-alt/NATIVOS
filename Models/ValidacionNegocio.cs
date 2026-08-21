using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NATIVOS.Models
{
    [Table("ValidacionesNegocio")]
    public class ValidacionNegocio
    {
        [Key]
        public int IdValidacion { get; set; }

        [Required]
        public int IdNegocio { get; set; }

        public int? IdAdministrador { get; set; }

        [StringLength(500)]
        public string? DocumentosAdjuntos { get; set; }

        public DateTime FechaSolicitud { get; set; }

        public DateTime? FechaRevision { get; set; }

        [Required]
        [StringLength(50)]
        public string EstadoResolucion { get; set; } = "Pendiente";

        [StringLength(500)]
        public string? ComentariosAdmin { get; set; }

        [ForeignKey("IdNegocio")]
        public NegocioLocal? Negocio { get; set; }

        [ForeignKey("IdAdministrador")]
        public Usuario? Administrador { get; set; }
    }
}