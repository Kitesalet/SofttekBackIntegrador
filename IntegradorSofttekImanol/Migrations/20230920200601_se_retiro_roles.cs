using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegradorSofttekImanol.Migrations
{
    public partial class se_retiro_roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_roles_tipo",
                table: "usuarios");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_tipo",
                table: "usuarios");

            migrationBuilder.AddColumn<int>(
                name: "RoleCodRole",
                table: "usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 20, 17, 6, 1, 92, DateTimeKind.Local).AddTicks(8763));

            migrationBuilder.UpdateData(
                table: "proyectos",
                keyColumn: "codProyecto",
                keyValue: 2,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 20, 17, 6, 1, 92, DateTimeKind.Local).AddTicks(8781));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "codRol",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 20, 17, 6, 1, 96, DateTimeKind.Local).AddTicks(693));

            migrationBuilder.UpdateData(
                table: "servicios",
                keyColumn: "codServicio",
                keyValue: 1,
                column: "fechaAlta",
                value: new DateTime(2023, 9, 20, 17, 6, 1, 92, DateTimeKind.Local).AddTicks(9107));

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
                columns: new[] { "fechaAlta", "tipo" },
                values: new object[] { new DateTime(2023, 9, 20, 17, 6, 1, 93, DateTimeKind.Local).AddTicks(30), 2 });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 2,
                columns: new[] { "fechaAlta", "nombre", "tipo" },
                values: new object[] { new DateTime(2023, 9, 20, 17, 6, 1, 93, DateTimeKind.Local).AddTicks(230), "random", 1 });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 3,
                columns: new[] { "fechaAlta", "nombre", "tipo" },
                values: new object[] { new DateTime(2023, 9, 20, 17, 6, 1, 93, DateTimeKind.Local).AddTicks(309), "random", 1 });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_roles_RoleCodRole",
                table: "usuarios");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_RoleCodRole",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "RoleCodRole",
                table: "usuarios");

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
                columns: new[] { "fechaAlta", "tipo" },
                values: new object[] { new DateTime(2023, 9, 20, 15, 54, 26, 395, DateTimeKind.Local).AddTicks(4837), 1 });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 2,
                columns: new[] { "fechaAlta", "nombre", "tipo" },
                values: new object[] { new DateTime(2023, 9, 20, 15, 54, 26, 395, DateTimeKind.Local).AddTicks(5038), "randoms", 2 });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "codUsuario",
                keyValue: 3,
                columns: new[] { "fechaAlta", "nombre", "tipo" },
                values: new object[] { new DateTime(2023, 9, 20, 15, 54, 26, 395, DateTimeKind.Local).AddTicks(5122), "randomdd", 2 });

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
    }
}
