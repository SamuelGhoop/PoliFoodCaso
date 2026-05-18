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
            //ÓRDENES (20) - distribuidas en las 2 tiendas, con distintos estados
            // Fecha base estática para que el seed sea determinista (EF Core requiere valores fijos)
            DateTime baseFecha = new DateTime(2026, 5, 2, 14, 0, 0, DateTimeKind.Utc);

            // Productos por id (referencia rápida)
            string prodClasica = "e1b2c3d4-6001-4000-8000-000000000011";
            string prodDoble = "e1b2c3d4-6002-4000-8000-000000000012";
            string prodPollo = "e1b2c3d4-6003-4000-8000-000000000013";
            string prodVeggie = "e1b2c3d4-6004-4000-8000-000000000014";
            string prodGaseosa = "e1b2c3d4-6005-4000-8000-000000000015";
            string prodLimonada = "e1b2c3d4-6006-4000-8000-000000000016";
            string prodMargarita = "e1b2c3d4-6007-4000-8000-000000000017";
            string prodPepperoni = "e1b2c3d4-6008-4000-8000-000000000018";
            string prod4Quesos = "e1b2c3d4-6009-4000-8000-000000000019";
            string prodTiramisu = "e1b2c3d4-6011-4000-8000-000000000021";
            string prodBrownie = "e1b2c3d4-6012-4000-8000-000000000022";

            builder.Entity<Orden>().HasData(
                // Burguer Campus (tienda1) - 10 órdenes
                new Orden { id_orden = Guid.Parse("f1b2c3d4-7001-4000-8000-000000000023"), estado = EstadoOrden.Recibida, total = 19500, minutos_estimados = 12, pago_confirmado = true, fecha_pago = baseFecha.AddMinutes(-29).ToString("o"), fecha_creacion = baseFecha.AddMinutes(-30), isActive = 1, studentId = student1Id, tiendaId = Guid.Parse(tienda1Id) },
                new Orden { id_orden = Guid.Parse("f1b2c3d4-7002-4000-8000-000000000024"), estado = EstadoOrden.Recibida, total = 18500, minutos_estimados = 17, pago_confirmado = true, fecha_pago = baseFecha.AddMinutes(-59).ToString("o"), fecha_creacion = baseFecha.AddMinutes(-60), isActive = 1, studentId = student1Id, tiendaId = Guid.Parse(tienda1Id) },
                new Orden { id_orden = Guid.Parse("f1b2c3d4-7003-4000-8000-000000000025"), estado = EstadoOrden.Preparando, total = 20000, minutos_estimados = 13, pago_confirmado = true, fecha_pago = baseFecha.AddMinutes(-119).ToString("o"), fecha_creacion = baseFecha.AddMinutes(-120), isActive = 1, studentId = student1Id, tiendaId = Guid.Parse(tienda1Id) },
                new Orden { id_orden = Guid.Parse("f1b2c3d4-7004-4000-8000-000000000026"), estado = EstadoOrden.Preparando, total = 35000, minutos_estimados = 26, pago_confirmado = true, fecha_pago = baseFecha.AddMinutes(-179).ToString("o"), fecha_creacion = baseFecha.AddMinutes(-180), isActive = 1, studentId = student1Id, tiendaId = Guid.Parse(tienda1Id) },
                new Orden { id_orden = Guid.Parse("f1b2c3d4-7005-4000-8000-000000000027"), estado = EstadoOrden.Lista, total = 32000, minutos_estimados = 22, pago_confirmado = true, fecha_pago = baseFecha.AddMinutes(-299).ToString("o"), fecha_creacion = baseFecha.AddMinutes(-300), isActive = 1, studentId = student1Id, tiendaId = Guid.Parse(tienda1Id) },
                new Orden { id_orden = Guid.Parse("f1b2c3d4-7006-4000-8000-000000000028"), estado = EstadoOrden.Lista, total = 18500, minutos_estimados = 17, pago_confirmado = true, fecha_pago = baseFecha.AddMinutes(-419).ToString("o"), fecha_creacion = baseFecha.AddMinutes(-420), isActive = 1, studentId = student1Id, tiendaId = Guid.Parse(tienda1Id) },
                new Orden { id_orden = Guid.Parse("f1b2c3d4-7007-4000-8000-000000000029"), estado = EstadoOrden.Entregada, total = 36500, minutos_estimados = 25, pago_confirmado = true, fecha_pago = baseFecha.AddMinutes(-719).ToString("o"), fecha_creacion = baseFecha.AddMinutes(-720), isActive = 1, studentId = student1Id, tiendaId = Guid.Parse(tienda1Id) },
                new Orden { id_orden = Guid.Parse("f1b2c3d4-7008-4000-8000-000000000030"), estado = EstadoOrden.Entregada, total = 17500, minutos_estimados = 13, pago_confirmado = true, fecha_pago = baseFecha.AddMinutes(-1079).ToString("o"), fecha_creacion = baseFecha.AddMinutes(-1080), isActive = 1, studentId = student1Id, tiendaId = Guid.Parse(tienda1Id) },
                new Orden { id_orden = Guid.Parse("f1b2c3d4-7009-4000-8000-000000000031"), estado = EstadoOrden.Entregada, total = 48000, minutos_estimados = 33, pago_confirmado = true, fecha_pago = baseFecha.AddMinutes(-1439).ToString("o"), fecha_creacion = baseFecha.AddMinutes(-1440), isActive = 1, studentId = student1Id, tiendaId = Guid.Parse(tienda1Id) },
                new Orden { id_orden = Guid.Parse("f1b2c3d4-7010-4000-8000-000000000032"), estado = EstadoOrden.Entregada, total = 37000, minutos_estimados = 34, pago_confirmado = true, fecha_pago = baseFecha.AddMinutes(-2159).ToString("o"), fecha_creacion = baseFecha.AddMinutes(-2160), isActive = 1, studentId = student1Id, tiendaId = Guid.Parse(tienda1Id) },
                // Pizza Poli (tienda2) - 10 órdenes
                new Orden { id_orden = Guid.Parse("f1b2c3d4-7011-4000-8000-000000000033"), estado = EstadoOrden.Recibida, total = 25000, minutos_estimados = 17, pago_confirmado = true, fecha_pago = baseFecha.AddMinutes(-14).ToString("o"), fecha_creacion = baseFecha.AddMinutes(-15), isActive = 1, studentId = student1Id, tiendaId = Guid.Parse(tienda2Id) },
                new Orden { id_orden = Guid.Parse("f1b2c3d4-7012-4000-8000-000000000034"), estado = EstadoOrden.Recibida, total = 30000, minutos_estimados = 20, pago_confirmado = true, fecha_pago = baseFecha.AddMinutes(-44).ToString("o"), fecha_creacion = baseFecha.AddMinutes(-45), isActive = 1, studentId = student1Id, tiendaId = Guid.Parse(tienda2Id) },
                new Orden { id_orden = Guid.Parse("f1b2c3d4-7013-4000-8000-000000000035"), estado = EstadoOrden.Preparando, total = 39000, minutos_estimados = 24, pago_confirmado = true, fecha_pago = baseFecha.AddMinutes(-89).ToString("o"), fecha_creacion = baseFecha.AddMinutes(-90), isActive = 1, studentId = student1Id, tiendaId = Guid.Parse(tienda2Id) },
                new Orden { id_orden = Guid.Parse("f1b2c3d4-7014-4000-8000-000000000036"), estado = EstadoOrden.Preparando, total = 44000, minutos_estimados = 32, pago_confirmado = true, fecha_pago = baseFecha.AddMinutes(-149).ToString("o"), fecha_creacion = baseFecha.AddMinutes(-150), isActive = 1, studentId = student1Id, tiendaId = Guid.Parse(tienda2Id) },
                new Orden { id_orden = Guid.Parse("f1b2c3d4-7015-4000-8000-000000000037"), estado = EstadoOrden.Preparando, total = 38000, minutos_estimados = 22, pago_confirmado = true, fecha_pago = baseFecha.AddMinutes(-239).ToString("o"), fecha_creacion = baseFecha.AddMinutes(-240), isActive = 1, studentId = student1Id, tiendaId = Guid.Parse(tienda2Id) },
                new Orden { id_orden = Guid.Parse("f1b2c3d4-7016-4000-8000-000000000038"), estado = EstadoOrden.Lista, total = 32000, minutos_estimados = 22, pago_confirmado = true, fecha_pago = baseFecha.AddMinutes(-359).ToString("o"), fecha_creacion = baseFecha.AddMinutes(-360), isActive = 1, studentId = student1Id, tiendaId = Guid.Parse(tienda2Id) },
                new Orden { id_orden = Guid.Parse("f1b2c3d4-7017-4000-8000-000000000039"), estado = EstadoOrden.Lista, total = 26000, minutos_estimados = 17, pago_confirmado = true, fecha_pago = baseFecha.AddMinutes(-479).ToString("o"), fecha_creacion = baseFecha.AddMinutes(-480), isActive = 1, studentId = student1Id, tiendaId = Guid.Parse(tienda2Id) },
                new Orden { id_orden = Guid.Parse("f1b2c3d4-7018-4000-8000-000000000040"), estado = EstadoOrden.Entregada, total = 51000, minutos_estimados = 38, pago_confirmado = true, fecha_pago = baseFecha.AddMinutes(-839).ToString("o"), fecha_creacion = baseFecha.AddMinutes(-840), isActive = 1, studentId = student1Id, tiendaId = Guid.Parse(tienda2Id) },
                new Orden { id_orden = Guid.Parse("f1b2c3d4-7019-4000-8000-000000000041"), estado = EstadoOrden.Entregada, total = 33000, minutos_estimados = 22, pago_confirmado = true, fecha_pago = baseFecha.AddMinutes(-1199).ToString("o"), fecha_creacion = baseFecha.AddMinutes(-1200), isActive = 1, studentId = student1Id, tiendaId = Guid.Parse(tienda2Id) },
                new Orden { id_orden = Guid.Parse("f1b2c3d4-7020-4000-8000-000000000042"), estado = EstadoOrden.Entregada, total = 25000, minutos_estimados = 17, pago_confirmado = true, fecha_pago = baseFecha.AddMinutes(-1919).ToString("o"), fecha_creacion = baseFecha.AddMinutes(-1920), isActive = 1, studentId = student1Id, tiendaId = Guid.Parse(tienda2Id) }
            );

            //ORDEN ITEMS (40) - 2 items por orden
            builder.Entity<OrdenItem>().HasData(
                // O1: Clásica x1 + Gaseosa x2 = 19500
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8001-4000-8000-000000000043"), cantidad = 1, precio_unitario = 12500, ordenId = Guid.Parse("f1b2c3d4-7001-4000-8000-000000000023"), productoId = Guid.Parse(prodClasica) },
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8002-4000-8000-000000000044"), cantidad = 2, precio_unitario = 3500, ordenId = Guid.Parse("f1b2c3d4-7001-4000-8000-000000000023"), productoId = Guid.Parse(prodGaseosa) },
                // O2: Pollo x1 + Limonada x1 = 18500
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8003-4000-8000-000000000045"), cantidad = 1, precio_unitario = 14000, ordenId = Guid.Parse("f1b2c3d4-7002-4000-8000-000000000024"), productoId = Guid.Parse(prodPollo) },
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8004-4000-8000-000000000046"), cantidad = 1, precio_unitario = 4500, ordenId = Guid.Parse("f1b2c3d4-7002-4000-8000-000000000024"), productoId = Guid.Parse(prodLimonada) },
                // O3: Doble x1 + Gaseosa x1 = 20000
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8005-4000-8000-000000000047"), cantidad = 1, precio_unitario = 16500, ordenId = Guid.Parse("f1b2c3d4-7003-4000-8000-000000000025"), productoId = Guid.Parse(prodDoble) },
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8006-4000-8000-000000000048"), cantidad = 1, precio_unitario = 3500, ordenId = Guid.Parse("f1b2c3d4-7003-4000-8000-000000000025"), productoId = Guid.Parse(prodGaseosa) },
                // O4: Veggie x2 + Limonada x2 = 35000
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8007-4000-8000-000000000049"), cantidad = 2, precio_unitario = 13000, ordenId = Guid.Parse("f1b2c3d4-7004-4000-8000-000000000026"), productoId = Guid.Parse(prodVeggie) },
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8008-4000-8000-000000000050"), cantidad = 2, precio_unitario = 4500, ordenId = Guid.Parse("f1b2c3d4-7004-4000-8000-000000000026"), productoId = Guid.Parse(prodLimonada) },
                // O5: Clásica x2 + Gaseosa x2 = 32000
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8009-4000-8000-000000000051"), cantidad = 2, precio_unitario = 12500, ordenId = Guid.Parse("f1b2c3d4-7005-4000-8000-000000000027"), productoId = Guid.Parse(prodClasica) },
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8010-4000-8000-000000000052"), cantidad = 2, precio_unitario = 3500, ordenId = Guid.Parse("f1b2c3d4-7005-4000-8000-000000000027"), productoId = Guid.Parse(prodGaseosa) },
                // O6: Pollo x1 + Limonada x1 = 18500
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8011-4000-8000-000000000053"), cantidad = 1, precio_unitario = 14000, ordenId = Guid.Parse("f1b2c3d4-7006-4000-8000-000000000028"), productoId = Guid.Parse(prodPollo) },
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8012-4000-8000-000000000054"), cantidad = 1, precio_unitario = 4500, ordenId = Guid.Parse("f1b2c3d4-7006-4000-8000-000000000028"), productoId = Guid.Parse(prodLimonada) },
                // O7: Doble x2 + Gaseosa x1 = 36500
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8013-4000-8000-000000000055"), cantidad = 2, precio_unitario = 16500, ordenId = Guid.Parse("f1b2c3d4-7007-4000-8000-000000000029"), productoId = Guid.Parse(prodDoble) },
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8014-4000-8000-000000000056"), cantidad = 1, precio_unitario = 3500, ordenId = Guid.Parse("f1b2c3d4-7007-4000-8000-000000000029"), productoId = Guid.Parse(prodGaseosa) },
                // O8: Veggie x1 + Limonada x1 = 17500
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8015-4000-8000-000000000057"), cantidad = 1, precio_unitario = 13000, ordenId = Guid.Parse("f1b2c3d4-7008-4000-8000-000000000030"), productoId = Guid.Parse(prodVeggie) },
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8016-4000-8000-000000000058"), cantidad = 1, precio_unitario = 4500, ordenId = Guid.Parse("f1b2c3d4-7008-4000-8000-000000000030"), productoId = Guid.Parse(prodLimonada) },
                // O9: Clásica x3 + Gaseosa x3 = 48000
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8017-4000-8000-000000000059"), cantidad = 3, precio_unitario = 12500, ordenId = Guid.Parse("f1b2c3d4-7009-4000-8000-000000000031"), productoId = Guid.Parse(prodClasica) },
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8018-4000-8000-000000000060"), cantidad = 3, precio_unitario = 3500, ordenId = Guid.Parse("f1b2c3d4-7009-4000-8000-000000000031"), productoId = Guid.Parse(prodGaseosa) },
                // O10: Pollo x2 + Limonada x2 = 37000
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8019-4000-8000-000000000061"), cantidad = 2, precio_unitario = 14000, ordenId = Guid.Parse("f1b2c3d4-7010-4000-8000-000000000032"), productoId = Guid.Parse(prodPollo) },
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8020-4000-8000-000000000062"), cantidad = 2, precio_unitario = 4500, ordenId = Guid.Parse("f1b2c3d4-7010-4000-8000-000000000032"), productoId = Guid.Parse(prodLimonada) },
                // O11: Margarita x1 + Brownie x1 = 25000
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8021-4000-8000-000000000063"), cantidad = 1, precio_unitario = 18000, ordenId = Guid.Parse("f1b2c3d4-7011-4000-8000-000000000033"), productoId = Guid.Parse(prodMargarita) },
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8022-4000-8000-000000000064"), cantidad = 1, precio_unitario = 7000, ordenId = Guid.Parse("f1b2c3d4-7011-4000-8000-000000000033"), productoId = Guid.Parse(prodBrownie) },
                // O12: Pepperoni x1 + Tiramisú x1 = 30000
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8023-4000-8000-000000000065"), cantidad = 1, precio_unitario = 22000, ordenId = Guid.Parse("f1b2c3d4-7012-4000-8000-000000000034"), productoId = Guid.Parse(prodPepperoni) },
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8024-4000-8000-000000000066"), cantidad = 1, precio_unitario = 8000, ordenId = Guid.Parse("f1b2c3d4-7012-4000-8000-000000000034"), productoId = Guid.Parse(prodTiramisu) },
                // O13: 4 Quesos x1 + Brownie x2 = 39000
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8025-4000-8000-000000000067"), cantidad = 1, precio_unitario = 25000, ordenId = Guid.Parse("f1b2c3d4-7013-4000-8000-000000000035"), productoId = Guid.Parse(prod4Quesos) },
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8026-4000-8000-000000000068"), cantidad = 2, precio_unitario = 7000, ordenId = Guid.Parse("f1b2c3d4-7013-4000-8000-000000000035"), productoId = Guid.Parse(prodBrownie) },
                // O14: Margarita x2 + Tiramisú x1 = 44000
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8027-4000-8000-000000000069"), cantidad = 2, precio_unitario = 18000, ordenId = Guid.Parse("f1b2c3d4-7014-4000-8000-000000000036"), productoId = Guid.Parse(prodMargarita) },
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8028-4000-8000-000000000070"), cantidad = 1, precio_unitario = 8000, ordenId = Guid.Parse("f1b2c3d4-7014-4000-8000-000000000036"), productoId = Guid.Parse(prodTiramisu) },
                // O15: Pepperoni x1 + Tiramisú x2 = 38000
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8029-4000-8000-000000000071"), cantidad = 1, precio_unitario = 22000, ordenId = Guid.Parse("f1b2c3d4-7015-4000-8000-000000000037"), productoId = Guid.Parse(prodPepperoni) },
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8030-4000-8000-000000000072"), cantidad = 2, precio_unitario = 8000, ordenId = Guid.Parse("f1b2c3d4-7015-4000-8000-000000000037"), productoId = Guid.Parse(prodTiramisu) },
                // O16: 4 Quesos x1 + Brownie x1 = 32000
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8031-4000-8000-000000000073"), cantidad = 1, precio_unitario = 25000, ordenId = Guid.Parse("f1b2c3d4-7016-4000-8000-000000000038"), productoId = Guid.Parse(prod4Quesos) },
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8032-4000-8000-000000000074"), cantidad = 1, precio_unitario = 7000, ordenId = Guid.Parse("f1b2c3d4-7016-4000-8000-000000000038"), productoId = Guid.Parse(prodBrownie) },
                // O17: Margarita x1 + Tiramisú x1 = 26000
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8033-4000-8000-000000000075"), cantidad = 1, precio_unitario = 18000, ordenId = Guid.Parse("f1b2c3d4-7017-4000-8000-000000000039"), productoId = Guid.Parse(prodMargarita) },
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8034-4000-8000-000000000076"), cantidad = 1, precio_unitario = 8000, ordenId = Guid.Parse("f1b2c3d4-7017-4000-8000-000000000039"), productoId = Guid.Parse(prodTiramisu) },
                // O18: Pepperoni x2 + Brownie x1 = 51000
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8035-4000-8000-000000000077"), cantidad = 2, precio_unitario = 22000, ordenId = Guid.Parse("f1b2c3d4-7018-4000-8000-000000000040"), productoId = Guid.Parse(prodPepperoni) },
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8036-4000-8000-000000000078"), cantidad = 1, precio_unitario = 7000, ordenId = Guid.Parse("f1b2c3d4-7018-4000-8000-000000000040"), productoId = Guid.Parse(prodBrownie) },
                // O19: 4 Quesos x1 + Tiramisú x1 = 33000
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8037-4000-8000-000000000079"), cantidad = 1, precio_unitario = 25000, ordenId = Guid.Parse("f1b2c3d4-7019-4000-8000-000000000041"), productoId = Guid.Parse(prod4Quesos) },
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8038-4000-8000-000000000080"), cantidad = 1, precio_unitario = 8000, ordenId = Guid.Parse("f1b2c3d4-7019-4000-8000-000000000041"), productoId = Guid.Parse(prodTiramisu) },
                // O20: Margarita x1 + Brownie x1 = 25000
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8039-4000-8000-000000000081"), cantidad = 1, precio_unitario = 18000, ordenId = Guid.Parse("f1b2c3d4-7020-4000-8000-000000000042"), productoId = Guid.Parse(prodMargarita) },
                new OrdenItem { id_orden_item = Guid.Parse("f1b2c3d4-8040-4000-8000-000000000082"), cantidad = 1, precio_unitario = 7000, ordenId = Guid.Parse("f1b2c3d4-7020-4000-8000-000000000042"), productoId = Guid.Parse(prodBrownie) }
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