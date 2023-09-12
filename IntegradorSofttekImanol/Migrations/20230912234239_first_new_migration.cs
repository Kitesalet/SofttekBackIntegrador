using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegradorSofttekImanol.Migrations
{
    /// <inheritdoc />
    public partial class first_new_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "proyectos",
                columns: table => new
                {
                    codProyecto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    fechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaUpdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proyectos", x => x.codProyecto);
                });

            migrationBuilder.CreateTable(
                name: "servicios",
                columns: table => new
                {
                    codServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false),
                    valorHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaUpdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servicios", x => x.codServicio);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    codUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dni = table.Column<int>(type: "int", nullable: false),
                    tipo = table.Column<int>(type: "int", nullable: false),
                    contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaUpdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.codUsuario);
                });

            migrationBuilder.CreateTable(
                name: "trabajos",
                columns: table => new
                {
                    codTrabajo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    codProyecto = table.Column<int>(type: "int", nullable: false),
                    codServicio = table.Column<int>(type: "int", nullable: false),
                    cantHoras = table.Column<int>(type: "int", nullable: false),
                    valorHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaUpdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trabajos", x => x.codTrabajo);
                    table.ForeignKey(
                        name: "FK_trabajos_proyectos_codProyecto",
                        column: x => x.codProyecto,
                        principalTable: "proyectos",
                        principalColumn: "codProyecto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trabajos_servicios_codServicio",
                        column: x => x.codServicio,
                        principalTable: "servicios",
                        principalColumn: "codServicio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_trabajos_codProyecto",
                table: "trabajos",
                column: "codProyecto");

            migrationBuilder.CreateIndex(
                name: "IX_trabajos_codServicio",
                table: "trabajos",
                column: "codServicio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trabajos");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "proyectos");

            migrationBuilder.DropTable(
                name: "servicios");
        }
    }
}
