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