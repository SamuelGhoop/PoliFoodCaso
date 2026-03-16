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

            //ROLES
            string adminRoleId = "a1b2c3d4-0001-4000-8000-000000000001";
            string vendorRoleId = "a1b2c3d4-0002-4000-8000-000000000002";
            string studentRoleId = "a1b2c3d4-0003-4000-8000-000000000003";

            builder.Entity<IdentityRole>().HasData(
    new IdentityRole { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = adminRoleId },
    new IdentityRole { Id = vendorRoleId, Name = "Vendor", NormalizedName = "VENDOR", ConcurrencyStamp = vendorRoleId },
    new IdentityRole { Id = studentRoleId, Name = "Student", NormalizedName = "STUDENT", ConcurrencyStamp = studentRoleId }
);

            //USUARIOS
            string adminUserId = "b1b2c3d4-1001-4000-8000-000000000001";
            string vendor1Id = "b1b2c3d4-2001-4000-8000-000000000002";
            string vendor2Id = "b1b2c3d4-2002-4000-8000-000000000003";
            string student1Id = "b1b2c3d4-3001-4000-8000-000000000004";

            string passwordHash = "AQAAAAIAAYagAAAAEEBWGNitMvuS+1Fw5Yby2cDtcrn7ZRJWCz1ZNei8DQ1UxMRtzahLv77X6zn5eY/3+g==";

            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = adminUserId,
                    UserName = "admin@polifood.edu",
                    NormalizedUserName = "ADMIN@POLIFOOD.EDU",
                    Email = "admin@polifood.edu",
                    NormalizedEmail = "ADMIN@POLIFOOD.EDU",
                    EmailConfirmed = true,
                    PasswordHash = passwordHash,
                    SecurityStamp = "seed-stamp-admin1",
                    ConcurrencyStamp = adminUserId
                },
                new IdentityUser
                {
                    Id = vendor1Id,
                    UserName = "burguer@polifood.edu",
                    NormalizedUserName = "BURGUER@POLIFOOD.EDU",
                    Email = "burguer@polifood.edu",
                    NormalizedEmail = "BURGUER@POLIFOOD.EDU",
                    EmailConfirmed = true,
                    PasswordHash = passwordHash,
                    SecurityStamp = "seed-stamp-vendor1",
                    ConcurrencyStamp = vendor1Id
                },
                new IdentityUser
                {
                    Id = vendor2Id,
                    UserName = "pizza@polifood.edu",
                    NormalizedUserName = "PIZZA@POLIFOOD.EDU",
                    Email = "pizza@polifood.edu",
                    NormalizedEmail = "PIZZA@POLIFOOD.EDU",
                    EmailConfirmed = true,
                    PasswordHash = passwordHash,
                    SecurityStamp = "seed-stamp-vendor2",
                    ConcurrencyStamp = vendor2Id
                },
                new IdentityUser
                {
                    Id = student1Id,
                    UserName = "estudiante@polifood.edu",
                    NormalizedUserName = "ESTUDIANTE@POLIFOOD.EDU",
                    Email = "estudiante@polifood.edu",
                    NormalizedEmail = "ESTUDIANTE@POLIFOOD.EDU",
                    EmailConfirmed = true,
                    PasswordHash = passwordHash,
                    SecurityStamp = "seed-stamp-student1",
                    ConcurrencyStamp = student1Id
                }
            );

            //ROLES ASIGNADOS
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = adminUserId, RoleId = adminRoleId },
                new IdentityUserRole<string> { UserId = vendor1Id, RoleId = vendorRoleId },
                new IdentityUserRole<string> { UserId = vendor2Id, RoleId = vendorRoleId },
                new IdentityUserRole<string> { UserId = student1Id, RoleId = studentRoleId }
            );

            //TIENDAS
            string tienda1Id = "c1b2c3d4-4001-4000-8000-000000000005";
            string tienda2Id = "c1b2c3d4-4002-4000-8000-000000000006";

            builder.Entity<Tienda>().HasData(
                new Tienda { id_tienda = Guid.Parse(tienda1Id), nombre_tienda = "Burguer Campus", isActive = 1, vendorId = vendor1Id },
                new Tienda { id_tienda = Guid.Parse(tienda2Id), nombre_tienda = "Pizza Poli", isActive = 1, vendorId = vendor2Id }
            );

            //CATEGORÍAS
            string cat1Id = "d1b2c3d4-5001-4000-8000-000000000007";
            string cat2Id = "d1b2c3d4-5002-4000-8000-000000000008";
            string cat3Id = "d1b2c3d4-5003-4000-8000-000000000009";
            string cat4Id = "d1b2c3d4-5004-4000-8000-000000000010";

            builder.Entity<Categoria>().HasData(
                new Categoria { id_categoria = Guid.Parse(cat1Id), nombre_categoria = "Hamburguesas", isActive = 1, tiendaId = Guid.Parse(tienda1Id) },
                new Categoria { id_categoria = Guid.Parse(cat2Id), nombre_categoria = "Bebidas", isActive = 1, tiendaId = Guid.Parse(tienda1Id) },
                new Categoria { id_categoria = Guid.Parse(cat3Id), nombre_categoria = "Pizzas", isActive = 1, tiendaId = Guid.Parse(tienda2Id) },
                new Categoria { id_categoria = Guid.Parse(cat4Id), nombre_categoria = "Postres", isActive = 1, tiendaId = Guid.Parse(tienda2Id) }
            );

            //PRODUCTOS (12)
            builder.Entity<Producto>().HasData(
                new Producto { id_producto = Guid.Parse("e1b2c3d4-6001-4000-8000-000000000011"), nombre_producto = "Clásica", descripcion = "Carne 150g, lechuga, tomate, queso", precio = 12500, imagen_url = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?w=300", disponible = true, minutos_preparacion = 10, isActive = 1, categoriaId = Guid.Parse(cat1Id) },
                new Producto { id_producto = Guid.Parse("e1b2c3d4-6002-4000-8000-000000000012"), nombre_producto = "Doble Cheddar", descripcion = "Doble carne, doble queso cheddar", precio = 16500, imagen_url = "https://images.unsplash.com/photo-1553979459-d2229ba7433b?w=300", disponible = true, minutos_preparacion = 12, isActive = 1, categoriaId = Guid.Parse(cat1Id) },
                new Producto { id_producto = Guid.Parse("e1b2c3d4-6003-4000-8000-000000000013"), nombre_producto = "Pollo Crispy", descripcion = "Pechuga apanada, mayonesa especial", precio = 14000, imagen_url = "https://images.unsplash.com/photo-1606755962773-d324e0a13086?w=300", disponible = true, minutos_preparacion = 14, isActive = 1, categoriaId = Guid.Parse(cat1Id) },
                new Producto { id_producto = Guid.Parse("e1b2c3d4-6004-4000-8000-000000000014"), nombre_producto = "Veggie", descripcion = "Hamburguesa de garbanzo vegana", precio = 13000, imagen_url = "https://images.unsplash.com/photo-1520072959219-c595dc870360?w=300", disponible = true, minutos_preparacion = 10, isActive = 1, categoriaId = Guid.Parse(cat1Id) },
                new Producto { id_producto = Guid.Parse("e1b2c3d4-6005-4000-8000-000000000015"), nombre_producto = "Gaseosa", descripcion = "350ml fría", precio = 3500, imagen_url = "https://images.unsplash.com/photo-1622483767028-3f66f32aef97?w=300", disponible = true, minutos_preparacion = 1, isActive = 1, categoriaId = Guid.Parse(cat2Id) },
                new Producto { id_producto = Guid.Parse("e1b2c3d4-6006-4000-8000-000000000016"), nombre_producto = "Limonada", descripcion = "Limón, agua, azúcar, hielo", precio = 4500, imagen_url = "https://images.unsplash.com/photo-1621263764928-df1444c5e859?w=300", disponible = true, minutos_preparacion = 3, isActive = 1, categoriaId = Guid.Parse(cat2Id) },
                new Producto { id_producto = Guid.Parse("e1b2c3d4-6007-4000-8000-000000000017"), nombre_producto = "Margarita", descripcion = "Salsa, mozzarella y albahaca", precio = 18000, imagen_url = "https://images.unsplash.com/photo-1574071318508-1cdbab80d002?w=300", disponible = true, minutos_preparacion = 15, isActive = 1, categoriaId = Guid.Parse(cat3Id) },
                new Producto { id_producto = Guid.Parse("e1b2c3d4-6008-4000-8000-000000000018"), nombre_producto = "Pepperoni", descripcion = "Salsa, pepperoni y mozzarella", precio = 22000, imagen_url = "https://images.unsplash.com/photo-1628840042765-356cda07504e?w=300", disponible = true, minutos_preparacion = 18, isActive = 1, categoriaId = Guid.Parse(cat3Id) },
                new Producto { id_producto = Guid.Parse("e1b2c3d4-6009-4000-8000-000000000019"), nombre_producto = "4 Quesos", descripcion = "Mozzarella, cheddar, azul, parm", precio = 25000, imagen_url = "https://images.unsplash.com/photo-1513104890138-7c749659a591?w=300", disponible = true, minutos_preparacion = 20, isActive = 1, categoriaId = Guid.Parse(cat3Id) },
                new Producto { id_producto = Guid.Parse("e1b2c3d4-6010-4000-8000-000000000020"), nombre_producto = "Hawaiana", descripcion = "Piña, jamón, mozzarella", precio = 21000, imagen_url = "https://images.unsplash.com/photo-1565299624946-b28f40a0ae38?w=300", disponible = false, minutos_preparacion = 18, isActive = 1, categoriaId = Guid.Parse(cat3Id) },
                new Producto { id_producto = Guid.Parse("e1b2c3d4-6011-4000-8000-000000000021"), nombre_producto = "Tiramisú", descripcion = "Porción individual artesanal", precio = 8000, imagen_url = "https://images.unsplash.com/photo-1571877227200-a0d98ea607e9?w=300", disponible = true, minutos_preparacion = 2, isActive = 1, categoriaId = Guid.Parse(cat4Id) },
                new Producto { id_producto = Guid.Parse("e1b2c3d4-6012-4000-8000-000000000022"), nombre_producto = "Brownie", descripcion = "Brownie de chocolate con helado", precio = 7000, imagen_url = "https://images.unsplash.com/photo-1606313564200-e75d5e30476c?w=300", disponible = true, minutos_preparacion = 2, isActive = 1, categoriaId = Guid.Parse(cat4Id) }
            );
            //FK CASCADE FIX
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