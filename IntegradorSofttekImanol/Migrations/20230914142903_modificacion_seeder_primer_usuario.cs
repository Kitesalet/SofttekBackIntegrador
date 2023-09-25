using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegradorSofttekImanol.Migrations
{
    public partial class modificacion_seeder_primer_usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 14, 11, 29, 2, 670, DateTimeKind.Local).AddTicks(9051));

            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 2,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 14, 11, 29, 2, 670, DateTimeKind.Local).AddTicks(9066));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "codRol",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 14, 11, 29, 2, 670, DateTimeKind.Local).AddTicks(9915));

            migrationBuilder.UpdateData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 14, 11, 29, 2, 670, DateTimeKind.Local).AddTicks(9302));

            migrationBuilder.UpdateData(
                table: "trabajos",
                keyColumn: "codTrabajo",
                keyValue: 1,
                columns: new[] { "fecha", "fechaAlta" },
                values: new object[] { new DateTime(2023, 9, 14, 11, 29, 2, 670, DateTimeKind.Local).AddTicks(9387), new DateTime(2023, 9, 14, 11, 29, 2, 670, DateTimeKind.Local).AddTicks(9391) });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 1,
                columns: new[] { "dni", "fechaAlta" },
                values: new object[] { 39321874, new DateTime(2023, 9, 14, 11, 29, 2, 670, DateTimeKind.Local).AddTicks(9469) });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 2,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 14, 11, 29, 2, 670, DateTimeKind.Local).AddTicks(9795));

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 3,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 14, 11, 29, 2, 670, DateTimeKind.Local).AddTicks(9829));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "fecha", "fechaAlta" },
                values: new object[] { new DateTime(2023, 9, 13, 16, 39, 8, 17, DateTimeKind.Local).AddTicks(6647), new DateTime(2023, 9, 13, 16, 39, 8, 17, DateTimeKind.Local).AddTicks(6650) });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 1,
                columns: new[] { "dni", "fechaAlta" },
                values: new object[] { 39382743, new DateTime(2023, 9, 13, 16, 39, 8, 17, DateTimeKind.Local).AddTicks(6718) });

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
    }
}
