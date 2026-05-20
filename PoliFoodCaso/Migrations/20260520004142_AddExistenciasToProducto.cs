using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoliFoodCaso.Migrations
{
    /// <inheritdoc />
    public partial class AddExistenciasToProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "existencias",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "id_producto",
                keyValue: new Guid("e1b2c3d4-6001-4000-8000-000000000011"),
                column: "existencias",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "id_producto",
                keyValue: new Guid("e1b2c3d4-6002-4000-8000-000000000012"),
                column: "existencias",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "id_producto",
                keyValue: new Guid("e1b2c3d4-6003-4000-8000-000000000013"),
                column: "existencias",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "id_producto",
                keyValue: new Guid("e1b2c3d4-6004-4000-8000-000000000014"),
                column: "existencias",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "id_producto",
                keyValue: new Guid("e1b2c3d4-6005-4000-8000-000000000015"),
                column: "existencias",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "id_producto",
                keyValue: new Guid("e1b2c3d4-6006-4000-8000-000000000016"),
                column: "existencias",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "id_producto",
                keyValue: new Guid("e1b2c3d4-6007-4000-8000-000000000017"),
                column: "existencias",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "id_producto",
                keyValue: new Guid("e1b2c3d4-6008-4000-8000-000000000018"),
                column: "existencias",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "id_producto",
                keyValue: new Guid("e1b2c3d4-6009-4000-8000-000000000019"),
                column: "existencias",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "id_producto",
                keyValue: new Guid("e1b2c3d4-6010-4000-8000-000000000020"),
                column: "existencias",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "id_producto",
                keyValue: new Guid("e1b2c3d4-6011-4000-8000-000000000021"),
                column: "existencias",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "id_producto",
                keyValue: new Guid("e1b2c3d4-6012-4000-8000-000000000022"),
                column: "existencias",
                value: 50);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "existencias",
                table: "Producto");
        }
    }
}
