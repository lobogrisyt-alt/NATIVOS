using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NATIVOS.Models
{
    [Table("Experiencias")]
    public class Experiencia
    {
        [Key]
        public int IdExperiencia { get; set; }

        [Required]
        public int IdNegocio { get; set; }

        [Required]
        public int IdCategoria { get; set; }

        [Required]
        [StringLength(150)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Descripcion { get; set; }

        [StringLength(200)]
        public string? Ubicacion { get; set; }

        [StringLength(100)]
        public string? Departamento { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Range(0, double.MaxValue)]
        public decimal Precio { get; set; }

        [StringLength(255)]
        public string? Imagen { get; set; }

        [Range(0, int.MaxValue)]
        public int CuposDisponibles { get; set; }

        [StringLength(50)]
        public string? Duracion { get; set; }

        [Required]
        [StringLength(30)]
        public string Estado { get; set; } = "Disponible";

        [ForeignKey("IdNegocio")]
        public NegocioLocal? Negocio { get; set; }

        [ForeignKey("IdCategoria")]
        public Categoria? Categoria { get; set; }

        public ICollection<Reserva>? Reservas { get; set; }
    }
}