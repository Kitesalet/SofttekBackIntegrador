using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegradorSofttekImanol.Migrations
{
    public partial class new_mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 19, 13, 55, 28, 596, DateTimeKind.Local).AddTicks(166));

            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 2,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 19, 13, 55, 28, 596, DateTimeKind.Local).AddTicks(174));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "codRol",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 19, 13, 55, 28, 596, DateTimeKind.Local).AddTicks(895));

            migrationBuilder.UpdateData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 19, 13, 55, 28, 596, DateTimeKind.Local).AddTicks(343));

            migrationBuilder.UpdateData(
                table: "trabajos",
                keyColumn: "codTrabajo",
                keyValue: 1,
                columns: new[] { "fecha", "fechaAlta" },
                values: new object[] { new DateTime(2023, 9, 19, 13, 55, 28, 596, DateTimeKind.Local).AddTicks(403), new DateTime(2023, 9, 19, 13, 55, 28, 596, DateTimeKind.Local).AddTicks(406) });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 19, 13, 55, 28, 596, DateTimeKind.Local).AddTicks(680));

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 2,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 19, 13, 55, 28, 596, DateTimeKind.Local).AddTicks(739));

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 3,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 19, 13, 55, 28, 596, DateTimeKind.Local).AddTicks(823));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 18, 6, 33, 33, 484, DateTimeKind.Local).AddTicks(7313));

            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 2,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 18, 6, 33, 33, 484, DateTimeKind.Local).AddTicks(7326));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "codRol",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 18, 6, 33, 33, 484, DateTimeKind.Local).AddTicks(8709));

            migrationBuilder.UpdateData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 18, 6, 33, 33, 484, DateTimeKind.Local).AddTicks(7606));

            migrationBuilder.UpdateData(
                table: "trabajos",
                keyColumn: "codTrabajo",
                keyValue: 1,
                columns: new[] { "fecha", "fechaAlta" },
                values: new object[] { new DateTime(2023, 9, 18, 6, 33, 33, 484, DateTimeKind.Local).AddTicks(7704), new DateTime(2023, 9, 18, 6, 33, 33, 484, DateTimeKind.Local).AddTicks(7708) });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 18, 6, 33, 33, 484, DateTimeKind.Local).AddTicks(8214));

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 2,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 18, 6, 33, 33, 484, DateTimeKind.Local).AddTicks(8299));

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 3,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 18, 6, 33, 33, 484, DateTimeKind.Local).AddTicks(8491));
        }
    }
}
