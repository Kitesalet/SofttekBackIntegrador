using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegradorSofttekImanol.Migrations
{
    public partial class traducido_todo_el_codigo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 20, 15, 54, 26, 395, DateTimeKind.Local).AddTicks(3907));

            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 2,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 20, 15, 54, 26, 395, DateTimeKind.Local).AddTicks(3921));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "codRol",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 20, 15, 54, 26, 395, DateTimeKind.Local).AddTicks(5267));

            migrationBuilder.UpdateData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 20, 15, 54, 26, 395, DateTimeKind.Local).AddTicks(4181));

            migrationBuilder.UpdateData(
                table: "trabajos",
                keyColumn: "codTrabajo",
                keyValue: 1,
                columns: new[] { "fechaAlta", "fecha" },
                values: new object[] { new DateTime(2023, 9, 20, 15, 54, 26, 395, DateTimeKind.Local).AddTicks(4283), new DateTime(2023, 9, 20, 15, 54, 26, 395, DateTimeKind.Local).AddTicks(4280) });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 20, 15, 54, 26, 395, DateTimeKind.Local).AddTicks(4837));

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 2,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 20, 15, 54, 26, 395, DateTimeKind.Local).AddTicks(5038));

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 3,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 20, 15, 54, 26, 395, DateTimeKind.Local).AddTicks(5122));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                column: "fechaAlta",
                value: new DateTime(2023, 9, 19, 20, 53, 0, 134, DateTimeKind.Local).AddTicks(1387));

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
    }
}
