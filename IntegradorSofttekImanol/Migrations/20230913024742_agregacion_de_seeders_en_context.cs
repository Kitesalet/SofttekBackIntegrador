using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegradorSofttekImanol.Migrations
{
    public partial class agregacion_de_seeders_en_context : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "proyectos",
                columns: new[] { "codProyecto", "direccion", "estado", "fechaAlta", "fechaBaja", "fechaUpdate", "nombre" },
                values: new object[] { 1, "xxxxxxxx", 2, new DateTime(2023, 9, 12, 23, 47, 41, 817, DateTimeKind.Local).AddTicks(8397), null, null, "random" });

            migrationBuilder.InsertData(
                table: "servicios",
                columns: new[] { "codServicio", "descr", "estado", "fechaAlta", "fechaBaja", "fechaUpdate", "valorHora" },
                values: new object[] { 1, "xxxxxxxx", true, new DateTime(2023, 9, 12, 23, 47, 41, 817, DateTimeKind.Local).AddTicks(8794), null, null, 0m });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "codUsuario", "contrasena", "dni", "fechaAlta", "fechaBaja", "fechaUpdate", "nombre", "tipo" },
                values: new object[] { 1, "xxxxxxxx", 39382743, new DateTime(2023, 9, 12, 23, 47, 41, 817, DateTimeKind.Local).AddTicks(8971), null, null, "random", 0 });

            migrationBuilder.InsertData(
                table: "trabajos",
                columns: new[] { "codTrabajo", "cantHoras", "codProyecto", "codServicio", "costo", "fecha", "fechaAlta", "fechaBaja", "fechaUpdate", "valorHora" },
                values: new object[] { 1, 2, 1, 1, 0m, new DateTime(2023, 9, 12, 23, 47, 41, 817, DateTimeKind.Local).AddTicks(8885), new DateTime(2023, 9, 12, 23, 47, 41, 817, DateTimeKind.Local).AddTicks(8888), null, null, 4m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "trabajos",
                keyColumn: "codTrabajo",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 1);
        }
    }
}
