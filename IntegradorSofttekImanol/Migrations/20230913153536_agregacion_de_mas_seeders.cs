using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegradorSofttekImanol.Migrations
{
    public partial class agregacion_de_mas_seeders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    codRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaUpdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.codRol);
                });

            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 13, 12, 35, 35, 887, DateTimeKind.Local).AddTicks(2120));

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "codRol", "description", "fechaAlta", "fechaBaja", "fechaUpdate", "nombre" },
                values: new object[,]
                {
                    { 1, "Usuario con derechos maximos", new DateTime(2023, 9, 13, 12, 35, 35, 887, DateTimeKind.Local).AddTicks(2869), null, null, "Administrador" },
                    { 2, "Usuario con derechos basicos", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Consultor" }
                });

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
                columns: new[] { "contrasena", "fechaAlta", "tipo" },
                values: new object[] { "a441b15fe9a3cf56661190a0b93b9dec7d04127288cc87250967cf3b52894d11", new DateTime(2023, 9, 13, 12, 35, 35, 887, DateTimeKind.Local).AddTicks(2665), 1 });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "codUsuario", "contrasena", "dni", "fechaAlta", "fechaBaja", "fechaUpdate", "nombre", "tipo" },
                values: new object[] { 2, "4e151238dcbb465195f49433b8ea408b8889a41d995e25b990b502d3362a602d", 39382743, new DateTime(2023, 9, 13, 12, 35, 35, 887, DateTimeKind.Local).AddTicks(2762), null, null, "randoms", 2 });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "codUsuario", "contrasena", "dni", "fechaAlta", "fechaBaja", "fechaUpdate", "nombre", "tipo" },
                values: new object[] { 3, "4e151238dcbb465195f49433b8ea408b8889a41d995e25b990b502d3362a602d", 39382743, new DateTime(2023, 9, 13, 12, 35, 35, 887, DateTimeKind.Local).AddTicks(2797), null, null, "randomdd", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_tipo",
                table: "usuarios",
                column: "tipo");

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_roles_tipo",
                table: "usuarios",
                column: "tipo",
                principalTable: "roles",
                principalColumn: "codRol",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_roles_tipo",
                table: "usuarios");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_tipo",
                table: "usuarios");

            migrationBuilder.DeleteData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 12, 23, 47, 41, 817, DateTimeKind.Local).AddTicks(8397));

            migrationBuilder.UpdateData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 12, 23, 47, 41, 817, DateTimeKind.Local).AddTicks(8794));

            migrationBuilder.UpdateData(
                table: "trabajos",
                keyColumn: "codTrabajo",
                keyValue: 1,
                columns: new[] { "fecha", "fechaAlta" },
                values: new object[] { new DateTime(2023, 9, 12, 23, 47, 41, 817, DateTimeKind.Local).AddTicks(8885), new DateTime(2023, 9, 12, 23, 47, 41, 817, DateTimeKind.Local).AddTicks(8888) });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 1,
                columns: new[] { "contrasena", "fechaAlta", "tipo" },
                values: new object[] { "xxxxxxxx", new DateTime(2023, 9, 12, 23, 47, 41, 817, DateTimeKind.Local).AddTicks(8971), 0 });
        }
    }
}
