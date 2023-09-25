using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegradorSofttekImanol.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 17, 16, 13, 45, 127, DateTimeKind.Local).AddTicks(9275));

            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 2,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 17, 16, 13, 45, 127, DateTimeKind.Local).AddTicks(9286));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "codRol",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 17, 16, 13, 45, 128, DateTimeKind.Local).AddTicks(243));

            migrationBuilder.UpdateData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 17, 16, 13, 45, 127, DateTimeKind.Local).AddTicks(9479));

            migrationBuilder.UpdateData(
                table: "trabajos",
                keyColumn: "codTrabajo",
                keyValue: 1,
                columns: new[] { "fecha", "fechaAlta" },
                values: new object[] { new DateTime(2023, 9, 17, 16, 13, 45, 127, DateTimeKind.Local).AddTicks(9560), new DateTime(2023, 9, 17, 16, 13, 45, 127, DateTimeKind.Local).AddTicks(9564) });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 1,
                columns: new[] { "contrasena", "fechaAlta" },
                values: new object[] { "5027b777d9a671fcde693a6269cb3e9594602138fb2305bd54d99763373700bf", new DateTime(2023, 9, 17, 16, 13, 45, 128, DateTimeKind.Local).AddTicks(8) });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 2,
                columns: new[] { "contrasena", "fechaAlta" },
                values: new object[] { "c2f48c5bdf5da0dab948e28cf1a9605256a62b0d0138c3ce2bca4467f14884ef", new DateTime(2023, 9, 17, 16, 13, 45, 128, DateTimeKind.Local).AddTicks(86) });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 3,
                columns: new[] { "contrasena", "fechaAlta" },
                values: new object[] { "c2f48c5bdf5da0dab948e28cf1a9605256a62b0d0138c3ce2bca4467f14884ef", new DateTime(2023, 9, 17, 16, 13, 45, 128, DateTimeKind.Local).AddTicks(152) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "contrasena", "fechaAlta" },
                values: new object[] { "random", new DateTime(2023, 9, 14, 11, 29, 2, 670, DateTimeKind.Local).AddTicks(9469) });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 2,
                columns: new[] { "contrasena", "fechaAlta" },
                values: new object[] { "4e151238dcbb465195f49433b8ea408b8889a41d995e25b990b502d3362a602d", new DateTime(2023, 9, 14, 11, 29, 2, 670, DateTimeKind.Local).AddTicks(9795) });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 3,
                columns: new[] { "contrasena", "fechaAlta" },
                values: new object[] { "4e151238dcbb465195f49433b8ea408b8889a41d995e25b990b502d3362a602d", new DateTime(2023, 9, 14, 11, 29, 2, 670, DateTimeKind.Local).AddTicks(9829) });
        }
    }
}
