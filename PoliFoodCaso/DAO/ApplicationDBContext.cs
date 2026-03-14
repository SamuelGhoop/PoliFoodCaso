using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PoliFoodCaso.Models;

namespace PoliFoodCaso.DAO
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Tienda> Tienda { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Orden> Orden { get; set; }
        public DbSet<OrdenItem> OrdenItem { get; set; }
        public DbSet<CarritoItem> CarritoItem { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Evitar múltiples rutas de cascada en OrdenItem
            builder.Entity<OrdenItem>()
                .HasOne(oi => oi.producto)
                .WithMany()
                .HasForeignKey(oi => oi.productoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<OrdenItem>()
                .HasOne(oi => oi.orden)
                .WithMany()
                .HasForeignKey(oi => oi.ordenId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}