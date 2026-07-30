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
    }
}