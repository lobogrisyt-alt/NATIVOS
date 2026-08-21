using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NATIVOS.Models
{
    [Table("Reservas")]
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; }

        public int? IdUsuario { get; set; }

        public int? IdExperiencia { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Correo { get; set; } = string.Empty;

        [Required]
        [StringLength(30)]
        public string Telefono { get; set; } = string.Empty;

        public DateTime FechaReserva { get; set; }

        [Required]
        public DateTime FechaVisita { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int CantidadPersonas { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Range(0, double.MaxValue)]
        public decimal? Total { get; set; }

        [Required]
        [StringLength(30)]
        public string Estado { get; set; } = "Pendiente";

        [StringLength(300)]
        public string? Observaciones { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }

        [ForeignKey("IdExperiencia")]
        public Experiencia? Experiencia { get; set; }
    }
}