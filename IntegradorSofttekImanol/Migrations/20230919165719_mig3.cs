using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegradorSofttekImanol.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 19, 13, 57, 19, 34, DateTimeKind.Local).AddTicks(1618));

            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 2,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 19, 13, 57, 19, 34, DateTimeKind.Local).AddTicks(1629));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "codRol",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 19, 13, 57, 19, 34, DateTimeKind.Local).AddTicks(2439));

            migrationBuilder.UpdateData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 19, 13, 57, 19, 34, DateTimeKind.Local).AddTicks(1803));

            migrationBuilder.UpdateData(
                table: "trabajos",
                keyColumn: "codTrabajo",
                keyValue: 1,
                columns: new[] { "fecha", "fechaAlta" },
                values: new object[] { new DateTime(2023, 9, 19, 13, 57, 19, 34, DateTimeKind.Local).AddTicks(1863), new DateTime(2023, 9, 19, 13, 57, 19, 34, DateTimeKind.Local).AddTicks(1867) });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 1,
                columns: new[] { "contrasena", "fechaAlta" },
                values: new object[] { "6595cdd5bbc03b9e204c99e415a3913d7ef6002beb2470666b3509245f6541a7", new DateTime(2023, 9, 19, 13, 57, 19, 34, DateTimeKind.Local).AddTicks(2193) });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 2,
                columns: new[] { "contrasena", "fechaAlta" },
                values: new object[] { "50512f619f273a7d66c428e837b22e0df402bf74ac3232c1551b6c7b686fdf5e", new DateTime(2023, 9, 19, 13, 57, 19, 34, DateTimeKind.Local).AddTicks(2309) });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 3,
                columns: new[] { "contrasena", "fechaAlta" },
                values: new object[] { "e2fe35a33339f5bbfe8c068cafcf2cc1bfa6e696e90b9f3fc3358bf2d823caa6", new DateTime(2023, 9, 19, 13, 57, 19, 34, DateTimeKind.Local).AddTicks(2366) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "contrasena", "fechaAlta" },
                values: new object[] { "5027b777d9a671fcde693a6269cb3e9594602138fb2305bd54d99763373700bf", new DateTime(2023, 9, 19, 13, 55, 28, 596, DateTimeKind.Local).AddTicks(680) });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 2,
                columns: new[] { "contrasena", "fechaAlta" },
                values: new object[] { "c2f48c5bdf5da0dab948e28cf1a9605256a62b0d0138c3ce2bca4467f14884ef", new DateTime(2023, 9, 19, 13, 55, 28, 596, DateTimeKind.Local).AddTicks(739) });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 3,
                columns: new[] { "contrasena", "fechaAlta" },
                values: new object[] { "c2f48c5bdf5da0dab948e28cf1a9605256a62b0d0138c3ce2bca4467f14884ef", new DateTime(2023, 9, 19, 13, 55, 28, 596, DateTimeKind.Local).AddTicks(823) });
        }
    }
}
