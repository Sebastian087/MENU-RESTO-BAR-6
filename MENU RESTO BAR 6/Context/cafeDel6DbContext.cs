using MENU_RESTO_BAR_6.Models;
using Microsoft.EntityFrameworkCore;

namespace MENU_RESTO_BAR_6.Context

{



    public class CafeDel6DbContext : DbContext
    {
        public CafeDel6DbContext(DbContextOptions<CafeDel6DbContext> options) : base(options) 
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Reserva> Reservas { get; set; }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<MotivoCancelacion> MotivosCancelacion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la relación
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.MotivoCancelacion)
                .WithMany(m => m.Reservas)
                .HasForeignKey(r => r.MotivoCancelacionId);
        }
    }

}