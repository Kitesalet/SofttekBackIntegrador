using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegradorSofttekImanol.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                column: "fechaAlta",
                value: new DateTime(2023, 9, 19, 14, 13, 14, 108, DateTimeKind.Local).AddTicks(9889));

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
                columns: new[] { "contrasena", "fechaAlta" },
                values: new object[] { "2a80d4f36544c4bd8352ce27aa61c79a7dd4f7edde6cccebe94b38decbc5af5e", new DateTime(2023, 9, 19, 14, 13, 14, 109, DateTimeKind.Local).AddTicks(342) });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 2,
                columns: new[] { "contrasena", "fechaAlta" },
                values: new object[] { "2a80d4f36544c4bd8352ce27aa61c79a7dd4f7edde6cccebe94b38decbc5af5e", new DateTime(2023, 9, 19, 14, 13, 14, 109, DateTimeKind.Local).AddTicks(412) });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 3,
                columns: new[] { "contrasena", "fechaAlta" },
                values: new object[] { "67a90cb7fd5662ad510e6861727eb97f218b440e43e7820183fabf19d7f537dc", new DateTime(2023, 9, 19, 14, 13, 14, 109, DateTimeKind.Local).AddTicks(531) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
