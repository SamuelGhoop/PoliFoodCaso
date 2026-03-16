using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PoliFoodCaso.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tienda",
                columns: table => new
                {
                    id_tienda = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre_tienda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<int>(type: "int", nullable: false),
                    vendorId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tienda", x => x.id_tienda);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    id_categoria = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre_categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<int>(type: "int", nullable: false),
                    tiendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.id_categoria);
                    table.ForeignKey(
                        name: "FK_Categoria_Tienda_tiendaId",
                        column: x => x.tiendaId,
                        principalTable: "Tienda",
                        principalColumn: "id_tienda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    id_orden = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    total = table.Column<double>(type: "float", nullable: false),
                    minutos_estimados = table.Column<int>(type: "int", nullable: false),
                    pago_confirmado = table.Column<bool>(type: "bit", nullable: false),
                    fecha_pago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActive = table.Column<int>(type: "int", nullable: false),
                    studentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tiendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.id_orden);
                    table.ForeignKey(
                        name: "FK_Orden_Tienda_tiendaId",
                        column: x => x.tiendaId,
                        principalTable: "Tienda",
                        principalColumn: "id_tienda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    id_producto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre_producto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precio = table.Column<double>(type: "float", nullable: false),
                    imagen_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    disponible = table.Column<bool>(type: "bit", nullable: false),
                    minutos_preparacion = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<int>(type: "int", nullable: false),
                    categoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.id_producto);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria_categoriaId",
                        column: x => x.categoriaId,
                        principalTable: "Categoria",
                        principalColumn: "id_categoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarritoItem",
                columns: table => new
                {
                    id_carrito_item = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    studentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoItem", x => x.id_carrito_item);
                    table.ForeignKey(
                        name: "FK_CarritoItem_Producto_productoId",
                        column: x => x.productoId,
                        principalTable: "Producto",
                        principalColumn: "id_producto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenItem",
                columns: table => new
                {
                    id_orden_item = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio_unitario = table.Column<double>(type: "float", nullable: false),
                    ordenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    productoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenItem", x => x.id_orden_item);
                    table.ForeignKey(
                        name: "FK_OrdenItem_Orden_ordenId",
                        column: x => x.ordenId,
                        principalTable: "Orden",
                        principalColumn: "id_orden");
                    table.ForeignKey(
                        name: "FK_OrdenItem_Producto_productoId",
                        column: x => x.productoId,
                        principalTable: "Producto",
                        principalColumn: "id_producto");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a1b2c3d4-0001-4000-8000-000000000001", "a1b2c3d4-0001-4000-8000-000000000001", "Admin", "ADMIN" },
                    { "a1b2c3d4-0002-4000-8000-000000000002", "a1b2c3d4-0002-4000-8000-000000000002", "Vendor", "VENDOR" },
                    { "a1b2c3d4-0003-4000-8000-000000000003", "a1b2c3d4-0003-4000-8000-000000000003", "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b1b2c3d4-1001-4000-8000-000000000001", 0, "b1b2c3d4-1001-4000-8000-000000000001", "admin@polifood.edu", true, false, null, "ADMIN@POLIFOOD.EDU", "ADMIN@POLIFOOD.EDU", "AQAAAAIAAYagAAAAEEBWGNitMvuS+1Fw5Yby2cDtcrn7ZRJWCz1ZNei8DQ1UxMRtzahLv77X6zn5eY/3+g==", null, false, "seed-stamp-admin1", false, "admin@polifood.edu" },
                    { "b1b2c3d4-2001-4000-8000-000000000002", 0, "b1b2c3d4-2001-4000-8000-000000000002", "burguer@polifood.edu", true, false, null, "BURGUER@POLIFOOD.EDU", "BURGUER@POLIFOOD.EDU", "AQAAAAIAAYagAAAAEEBWGNitMvuS+1Fw5Yby2cDtcrn7ZRJWCz1ZNei8DQ1UxMRtzahLv77X6zn5eY/3+g==", null, false, "seed-stamp-vendor1", false, "burguer@polifood.edu" },
                    { "b1b2c3d4-2002-4000-8000-000000000003", 0, "b1b2c3d4-2002-4000-8000-000000000003", "pizza@polifood.edu", true, false, null, "PIZZA@POLIFOOD.EDU", "PIZZA@POLIFOOD.EDU", "AQAAAAIAAYagAAAAEEBWGNitMvuS+1Fw5Yby2cDtcrn7ZRJWCz1ZNei8DQ1UxMRtzahLv77X6zn5eY/3+g==", null, false, "seed-stamp-vendor2", false, "pizza@polifood.edu" },
                    { "b1b2c3d4-3001-4000-8000-000000000004", 0, "b1b2c3d4-3001-4000-8000-000000000004", "estudiante@polifood.edu", true, false, null, "ESTUDIANTE@POLIFOOD.EDU", "ESTUDIANTE@POLIFOOD.EDU", "AQAAAAIAAYagAAAAEEBWGNitMvuS+1Fw5Yby2cDtcrn7ZRJWCz1ZNei8DQ1UxMRtzahLv77X6zn5eY/3+g==", null, false, "seed-stamp-student1", false, "estudiante@polifood.edu" }
                });

            migrationBuilder.InsertData(
                table: "Tienda",
                columns: new[] { "id_tienda", "isActive", "nombre_tienda", "vendorId" },
                values: new object[,]
                {
                    { new Guid("c1b2c3d4-4001-4000-8000-000000000005"), 1, "Burguer Campus", "b1b2c3d4-2001-4000-8000-000000000002" },
                    { new Guid("c1b2c3d4-4002-4000-8000-000000000006"), 1, "Pizza Poli", "b1b2c3d4-2002-4000-8000-000000000003" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a1b2c3d4-0001-4000-8000-000000000001", "b1b2c3d4-1001-4000-8000-000000000001" },
                    { "a1b2c3d4-0002-4000-8000-000000000002", "b1b2c3d4-2001-4000-8000-000000000002" },
                    { "a1b2c3d4-0002-4000-8000-000000000002", "b1b2c3d4-2002-4000-8000-000000000003" },
                    { "a1b2c3d4-0003-4000-8000-000000000003", "b1b2c3d4-3001-4000-8000-000000000004" }
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "id_categoria", "isActive", "nombre_categoria", "tiendaId" },
                values: new object[,]
                {
                    { new Guid("d1b2c3d4-5001-4000-8000-000000000007"), 1, "Hamburguesas", new Guid("c1b2c3d4-4001-4000-8000-000000000005") },
                    { new Guid("d1b2c3d4-5002-4000-8000-000000000008"), 1, "Bebidas", new Guid("c1b2c3d4-4001-4000-8000-000000000005") },
                    { new Guid("d1b2c3d4-5003-4000-8000-000000000009"), 1, "Pizzas", new Guid("c1b2c3d4-4002-4000-8000-000000000006") },
                    { new Guid("d1b2c3d4-5004-4000-8000-000000000010"), 1, "Postres", new Guid("c1b2c3d4-4002-4000-8000-000000000006") }
                });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "id_producto", "categoriaId", "descripcion", "disponible", "imagen_url", "isActive", "minutos_preparacion", "nombre_producto", "precio" },
                values: new object[,]
                {
                    { new Guid("e1b2c3d4-6001-4000-8000-000000000011"), new Guid("d1b2c3d4-5001-4000-8000-000000000007"), "Carne 150g, lechuga, tomate, queso", true, "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?w=300", 1, 10, "Clásica", 12500.0 },
                    { new Guid("e1b2c3d4-6002-4000-8000-000000000012"), new Guid("d1b2c3d4-5001-4000-8000-000000000007"), "Doble carne, doble queso cheddar", true, "https://images.unsplash.com/photo-1553979459-d2229ba7433b?w=300", 1, 12, "Doble Cheddar", 16500.0 },
                    { new Guid("e1b2c3d4-6003-4000-8000-000000000013"), new Guid("d1b2c3d4-5001-4000-8000-000000000007"), "Pechuga apanada, mayonesa especial", true, "https://images.unsplash.com/photo-1606755962773-d324e0a13086?w=300", 1, 14, "Pollo Crispy", 14000.0 },
                    { new Guid("e1b2c3d4-6004-4000-8000-000000000014"), new Guid("d1b2c3d4-5001-4000-8000-000000000007"), "Hamburguesa de garbanzo vegana", true, "https://images.unsplash.com/photo-1520072959219-c595dc870360?w=300", 1, 10, "Veggie", 13000.0 },
                    { new Guid("e1b2c3d4-6005-4000-8000-000000000015"), new Guid("d1b2c3d4-5002-4000-8000-000000000008"), "350ml fría", true, "https://images.unsplash.com/photo-1622483767028-3f66f32aef97?w=300", 1, 1, "Gaseosa", 3500.0 },
                    { new Guid("e1b2c3d4-6006-4000-8000-000000000016"), new Guid("d1b2c3d4-5002-4000-8000-000000000008"), "Limón, agua, azúcar, hielo", true, "https://images.unsplash.com/photo-1621263764928-df1444c5e859?w=300", 1, 3, "Limonada", 4500.0 },
                    { new Guid("e1b2c3d4-6007-4000-8000-000000000017"), new Guid("d1b2c3d4-5003-4000-8000-000000000009"), "Salsa, mozzarella y albahaca", true, "https://images.unsplash.com/photo-1574071318508-1cdbab80d002?w=300", 1, 15, "Margarita", 18000.0 },
                    { new Guid("e1b2c3d4-6008-4000-8000-000000000018"), new Guid("d1b2c3d4-5003-4000-8000-000000000009"), "Salsa, pepperoni y mozzarella", true, "https://images.unsplash.com/photo-1628840042765-356cda07504e?w=300", 1, 18, "Pepperoni", 22000.0 },
                    { new Guid("e1b2c3d4-6009-4000-8000-000000000019"), new Guid("d1b2c3d4-5003-4000-8000-000000000009"), "Mozzarella, cheddar, azul, parm", true, "https://images.unsplash.com/photo-1513104890138-7c749659a591?w=300", 1, 20, "4 Quesos", 25000.0 },
                    { new Guid("e1b2c3d4-6010-4000-8000-000000000020"), new Guid("d1b2c3d4-5003-4000-8000-000000000009"), "Piña, jamón, mozzarella", false, "https://images.unsplash.com/photo-1565299624946-b28f40a0ae38?w=300", 1, 18, "Hawaiana", 21000.0 },
                    { new Guid("e1b2c3d4-6011-4000-8000-000000000021"), new Guid("d1b2c3d4-5004-4000-8000-000000000010"), "Porción individual artesanal", true, "https://images.unsplash.com/photo-1571877227200-a0d98ea607e9?w=300", 1, 2, "Tiramisú", 8000.0 },
                    { new Guid("e1b2c3d4-6012-4000-8000-000000000022"), new Guid("d1b2c3d4-5004-4000-8000-000000000010"), "Brownie de chocolate con helado", true, "https://images.unsplash.com/photo-1606313564200-e75d5e30476c?w=300", 1, 2, "Brownie", 7000.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoItem_productoId",
                table: "CarritoItem",
                column: "productoId");

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_tiendaId",
                table: "Categoria",
                column: "tiendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_tiendaId",
                table: "Orden",
                column: "tiendaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenItem_ordenId",
                table: "OrdenItem",
                column: "ordenId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenItem_productoId",
                table: "OrdenItem",
                column: "productoId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_categoriaId",
                table: "Producto",
                column: "categoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CarritoItem");

            migrationBuilder.DropTable(
                name: "OrdenItem");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Tienda");
        }
    }
}
