using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegradorSofttekImanol.Migrations
{
    public partial class cambios_proyecto_servicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 19, 20, 53, 0, 134, DateTimeKind.Local).AddTicks(1054));

            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 2,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 19, 20, 53, 0, 134, DateTimeKind.Local).AddTicks(1062));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "codRol",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 19, 20, 53, 0, 134, DateTimeKind.Local).AddTicks(1961));

            migrationBuilder.UpdateData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 1,
                columns: new[] { "fechaAlta", "valorHora" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 53, 0, 134, DateTimeKind.Local).AddTicks(1387), 100m });

            migrationBuilder.UpdateData(
                table: "trabajos",
                keyColumn: "codTrabajo",
                keyValue: 1,
                columns: new[] { "fecha", "fechaAlta" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 53, 0, 134, DateTimeKind.Local).AddTicks(1450), new DateTime(2023, 9, 19, 20, 53, 0, 134, DateTimeKind.Local).AddTicks(1452) });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 19, 20, 53, 0, 134, DateTimeKind.Local).AddTicks(1746));

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 2,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 19, 20, 53, 0, 134, DateTimeKind.Local).AddTicks(1804));

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 3,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 19, 20, 53, 0, 134, DateTimeKind.Local).AddTicks(1892));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 19, 14, 13, 14, 108, DateTimeKind.Local).AddTicks(9673));

            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 2,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 19, 14, 13, 14, 108, DateTimeKind.Local).AddTicks(9683));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "codRol",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 19, 14, 13, 14, 109, DateTimeKind.Local).AddTicks(623));

            migrationBuilder.UpdateData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 1,
                columns: new[] { "fechaAlta", "valorHora" },
                values: new object[] { new DateTime(2023, 9, 19, 14, 13, 14, 108, DateTimeKind.Local).AddTicks(9889), 0m });

            migrationBuilder.UpdateData(
                table: "trabajos",
                keyColumn: "codTrabajo",
                keyValue: 1,
                columns: new[] { "fecha", "fechaAlta" },
                values: new object[] { new DateTime(2023, 9, 19, 14, 13, 14, 108, DateTimeKind.Local).AddTicks(9982), new DateTime(2023, 9, 19, 14, 13, 14, 108, DateTimeKind.Local).AddTicks(9985) });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 19, 14, 13, 14, 109, DateTimeKind.Local).AddTicks(342));

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 2,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 19, 14, 13, 14, 109, DateTimeKind.Local).AddTicks(412));

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 3,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 19, 14, 13, 14, 109, DateTimeKind.Local).AddTicks(531));
        }
    }
}
