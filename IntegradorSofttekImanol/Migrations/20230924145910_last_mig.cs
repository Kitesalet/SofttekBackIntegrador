using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegradorSofttekImanol.Migrations
{
    public partial class last_mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 24, 11, 59, 10, 169, DateTimeKind.Local).AddTicks(6225));

            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 2,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 24, 11, 59, 10, 169, DateTimeKind.Local).AddTicks(6237));

            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 3,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 24, 11, 59, 10, 169, DateTimeKind.Local).AddTicks(6238));

            migrationBuilder.UpdateData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 24, 11, 59, 10, 169, DateTimeKind.Local).AddTicks(6412));

            migrationBuilder.UpdateData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 2,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 24, 11, 59, 10, 169, DateTimeKind.Local).AddTicks(6417));

            migrationBuilder.UpdateData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 3,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 24, 11, 59, 10, 169, DateTimeKind.Local).AddTicks(6418));

            migrationBuilder.UpdateData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 4,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 24, 11, 59, 10, 169, DateTimeKind.Local).AddTicks(6430));

            migrationBuilder.UpdateData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 5,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 24, 11, 59, 10, 169, DateTimeKind.Local).AddTicks(6431));

            migrationBuilder.UpdateData(
                table: "trabajos",
                keyColumn: "codTrabajo",
                keyValue: 1,
                columns: new[] { "costo", "fechaAlta", "fecha", "cantHoras", "valorHora" },
                values: new object[] { 1000m, new DateTime(2023, 9, 24, 11, 59, 10, 169, DateTimeKind.Local).AddTicks(6549), new DateTime(2023, 9, 24, 11, 59, 10, 169, DateTimeKind.Local).AddTicks(6547), 10, 100m });

            migrationBuilder.InsertData(
                table: "trabajos",
                columns: new[] { "codTrabajo", "codProyecto", "codServicio", "costo", "fechaAlta", "fecha", "fechaBaja", "cantHoras", "valorHora", "fechaUpdate" },
                values: new object[] { 2, 2, 2, 2400m, new DateTime(2023, 9, 24, 11, 59, 10, 169, DateTimeKind.Local).AddTicks(6550), new DateTime(2023, 9, 24, 11, 59, 10, 169, DateTimeKind.Local).AddTicks(6549), null, 20, 120m, null });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 24, 11, 59, 10, 169, DateTimeKind.Local).AddTicks(6929));

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 2,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 24, 11, 59, 10, 169, DateTimeKind.Local).AddTicks(7004));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "trabajos",
                keyColumn: "codTrabajo",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 22, 16, 54, 54, 641, DateTimeKind.Local).AddTicks(1107));

            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 2,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 22, 16, 54, 54, 641, DateTimeKind.Local).AddTicks(1119));

            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 3,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 22, 16, 54, 54, 641, DateTimeKind.Local).AddTicks(1120));

            migrationBuilder.UpdateData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 22, 16, 54, 54, 641, DateTimeKind.Local).AddTicks(1292));

            migrationBuilder.UpdateData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 2,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 22, 16, 54, 54, 641, DateTimeKind.Local).AddTicks(1295));

            migrationBuilder.UpdateData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 3,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 22, 16, 54, 54, 641, DateTimeKind.Local).AddTicks(1297));

            migrationBuilder.UpdateData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 4,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 22, 16, 54, 54, 641, DateTimeKind.Local).AddTicks(1298));

            migrationBuilder.UpdateData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 5,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 22, 16, 54, 54, 641, DateTimeKind.Local).AddTicks(1300));

            migrationBuilder.UpdateData(
                table: "trabajos",
                keyColumn: "codTrabajo",
                keyValue: 1,
                columns: new[] { "costo", "fechaAlta", "fecha", "cantHoras", "valorHora" },
                values: new object[] { 8m, new DateTime(2023, 9, 22, 16, 54, 54, 641, DateTimeKind.Local).AddTicks(1390), new DateTime(2023, 9, 22, 16, 54, 54, 641, DateTimeKind.Local).AddTicks(1388), 2, 4m });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 22, 16, 54, 54, 641, DateTimeKind.Local).AddTicks(1791));

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 2,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 22, 16, 54, 54, 641, DateTimeKind.Local).AddTicks(1877));
        }
    }
}
