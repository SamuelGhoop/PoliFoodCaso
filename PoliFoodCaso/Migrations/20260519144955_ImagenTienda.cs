using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoliFoodCaso.Migrations
{
    /// <inheritdoc />
    public partial class ImagenTienda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imagen_url",
                table: "Tienda",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Tienda",
                keyColumn: "id_tienda",
                keyValue: new Guid("c1b2c3d4-4001-4000-8000-000000000005"),
                column: "imagen_url",
                value: "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?auto=format&fit=crop&w=1200&q=80");

            migrationBuilder.UpdateData(
                table: "Tienda",
                keyColumn: "id_tienda",
                keyValue: new Guid("c1b2c3d4-4002-4000-8000-000000000006"),
                column: "imagen_url",
                value: "https://images.unsplash.com/photo-1513104890138-7c749659a591?auto=format&fit=crop&w=1200&q=80");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imagen_url",
                table: "Tienda");
        }
    }
}
