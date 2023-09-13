using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegradorSofttekImanol.Migrations
{
    public partial class cambio_en_seed_proyecto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 13, 16, 30, 4, 210, DateTimeKind.Local).AddTicks(6548));

            migrationBuilder.InsertData(
                table: "proyectos",
                columns: new[] { "codProyecto", "direccion", "estado", "fechaAlta", "fechaBaja", "fechaUpdate", "nombre" },
                values: new object[] { 2, "xxxxxxxx", 1, new DateTime(2023, 9, 13, 16, 30, 4, 210, DateTimeKind.Local).AddTicks(6557), null, null, "random" });

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
                columns: new[] { "fecha", "fechaAlta" },
                values: new object[] { new DateTime(2023, 9, 13, 16, 30, 4, 210, DateTimeKind.Local).AddTicks(6806), new DateTime(2023, 9, 13, 16, 30, 4, 210, DateTimeKind.Local).AddTicks(6809) });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 13, 13, 55, 16, 641, DateTimeKind.Local).AddTicks(616));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "codRol",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 13, 13, 55, 16, 641, DateTimeKind.Local).AddTicks(1611));

            migrationBuilder.UpdateData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 13, 13, 55, 16, 641, DateTimeKind.Local).AddTicks(873));

            migrationBuilder.UpdateData(
                table: "trabajos",
                keyColumn: "codTrabajo",
                keyValue: 1,
                columns: new[] { "fecha", "fechaAlta" },
                values: new object[] { new DateTime(2023, 9, 13, 13, 55, 16, 641, DateTimeKind.Local).AddTicks(978), new DateTime(2023, 9, 13, 13, 55, 16, 641, DateTimeKind.Local).AddTicks(982) });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 13, 13, 55, 16, 641, DateTimeKind.Local).AddTicks(1086));

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 2,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 13, 13, 55, 16, 641, DateTimeKind.Local).AddTicks(1326));

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 3,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 13, 13, 55, 16, 641, DateTimeKind.Local).AddTicks(1455));
        }
    }
}
