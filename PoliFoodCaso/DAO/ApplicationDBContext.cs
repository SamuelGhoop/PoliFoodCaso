using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PoliFoodCaso.Models;

namespace PoliFoodCaso.DAO
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<OrdenItem> OrdenItems { get; set; }

        public DbSet<CarritoItem> CarritoItems { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var adminRolId = "rol-admin-001";
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = adminRolId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            var adminId = "usuario-admin-001";
            var hasher = new PasswordHasher<IdentityUser>();
            var adminUsuario = new IdentityUser
            {
                Id = adminId,
                UserName = "admin@polifood.edu",
                NormalizedUserName = "ADMIN@POLIFOOD.EDU",
                Email = "admin@polifood.edu",
                NormalizedEmail = "ADMIN@POLIFOOD.EDU",
                EmailConfirmed = true,
                SecurityStamp = "stamp-admin-001" //Requisito oara que no falle porque está fijo
            };
            adminUsuario.PasswordHash = hasher.HashPassword(adminUsuario, "Hola1234");

            builder.Entity<IdentityUser>().HasData(adminUsuario);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = adminId,
                RoleId = adminRolId
            });
        }
    }
}