﻿// <auto-generated />
using System;
using IntegradorSofttekImanol.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IntegradorSofttekImanol.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IntegradorSofttekImanol.Models.Entities.Proyecto", b =>
                {
                    b.Property<int>("CodProyecto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codProyecto");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodProyecto"), 1L, 1);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("direccion");

                    b.Property<int>("Estado")
                        .HasColumnType("int")
                        .HasColumnName("estado");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaAlta");

                    b.Property<DateTime?>("FechaBaja")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaBaja");

                    b.Property<DateTime?>("FechaUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaUpdate");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.HasKey("CodProyecto");

                    b.ToTable("proyectos");

                    b.HasData(
                        new
                        {
                            CodProyecto = 1,
                            Direccion = "xxxxxxxx",
                            Estado = 2,
                            FechaAlta = new DateTime(2023, 9, 19, 14, 13, 14, 108, DateTimeKind.Local).AddTicks(9673),
                            Nombre = "random"
                        },
                        new
                        {
                            CodProyecto = 2,
                            Direccion = "xxxxxxxx",
                            Estado = 1,
                            FechaAlta = new DateTime(2023, 9, 19, 14, 13, 14, 108, DateTimeKind.Local).AddTicks(9683),
                            Nombre = "random"
                        });
                });

            modelBuilder.Entity("IntegradorSofttekImanol.Models.Entities.Rol", b =>
                {
                    b.Property<int>("CodRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codRol");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodRol"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("descripcion");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaAlta");

                    b.Property<DateTime?>("FechaBaja")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaBaja");

                    b.Property<DateTime?>("FechaUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaUpdate");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(45)")
                        .HasColumnName("nombre");

                    b.HasKey("CodRol");

                    b.ToTable("roles");

                    b.HasData(
                        new
                        {
                            CodRol = 1,
                            Descripcion = "Usuario con derechos maximos",
                            FechaAlta = new DateTime(2023, 9, 19, 14, 13, 14, 109, DateTimeKind.Local).AddTicks(623),
                            Nombre = "Administrador"
                        },
                        new
                        {
                            CodRol = 2,
                            Descripcion = "Usuario con derechos basicos",
                            FechaAlta = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Consultor"
                        });
                });

            modelBuilder.Entity("IntegradorSofttekImanol.Models.Entities.Servicio", b =>
                {
                    b.Property<int>("CodServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codServicio");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodServicio"), 1L, 1);

                    b.Property<string>("Descr")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("descr");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("estado");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaAlta");

                    b.Property<DateTime?>("FechaBaja")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaBaja");

                    b.Property<DateTime?>("FechaUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaUpdate");

                    b.Property<decimal>("ValorHora")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("valorHora");

                    b.HasKey("CodServicio");

                    b.ToTable("servicios");

                    b.HasData(
                        new
                        {
                            CodServicio = 1,
                            Descr = "xxxxxxxx",
                            Estado = true,
                            FechaAlta = new DateTime(2023, 9, 19, 14, 13, 14, 108, DateTimeKind.Local).AddTicks(9889),
                            ValorHora = 0m
                        });
                });

            modelBuilder.Entity("IntegradorSofttekImanol.Models.Entities.Trabajo", b =>
                {
                    b.Property<int>("CodTrabajo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codTrabajo");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodTrabajo"), 1L, 1);

                    b.Property<int>("CantHoras")
                        .HasColumnType("int")
                        .HasColumnName("cantHoras");

                    b.Property<int>("CodProyecto")
                        .HasColumnType("int")
                        .HasColumnName("codProyecto");

                    b.Property<int>("CodServicio")
                        .HasColumnType("int")
                        .HasColumnName("codServicio");

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("costo");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2")
                        .HasColumnName("fecha");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaAlta");

                    b.Property<DateTime?>("FechaBaja")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaBaja");

                    b.Property<DateTime?>("FechaUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaUpdate");

                    b.Property<decimal>("valorHora")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("valorHora");

                    b.HasKey("CodTrabajo");

                    b.HasIndex("CodProyecto");

                    b.HasIndex("CodServicio");

                    b.ToTable("trabajos");

                    b.HasData(
                        new
                        {
                            CodTrabajo = 1,
                            CantHoras = 2,
                            CodProyecto = 1,
                            CodServicio = 1,
                            Costo = 8m,
                            Fecha = new DateTime(2023, 9, 19, 14, 13, 14, 108, DateTimeKind.Local).AddTicks(9982),
                            FechaAlta = new DateTime(2023, 9, 19, 14, 13, 14, 108, DateTimeKind.Local).AddTicks(9985),
                            valorHora = 4m
                        });
                });

            modelBuilder.Entity("IntegradorSofttekImanol.Models.Entities.Usuario", b =>
                {
                    b.Property<int>("CodUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codUsuario");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodUsuario"), 1L, 1);

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("contrasena");

                    b.Property<int>("Dni")
                        .HasColumnType("int")
                        .HasColumnName("dni");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaAlta");

                    b.Property<DateTime?>("FechaBaja")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaBaja");

                    b.Property<DateTime?>("FechaUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaUpdate");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasColumnName("nombre");

                    b.Property<int>("Tipo")
                        .HasColumnType("int")
                        .HasColumnName("tipo");

                    b.HasKey("CodUsuario");

                    b.HasIndex("Tipo");

                    b.ToTable("usuarios");

                    b.HasData(
                        new
                        {
                            CodUsuario = 1,
                            Contrasena = "2a80d4f36544c4bd8352ce27aa61c79a7dd4f7edde6cccebe94b38decbc5af5e",
                            Dni = 39321874,
                            FechaAlta = new DateTime(2023, 9, 19, 14, 13, 14, 109, DateTimeKind.Local).AddTicks(342),
                            Nombre = "random",
                            Tipo = 1
                        },
                        new
                        {
                            CodUsuario = 2,
                            Contrasena = "2a80d4f36544c4bd8352ce27aa61c79a7dd4f7edde6cccebe94b38decbc5af5e",
                            Dni = 39382743,
                            FechaAlta = new DateTime(2023, 9, 19, 14, 13, 14, 109, DateTimeKind.Local).AddTicks(412),
                            Nombre = "randoms",
                            Tipo = 2
                        },
                        new
                        {
                            CodUsuario = 3,
                            Contrasena = "67a90cb7fd5662ad510e6861727eb97f218b440e43e7820183fabf19d7f537dc",
                            Dni = 39382743,
                            FechaAlta = new DateTime(2023, 9, 19, 14, 13, 14, 109, DateTimeKind.Local).AddTicks(531),
                            Nombre = "randomdd",
                            Tipo = 2
                        });
                });

            modelBuilder.Entity("IntegradorSofttekImanol.Models.Entities.Trabajo", b =>
                {
                    b.HasOne("IntegradorSofttekImanol.Models.Entities.Proyecto", "Proyecto")
                        .WithMany("Trabajo")
                        .HasForeignKey("CodProyecto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IntegradorSofttekImanol.Models.Entities.Servicio", "Servicio")
                        .WithMany("Trabajo")
                        .HasForeignKey("CodServicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proyecto");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("IntegradorSofttekImanol.Models.Entities.Usuario", b =>
                {
                    b.HasOne("IntegradorSofttekImanol.Models.Entities.Rol", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("Tipo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("IntegradorSofttekImanol.Models.Entities.Proyecto", b =>
                {
                    b.Navigation("Trabajo");
                });

            modelBuilder.Entity("IntegradorSofttekImanol.Models.Entities.Rol", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("IntegradorSofttekImanol.Models.Entities.Servicio", b =>
                {
                    b.Navigation("Trabajo");
                });
#pragma warning restore 612, 618
        }
    }
}
