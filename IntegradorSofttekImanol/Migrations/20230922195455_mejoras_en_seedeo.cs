using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegradorSofttekImanol.Migrations
{
    public partial class mejoras_en_seedeo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_roles_RoleCodRole",
                table: "usuarios");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_RoleCodRole",
                table: "usuarios");

            migrationBuilder.DeleteData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "RoleCodRole",
                table: "usuarios");

            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 1,
                columns: new[] { "direccion", "fechaAlta", "nombre", "estado" },
                values: new object[] { "123 Oil Avenue", new DateTime(2023, 9, 22, 16, 54, 54, 641, DateTimeKind.Local).AddTicks(1107), "Oil Rig", 1 });

            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 2,
                columns: new[] { "direccion", "fechaAlta", "nombre", "estado" },
                values: new object[] { "456 Drilling Avenue", new DateTime(2023, 9, 22, 16, 54, 54, 641, DateTimeKind.Local).AddTicks(1119), "Drilling", 2 });

            migrationBuilder.InsertData(
                table: "proyectos",
                columns: new[] { "codProyecto", "direccion", "fechaAlta", "fechaBaja", "nombre", "estado", "fechaUpdate" },
                values: new object[] { 3, "789 Refinery Avenuen", new DateTime(2023, 9, 22, 16, 54, 54, 641, DateTimeKind.Local).AddTicks(1120), null, "Refinery", 3, null });

            migrationBuilder.UpdateData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 1,
                columns: new[] { "fechaAlta", "descr" },
                values: new object[] { new DateTime(2023, 9, 22, 16, 54, 54, 641, DateTimeKind.Local).AddTicks(1292), "Maintenance" });

            migrationBuilder.InsertData(
                table: "servicios",
                columns: new[] { "codServicio", "fechaAlta", "fechaBaja", "descr", "valorHora", "estado", "fechaUpdate" },
                values: new object[,]
                {
                    { 2, new DateTime(2023, 9, 22, 16, 54, 54, 641, DateTimeKind.Local).AddTicks(1295), null, "Inspection", 120m, false, null },
                    { 3, new DateTime(2023, 9, 22, 16, 54, 54, 641, DateTimeKind.Local).AddTicks(1297), null, "Drilling", 150m, true, null },
                    { 4, new DateTime(2023, 9, 22, 16, 54, 54, 641, DateTimeKind.Local).AddTicks(1298), null, "Assessment", 200m, false, null },
                    { 5, new DateTime(2023, 9, 22, 16, 54, 54, 641, DateTimeKind.Local).AddTicks(1300), null, "Construction", 250m, true, null }
                });

            migrationBuilder.UpdateData(
                table: "trabajos",
                keyColumn: "codTrabajo",
                keyValue: 1,
                columns: new[] { "fechaAlta", "fecha" },
                values: new object[] { new DateTime(2023, 9, 22, 16, 54, 54, 641, DateTimeKind.Local).AddTicks(1390), new DateTime(2023, 9, 22, 16, 54, 54, 641, DateTimeKind.Local).AddTicks(1388) });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 1,
                columns: new[] { "fechaAlta", "contrasena" },
                values: new object[] { new DateTime(2023, 9, 22, 16, 54, 54, 641, DateTimeKind.Local).AddTicks(1791), "3df84d8d2fd61fcbe9a904130b40ff617b662f7bd82c1c917a67f95314138302" });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 2,
                columns: new[] { "fechaAlta", "dni", "contrasena" },
                values: new object[] { new DateTime(2023, 9, 22, 16, 54, 54, 641, DateTimeKind.Local).AddTicks(1877), 39847635, "3df84d8d2fd61fcbe9a904130b40ff617b662f7bd82c1c917a67f95314138302" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 5);

            migrationBuilder.AddColumn<int>(
                name: "RoleCodRole",
                table: "usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    codRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    descripcion = table.Column<string>(type: "varchar(200)", nullable: false),
                    nombre = table.Column<string>(type: "varchar(45)", nullable: false),
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
                columns: new[] { "direccion", "fechaAlta", "nombre", "estado" },
                values: new object[] { "xxxxxxxx", new DateTime(2023, 9, 20, 17, 6, 1, 92, DateTimeKind.Local).AddTicks(8763), "random", 2 });

            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 2,
                columns: new[] { "direccion", "fechaAlta", "nombre", "estado" },
                values: new object[] { "xxxxxxxx", new DateTime(2023, 9, 20, 17, 6, 1, 92, DateTimeKind.Local).AddTicks(8781), "random", 1 });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "codRol", "fechaAlta", "fechaBaja", "descripcion", "nombre", "fechaUpdate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 20, 17, 6, 1, 96, DateTimeKind.Local).AddTicks(693), null, "Usuario con derechos maximos", "Administrador", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Usuario con derechos basicos", "Consultor", null }
                });

            migrationBuilder.UpdateData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 1,
                columns: new[] { "fechaAlta", "descr" },
                values: new object[] { new DateTime(2023, 9, 20, 17, 6, 1, 92, DateTimeKind.Local).AddTicks(9107), "xxxxxxxx" });

            migrationBuilder.UpdateData(
                table: "trabajos",
                keyColumn: "codTrabajo",
                keyValue: 1,
                columns: new[] { "fechaAlta", "fecha" },
                values: new object[] { new DateTime(2023, 9, 20, 17, 6, 1, 92, DateTimeKind.Local).AddTicks(9248), new DateTime(2023, 9, 20, 17, 6, 1, 92, DateTimeKind.Local).AddTicks(9246) });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 1,
                columns: new[] { "fechaAlta", "contrasena" },
                values: new object[] { new DateTime(2023, 9, 20, 17, 6, 1, 93, DateTimeKind.Local).AddTicks(30), "2a80d4f36544c4bd8352ce27aa61c79a7dd4f7edde6cccebe94b38decbc5af5e" });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 2,
                columns: new[] { "fechaAlta", "dni", "contrasena" },
                values: new object[] { new DateTime(2023, 9, 20, 17, 6, 1, 93, DateTimeKind.Local).AddTicks(230), 39382743, "2a80d4f36544c4bd8352ce27aa61c79a7dd4f7edde6cccebe94b38decbc5af5e" });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "codUsuario", "fechaAlta", "fechaBaja", "dni", "nombre", "contrasena", "RoleCodRole", "tipo", "fechaUpdate" },
                values: new object[] { 3, new DateTime(2023, 9, 20, 17, 6, 1, 93, DateTimeKind.Local).AddTicks(309), null, 39382743, "random", "67a90cb7fd5662ad510e6861727eb97f218b440e43e7820183fabf19d7f537dc", null, 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_RoleCodRole",
                table: "usuarios",
                column: "RoleCodRole");

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_roles_RoleCodRole",
                table: "usuarios",
                column: "RoleCodRole",
                principalTable: "roles",
                principalColumn: "codRol");
        }
    }
}
