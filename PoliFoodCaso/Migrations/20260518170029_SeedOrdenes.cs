using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PoliFoodCaso.Migrations
{
    /// <inheritdoc />
    public partial class SeedOrdenes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orden",
                columns: new[] { "id_orden", "estado", "fecha_creacion", "fecha_pago", "isActive", "minutos_estimados", "pago_confirmado", "studentId", "tiendaId", "total" },
                values: new object[,]
                {
                    { new Guid("f1b2c3d4-7001-4000-8000-000000000023"), 0, new DateTime(2026, 5, 2, 13, 30, 0, 0, DateTimeKind.Utc), "2026-05-02T13:31:00.0000000Z", 1, 12, true, "b1b2c3d4-3001-4000-8000-000000000004", new Guid("c1b2c3d4-4001-4000-8000-000000000005"), 19500.0 },
                    { new Guid("f1b2c3d4-7002-4000-8000-000000000024"), 0, new DateTime(2026, 5, 2, 13, 0, 0, 0, DateTimeKind.Utc), "2026-05-02T13:01:00.0000000Z", 1, 17, true, "b1b2c3d4-3001-4000-8000-000000000004", new Guid("c1b2c3d4-4001-4000-8000-000000000005"), 18500.0 },
                    { new Guid("f1b2c3d4-7003-4000-8000-000000000025"), 1, new DateTime(2026, 5, 2, 12, 0, 0, 0, DateTimeKind.Utc), "2026-05-02T12:01:00.0000000Z", 1, 13, true, "b1b2c3d4-3001-4000-8000-000000000004", new Guid("c1b2c3d4-4001-4000-8000-000000000005"), 20000.0 },
                    { new Guid("f1b2c3d4-7004-4000-8000-000000000026"), 1, new DateTime(2026, 5, 2, 11, 0, 0, 0, DateTimeKind.Utc), "2026-05-02T11:01:00.0000000Z", 1, 26, true, "b1b2c3d4-3001-4000-8000-000000000004", new Guid("c1b2c3d4-4001-4000-8000-000000000005"), 35000.0 },
                    { new Guid("f1b2c3d4-7005-4000-8000-000000000027"), 2, new DateTime(2026, 5, 2, 9, 0, 0, 0, DateTimeKind.Utc), "2026-05-02T09:01:00.0000000Z", 1, 22, true, "b1b2c3d4-3001-4000-8000-000000000004", new Guid("c1b2c3d4-4001-4000-8000-000000000005"), 32000.0 },
                    { new Guid("f1b2c3d4-7006-4000-8000-000000000028"), 2, new DateTime(2026, 5, 2, 7, 0, 0, 0, DateTimeKind.Utc), "2026-05-02T07:01:00.0000000Z", 1, 17, true, "b1b2c3d4-3001-4000-8000-000000000004", new Guid("c1b2c3d4-4001-4000-8000-000000000005"), 18500.0 },
                    { new Guid("f1b2c3d4-7007-4000-8000-000000000029"), 3, new DateTime(2026, 5, 2, 2, 0, 0, 0, DateTimeKind.Utc), "2026-05-02T02:01:00.0000000Z", 1, 25, true, "b1b2c3d4-3001-4000-8000-000000000004", new Guid("c1b2c3d4-4001-4000-8000-000000000005"), 36500.0 },
                    { new Guid("f1b2c3d4-7008-4000-8000-000000000030"), 3, new DateTime(2026, 5, 1, 20, 0, 0, 0, DateTimeKind.Utc), "2026-05-01T20:01:00.0000000Z", 1, 13, true, "b1b2c3d4-3001-4000-8000-000000000004", new Guid("c1b2c3d4-4001-4000-8000-000000000005"), 17500.0 },
                    { new Guid("f1b2c3d4-7009-4000-8000-000000000031"), 3, new DateTime(2026, 5, 1, 14, 0, 0, 0, DateTimeKind.Utc), "2026-05-01T14:01:00.0000000Z", 1, 33, true, "b1b2c3d4-3001-4000-8000-000000000004", new Guid("c1b2c3d4-4001-4000-8000-000000000005"), 48000.0 },
                    { new Guid("f1b2c3d4-7010-4000-8000-000000000032"), 3, new DateTime(2026, 5, 1, 2, 0, 0, 0, DateTimeKind.Utc), "2026-05-01T02:01:00.0000000Z", 1, 34, true, "b1b2c3d4-3001-4000-8000-000000000004", new Guid("c1b2c3d4-4001-4000-8000-000000000005"), 37000.0 },
                    { new Guid("f1b2c3d4-7011-4000-8000-000000000033"), 0, new DateTime(2026, 5, 2, 13, 45, 0, 0, DateTimeKind.Utc), "2026-05-02T13:46:00.0000000Z", 1, 17, true, "b1b2c3d4-3001-4000-8000-000000000004", new Guid("c1b2c3d4-4002-4000-8000-000000000006"), 25000.0 },
                    { new Guid("f1b2c3d4-7012-4000-8000-000000000034"), 0, new DateTime(2026, 5, 2, 13, 15, 0, 0, DateTimeKind.Utc), "2026-05-02T13:16:00.0000000Z", 1, 20, true, "b1b2c3d4-3001-4000-8000-000000000004", new Guid("c1b2c3d4-4002-4000-8000-000000000006"), 30000.0 },
                    { new Guid("f1b2c3d4-7013-4000-8000-000000000035"), 1, new DateTime(2026, 5, 2, 12, 30, 0, 0, DateTimeKind.Utc), "2026-05-02T12:31:00.0000000Z", 1, 24, true, "b1b2c3d4-3001-4000-8000-000000000004", new Guid("c1b2c3d4-4002-4000-8000-000000000006"), 39000.0 },
                    { new Guid("f1b2c3d4-7014-4000-8000-000000000036"), 1, new DateTime(2026, 5, 2, 11, 30, 0, 0, DateTimeKind.Utc), "2026-05-02T11:31:00.0000000Z", 1, 32, true, "b1b2c3d4-3001-4000-8000-000000000004", new Guid("c1b2c3d4-4002-4000-8000-000000000006"), 44000.0 },
                    { new Guid("f1b2c3d4-7015-4000-8000-000000000037"), 1, new DateTime(2026, 5, 2, 10, 0, 0, 0, DateTimeKind.Utc), "2026-05-02T10:01:00.0000000Z", 1, 22, true, "b1b2c3d4-3001-4000-8000-000000000004", new Guid("c1b2c3d4-4002-4000-8000-000000000006"), 38000.0 },
                    { new Guid("f1b2c3d4-7016-4000-8000-000000000038"), 2, new DateTime(2026, 5, 2, 8, 0, 0, 0, DateTimeKind.Utc), "2026-05-02T08:01:00.0000000Z", 1, 22, true, "b1b2c3d4-3001-4000-8000-000000000004", new Guid("c1b2c3d4-4002-4000-8000-000000000006"), 32000.0 },
                    { new Guid("f1b2c3d4-7017-4000-8000-000000000039"), 2, new DateTime(2026, 5, 2, 6, 0, 0, 0, DateTimeKind.Utc), "2026-05-02T06:01:00.0000000Z", 1, 17, true, "b1b2c3d4-3001-4000-8000-000000000004", new Guid("c1b2c3d4-4002-4000-8000-000000000006"), 26000.0 },
                    { new Guid("f1b2c3d4-7018-4000-8000-000000000040"), 3, new DateTime(2026, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), "2026-05-02T00:01:00.0000000Z", 1, 38, true, "b1b2c3d4-3001-4000-8000-000000000004", new Guid("c1b2c3d4-4002-4000-8000-000000000006"), 51000.0 },
                    { new Guid("f1b2c3d4-7019-4000-8000-000000000041"), 3, new DateTime(2026, 5, 1, 18, 0, 0, 0, DateTimeKind.Utc), "2026-05-01T18:01:00.0000000Z", 1, 22, true, "b1b2c3d4-3001-4000-8000-000000000004", new Guid("c1b2c3d4-4002-4000-8000-000000000006"), 33000.0 },
                    { new Guid("f1b2c3d4-7020-4000-8000-000000000042"), 3, new DateTime(2026, 5, 1, 6, 0, 0, 0, DateTimeKind.Utc), "2026-05-01T06:01:00.0000000Z", 1, 17, true, "b1b2c3d4-3001-4000-8000-000000000004", new Guid("c1b2c3d4-4002-4000-8000-000000000006"), 25000.0 }
                });

            migrationBuilder.InsertData(
                table: "OrdenItem",
                columns: new[] { "id_orden_item", "cantidad", "ordenId", "precio_unitario", "productoId" },
                values: new object[,]
                {
                    { new Guid("f1b2c3d4-8001-4000-8000-000000000043"), 1, new Guid("f1b2c3d4-7001-4000-8000-000000000023"), 12500.0, new Guid("e1b2c3d4-6001-4000-8000-000000000011") },
                    { new Guid("f1b2c3d4-8002-4000-8000-000000000044"), 2, new Guid("f1b2c3d4-7001-4000-8000-000000000023"), 3500.0, new Guid("e1b2c3d4-6005-4000-8000-000000000015") },
                    { new Guid("f1b2c3d4-8003-4000-8000-000000000045"), 1, new Guid("f1b2c3d4-7002-4000-8000-000000000024"), 14000.0, new Guid("e1b2c3d4-6003-4000-8000-000000000013") },
                    { new Guid("f1b2c3d4-8004-4000-8000-000000000046"), 1, new Guid("f1b2c3d4-7002-4000-8000-000000000024"), 4500.0, new Guid("e1b2c3d4-6006-4000-8000-000000000016") },
                    { new Guid("f1b2c3d4-8005-4000-8000-000000000047"), 1, new Guid("f1b2c3d4-7003-4000-8000-000000000025"), 16500.0, new Guid("e1b2c3d4-6002-4000-8000-000000000012") },
                    { new Guid("f1b2c3d4-8006-4000-8000-000000000048"), 1, new Guid("f1b2c3d4-7003-4000-8000-000000000025"), 3500.0, new Guid("e1b2c3d4-6005-4000-8000-000000000015") },
                    { new Guid("f1b2c3d4-8007-4000-8000-000000000049"), 2, new Guid("f1b2c3d4-7004-4000-8000-000000000026"), 13000.0, new Guid("e1b2c3d4-6004-4000-8000-000000000014") },
                    { new Guid("f1b2c3d4-8008-4000-8000-000000000050"), 2, new Guid("f1b2c3d4-7004-4000-8000-000000000026"), 4500.0, new Guid("e1b2c3d4-6006-4000-8000-000000000016") },
                    { new Guid("f1b2c3d4-8009-4000-8000-000000000051"), 2, new Guid("f1b2c3d4-7005-4000-8000-000000000027"), 12500.0, new Guid("e1b2c3d4-6001-4000-8000-000000000011") },
                    { new Guid("f1b2c3d4-8010-4000-8000-000000000052"), 2, new Guid("f1b2c3d4-7005-4000-8000-000000000027"), 3500.0, new Guid("e1b2c3d4-6005-4000-8000-000000000015") },
                    { new Guid("f1b2c3d4-8011-4000-8000-000000000053"), 1, new Guid("f1b2c3d4-7006-4000-8000-000000000028"), 14000.0, new Guid("e1b2c3d4-6003-4000-8000-000000000013") },
                    { new Guid("f1b2c3d4-8012-4000-8000-000000000054"), 1, new Guid("f1b2c3d4-7006-4000-8000-000000000028"), 4500.0, new Guid("e1b2c3d4-6006-4000-8000-000000000016") },
                    { new Guid("f1b2c3d4-8013-4000-8000-000000000055"), 2, new Guid("f1b2c3d4-7007-4000-8000-000000000029"), 16500.0, new Guid("e1b2c3d4-6002-4000-8000-000000000012") },
                    { new Guid("f1b2c3d4-8014-4000-8000-000000000056"), 1, new Guid("f1b2c3d4-7007-4000-8000-000000000029"), 3500.0, new Guid("e1b2c3d4-6005-4000-8000-000000000015") },
                    { new Guid("f1b2c3d4-8015-4000-8000-000000000057"), 1, new Guid("f1b2c3d4-7008-4000-8000-000000000030"), 13000.0, new Guid("e1b2c3d4-6004-4000-8000-000000000014") },
                    { new Guid("f1b2c3d4-8016-4000-8000-000000000058"), 1, new Guid("f1b2c3d4-7008-4000-8000-000000000030"), 4500.0, new Guid("e1b2c3d4-6006-4000-8000-000000000016") },
                    { new Guid("f1b2c3d4-8017-4000-8000-000000000059"), 3, new Guid("f1b2c3d4-7009-4000-8000-000000000031"), 12500.0, new Guid("e1b2c3d4-6001-4000-8000-000000000011") },
                    { new Guid("f1b2c3d4-8018-4000-8000-000000000060"), 3, new Guid("f1b2c3d4-7009-4000-8000-000000000031"), 3500.0, new Guid("e1b2c3d4-6005-4000-8000-000000000015") },
                    { new Guid("f1b2c3d4-8019-4000-8000-000000000061"), 2, new Guid("f1b2c3d4-7010-4000-8000-000000000032"), 14000.0, new Guid("e1b2c3d4-6003-4000-8000-000000000013") },
                    { new Guid("f1b2c3d4-8020-4000-8000-000000000062"), 2, new Guid("f1b2c3d4-7010-4000-8000-000000000032"), 4500.0, new Guid("e1b2c3d4-6006-4000-8000-000000000016") },
                    { new Guid("f1b2c3d4-8021-4000-8000-000000000063"), 1, new Guid("f1b2c3d4-7011-4000-8000-000000000033"), 18000.0, new Guid("e1b2c3d4-6007-4000-8000-000000000017") },
                    { new Guid("f1b2c3d4-8022-4000-8000-000000000064"), 1, new Guid("f1b2c3d4-7011-4000-8000-000000000033"), 7000.0, new Guid("e1b2c3d4-6012-4000-8000-000000000022") },
                    { new Guid("f1b2c3d4-8023-4000-8000-000000000065"), 1, new Guid("f1b2c3d4-7012-4000-8000-000000000034"), 22000.0, new Guid("e1b2c3d4-6008-4000-8000-000000000018") },
                    { new Guid("f1b2c3d4-8024-4000-8000-000000000066"), 1, new Guid("f1b2c3d4-7012-4000-8000-000000000034"), 8000.0, new Guid("e1b2c3d4-6011-4000-8000-000000000021") },
                    { new Guid("f1b2c3d4-8025-4000-8000-000000000067"), 1, new Guid("f1b2c3d4-7013-4000-8000-000000000035"), 25000.0, new Guid("e1b2c3d4-6009-4000-8000-000000000019") },
                    { new Guid("f1b2c3d4-8026-4000-8000-000000000068"), 2, new Guid("f1b2c3d4-7013-4000-8000-000000000035"), 7000.0, new Guid("e1b2c3d4-6012-4000-8000-000000000022") },
                    { new Guid("f1b2c3d4-8027-4000-8000-000000000069"), 2, new Guid("f1b2c3d4-7014-4000-8000-000000000036"), 18000.0, new Guid("e1b2c3d4-6007-4000-8000-000000000017") },
                    { new Guid("f1b2c3d4-8028-4000-8000-000000000070"), 1, new Guid("f1b2c3d4-7014-4000-8000-000000000036"), 8000.0, new Guid("e1b2c3d4-6011-4000-8000-000000000021") },
                    { new Guid("f1b2c3d4-8029-4000-8000-000000000071"), 1, new Guid("f1b2c3d4-7015-4000-8000-000000000037"), 22000.0, new Guid("e1b2c3d4-6008-4000-8000-000000000018") },
                    { new Guid("f1b2c3d4-8030-4000-8000-000000000072"), 2, new Guid("f1b2c3d4-7015-4000-8000-000000000037"), 8000.0, new Guid("e1b2c3d4-6011-4000-8000-000000000021") },
                    { new Guid("f1b2c3d4-8031-4000-8000-000000000073"), 1, new Guid("f1b2c3d4-7016-4000-8000-000000000038"), 25000.0, new Guid("e1b2c3d4-6009-4000-8000-000000000019") },
                    { new Guid("f1b2c3d4-8032-4000-8000-000000000074"), 1, new Guid("f1b2c3d4-7016-4000-8000-000000000038"), 7000.0, new Guid("e1b2c3d4-6012-4000-8000-000000000022") },
                    { new Guid("f1b2c3d4-8033-4000-8000-000000000075"), 1, new Guid("f1b2c3d4-7017-4000-8000-000000000039"), 18000.0, new Guid("e1b2c3d4-6007-4000-8000-000000000017") },
                    { new Guid("f1b2c3d4-8034-4000-8000-000000000076"), 1, new Guid("f1b2c3d4-7017-4000-8000-000000000039"), 8000.0, new Guid("e1b2c3d4-6011-4000-8000-000000000021") },
                    { new Guid("f1b2c3d4-8035-4000-8000-000000000077"), 2, new Guid("f1b2c3d4-7018-4000-8000-000000000040"), 22000.0, new Guid("e1b2c3d4-6008-4000-8000-000000000018") },
                    { new Guid("f1b2c3d4-8036-4000-8000-000000000078"), 1, new Guid("f1b2c3d4-7018-4000-8000-000000000040"), 7000.0, new Guid("e1b2c3d4-6012-4000-8000-000000000022") },
                    { new Guid("f1b2c3d4-8037-4000-8000-000000000079"), 1, new Guid("f1b2c3d4-7019-4000-8000-000000000041"), 25000.0, new Guid("e1b2c3d4-6009-4000-8000-000000000019") },
                    { new Guid("f1b2c3d4-8038-4000-8000-000000000080"), 1, new Guid("f1b2c3d4-7019-4000-8000-000000000041"), 8000.0, new Guid("e1b2c3d4-6011-4000-8000-000000000021") },
                    { new Guid("f1b2c3d4-8039-4000-8000-000000000081"), 1, new Guid("f1b2c3d4-7020-4000-8000-000000000042"), 18000.0, new Guid("e1b2c3d4-6007-4000-8000-000000000017") },
                    { new Guid("f1b2c3d4-8040-4000-8000-000000000082"), 1, new Guid("f1b2c3d4-7020-4000-8000-000000000042"), 7000.0, new Guid("e1b2c3d4-6012-4000-8000-000000000022") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8001-4000-8000-000000000043"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8002-4000-8000-000000000044"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8003-4000-8000-000000000045"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8004-4000-8000-000000000046"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8005-4000-8000-000000000047"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8006-4000-8000-000000000048"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8007-4000-8000-000000000049"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8008-4000-8000-000000000050"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8009-4000-8000-000000000051"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8010-4000-8000-000000000052"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8011-4000-8000-000000000053"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8012-4000-8000-000000000054"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8013-4000-8000-000000000055"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8014-4000-8000-000000000056"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8015-4000-8000-000000000057"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8016-4000-8000-000000000058"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8017-4000-8000-000000000059"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8018-4000-8000-000000000060"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8019-4000-8000-000000000061"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8020-4000-8000-000000000062"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8021-4000-8000-000000000063"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8022-4000-8000-000000000064"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8023-4000-8000-000000000065"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8024-4000-8000-000000000066"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8025-4000-8000-000000000067"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8026-4000-8000-000000000068"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8027-4000-8000-000000000069"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8028-4000-8000-000000000070"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8029-4000-8000-000000000071"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8030-4000-8000-000000000072"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8031-4000-8000-000000000073"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8032-4000-8000-000000000074"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8033-4000-8000-000000000075"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8034-4000-8000-000000000076"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8035-4000-8000-000000000077"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8036-4000-8000-000000000078"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8037-4000-8000-000000000079"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8038-4000-8000-000000000080"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8039-4000-8000-000000000081"));

            migrationBuilder.DeleteData(
                table: "OrdenItem",
                keyColumn: "id_orden_item",
                keyValue: new Guid("f1b2c3d4-8040-4000-8000-000000000082"));

            migrationBuilder.DeleteData(
                table: "Orden",
                keyColumn: "id_orden",
                keyValue: new Guid("f1b2c3d4-7001-4000-8000-000000000023"));

            migrationBuilder.DeleteData(
                table: "Orden",
                keyColumn: "id_orden",
                keyValue: new Guid("f1b2c3d4-7002-4000-8000-000000000024"));

            migrationBuilder.DeleteData(
                table: "Orden",
                keyColumn: "id_orden",
                keyValue: new Guid("f1b2c3d4-7003-4000-8000-000000000025"));

            migrationBuilder.DeleteData(
                table: "Orden",
                keyColumn: "id_orden",
                keyValue: new Guid("f1b2c3d4-7004-4000-8000-000000000026"));

            migrationBuilder.DeleteData(
                table: "Orden",
                keyColumn: "id_orden",
                keyValue: new Guid("f1b2c3d4-7005-4000-8000-000000000027"));

            migrationBuilder.DeleteData(
                table: "Orden",
                keyColumn: "id_orden",
                keyValue: new Guid("f1b2c3d4-7006-4000-8000-000000000028"));

            migrationBuilder.DeleteData(
                table: "Orden",
                keyColumn: "id_orden",
                keyValue: new Guid("f1b2c3d4-7007-4000-8000-000000000029"));

            migrationBuilder.DeleteData(
                table: "Orden",
                keyColumn: "id_orden",
                keyValue: new Guid("f1b2c3d4-7008-4000-8000-000000000030"));

            migrationBuilder.DeleteData(
                table: "Orden",
                keyColumn: "id_orden",
                keyValue: new Guid("f1b2c3d4-7009-4000-8000-000000000031"));

            migrationBuilder.DeleteData(
                table: "Orden",
                keyColumn: "id_orden",
                keyValue: new Guid("f1b2c3d4-7010-4000-8000-000000000032"));

            migrationBuilder.DeleteData(
                table: "Orden",
                keyColumn: "id_orden",
                keyValue: new Guid("f1b2c3d4-7011-4000-8000-000000000033"));

            migrationBuilder.DeleteData(
                table: "Orden",
                keyColumn: "id_orden",
                keyValue: new Guid("f1b2c3d4-7012-4000-8000-000000000034"));

            migrationBuilder.DeleteData(
                table: "Orden",
                keyColumn: "id_orden",
                keyValue: new Guid("f1b2c3d4-7013-4000-8000-000000000035"));

            migrationBuilder.DeleteData(
                table: "Orden",
                keyColumn: "id_orden",
                keyValue: new Guid("f1b2c3d4-7014-4000-8000-000000000036"));

            migrationBuilder.DeleteData(
                table: "Orden",
                keyColumn: "id_orden",
                keyValue: new Guid("f1b2c3d4-7015-4000-8000-000000000037"));

            migrationBuilder.DeleteData(
                table: "Orden",
                keyColumn: "id_orden",
                keyValue: new Guid("f1b2c3d4-7016-4000-8000-000000000038"));

            migrationBuilder.DeleteData(
                table: "Orden",
                keyColumn: "id_orden",
                keyValue: new Guid("f1b2c3d4-7017-4000-8000-000000000039"));

            migrationBuilder.DeleteData(
                table: "Orden",
                keyColumn: "id_orden",
                keyValue: new Guid("f1b2c3d4-7018-4000-8000-000000000040"));

            migrationBuilder.DeleteData(
                table: "Orden",
                keyColumn: "id_orden",
                keyValue: new Guid("f1b2c3d4-7019-4000-8000-000000000041"));

            migrationBuilder.DeleteData(
                table: "Orden",
                keyColumn: "id_orden",
                keyValue: new Guid("f1b2c3d4-7020-4000-8000-000000000042"));
        }
    }
}
