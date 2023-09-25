using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegradorSofttekImanol.Migrations
{
    public partial class modificacion_en_seeder_de_usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "contrasena", "fechaAlta" },
                values: new object[] { "random", new DateTime(2023, 9, 13, 13, 55, 16, 641, DateTimeKind.Local).AddTicks(1086) });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 13, 12, 35, 35, 887, DateTimeKind.Local).AddTicks(2120));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "codRol",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 13, 12, 35, 35, 887, DateTimeKind.Local).AddTicks(2869));

            migrationBuilder.UpdateData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 13, 12, 35, 35, 887, DateTimeKind.Local).AddTicks(2332));

            migrationBuilder.UpdateData(
                table: "trabajos",
                keyColumn: "codTrabajo",
                keyValue: 1,
                columns: new[] { "fecha", "fechaAlta" },
                values: new object[] { new DateTime(2023, 9, 13, 12, 35, 35, 887, DateTimeKind.Local).AddTicks(2399), new DateTime(2023, 9, 13, 12, 35, 35, 887, DateTimeKind.Local).AddTicks(2402) });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 1,
                columns: new[] { "contrasena", "fechaAlta" },
                values: new object[] { "a441b15fe9a3cf56661190a0b93b9dec7d04127288cc87250967cf3b52894d11", new DateTime(2023, 9, 13, 12, 35, 35, 887, DateTimeKind.Local).AddTicks(2665) });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 2,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 13, 12, 35, 35, 887, DateTimeKind.Local).AddTicks(2762));

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 3,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 13, 12, 35, 35, 887, DateTimeKind.Local).AddTicks(2797));
        }
    }
}
