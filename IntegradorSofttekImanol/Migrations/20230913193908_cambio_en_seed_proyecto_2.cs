using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegradorSofttekImanol.Migrations
{
    public partial class cambio_en_seed_proyecto_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 13, 16, 39, 8, 17, DateTimeKind.Local).AddTicks(6406));

            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 2,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 13, 16, 39, 8, 17, DateTimeKind.Local).AddTicks(6416));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "codRol",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 13, 16, 39, 8, 17, DateTimeKind.Local).AddTicks(7057));

            migrationBuilder.UpdateData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 13, 16, 39, 8, 17, DateTimeKind.Local).AddTicks(6584));

            migrationBuilder.UpdateData(
                table: "trabajos",
                keyColumn: "codTrabajo",
                keyValue: 1,
                columns: new[] { "costo", "fecha", "fechaAlta" },
                values: new object[] { 8m, new DateTime(2023, 9, 13, 16, 39, 8, 17, DateTimeKind.Local).AddTicks(6647), new DateTime(2023, 9, 13, 16, 39, 8, 17, DateTimeKind.Local).AddTicks(6650) });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 13, 16, 39, 8, 17, DateTimeKind.Local).AddTicks(6718));

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 2,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 13, 16, 39, 8, 17, DateTimeKind.Local).AddTicks(6912));

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 3,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 13, 16, 39, 8, 17, DateTimeKind.Local).AddTicks(6948));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 13, 16, 30, 4, 210, DateTimeKind.Local).AddTicks(6548));

            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 2,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 13, 16, 30, 4, 210, DateTimeKind.Local).AddTicks(6557));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "codRol",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 13, 16, 30, 4, 210, DateTimeKind.Local).AddTicks(7218));

            migrationBuilder.UpdateData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 13, 16, 30, 4, 210, DateTimeKind.Local).AddTicks(6735));

            migrationBuilder.UpdateData(
                table: "trabajos",
                keyColumn: "codTrabajo",
                keyValue: 1,
                columns: new[] { "costo", "fecha", "fechaAlta" },
                values: new object[] { 0m, new DateTime(2023, 9, 13, 16, 30, 4, 210, DateTimeKind.Local).AddTicks(6806), new DateTime(2023, 9, 13, 16, 30, 4, 210, DateTimeKind.Local).AddTicks(6809) });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 13, 16, 30, 4, 210, DateTimeKind.Local).AddTicks(6869));

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 2,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 13, 16, 30, 4, 210, DateTimeKind.Local).AddTicks(7062));

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 3,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 13, 16, 30, 4, 210, DateTimeKind.Local).AddTicks(7152));
        }
    }
}
