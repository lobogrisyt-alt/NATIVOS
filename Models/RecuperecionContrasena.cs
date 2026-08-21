using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NATIVOS.Models
{
    [Table("RecuperacionContrasena")]
    public class RecuperacionContrasena
    {
        [Key]
        public int IdRecuperacion { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(255)]
        public string TokenHash { get; set; } = string.Empty;

        public DateTime FechaSolicitud { get; set; }

        public DateTime FechaExpiracion { get; set; }

        public bool Usado { get; set; }

        public DateTime? FechaUso { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }
    }
}