using Microsoft.EntityFrameworkCore;
using ProyNoSQL.Entities;

namespace ProyNoSQL
{
    public class ProyectoContext :DbContext
    {
        public ProyectoContext(DbContextOptions<ProyectoContext>options) : base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Horarios> Horarios { get; set; }
        public DbSet<Sucursales> Sucursales { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<Ordenes> Ordenes { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }

    }
}
