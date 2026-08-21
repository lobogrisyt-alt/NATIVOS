using Microsoft.EntityFrameworkCore;
using NATIVOS.Models;

namespace NATIVOS.Data
{
    public class NATIVOSContext : DbContext
    {
        public NATIVOSContext(DbContextOptions<NATIVOSContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<RecuperacionContrasena> RecuperacionesContrasena { get; set; }

        public DbSet<NegocioLocal> NegociosLocales { get; set; }

        public DbSet<ValidacionNegocio> ValidacionesNegocio { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Experiencia> Experiencias { get; set; }

        public DbSet<Reserva> Reservas { get; set; }

        public DbSet<Anuncio> Anuncios { get; set; }
    }
}