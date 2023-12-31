﻿// <auto-generated />
using System;
using IntegradorSofttekImanol.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IntegradorSofttekImanol.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230913024742_agregacion_de_seeders_en_context")]
    partial class agregacion_de_seeders_en_context
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IntegradorSofttekImanol.Entities.Proyecto", b =>
                {
                    b.Property<int>("CodProyecto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codProyecto");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodProyecto"), 1L, 1);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
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
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nombre");

                    b.HasKey("CodProyecto");

                    b.ToTable("proyectos");

                    b.HasData(
                        new
                        {
                            CodProyecto = 1,
                            Direccion = "xxxxxxxx",
                            Estado = 2,
                            FechaAlta = new DateTime(2023, 9, 12, 23, 47, 41, 817, DateTimeKind.Local).AddTicks(8397),
                            Nombre = "random"
                        });
                });

            modelBuilder.Entity("IntegradorSofttekImanol.Entities.Servicio", b =>
                {
                    b.Property<int>("CodServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codServicio");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodServicio"), 1L, 1);

                    b.Property<string>("Descr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
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
                            FechaAlta = new DateTime(2023, 9, 12, 23, 47, 41, 817, DateTimeKind.Local).AddTicks(8794),
                            ValorHora = 0m
                        });
                });

            modelBuilder.Entity("IntegradorSofttekImanol.Entities.Trabajo", b =>
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
                            Costo = 0m,
                            Fecha = new DateTime(2023, 9, 12, 23, 47, 41, 817, DateTimeKind.Local).AddTicks(8885),
                            FechaAlta = new DateTime(2023, 9, 12, 23, 47, 41, 817, DateTimeKind.Local).AddTicks(8888),
                            valorHora = 4m
                        });
                });

            modelBuilder.Entity("IntegradorSofttekImanol.Entities.Usuario", b =>
                {
                    b.Property<int>("CodUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codUsuario");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodUsuario"), 1L, 1);

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
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
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nombre");

                    b.Property<int>("Tipo")
                        .HasColumnType("int")
                        .HasColumnName("tipo");

                    b.HasKey("CodUsuario");

                    b.ToTable("usuarios");

                    b.HasData(
                        new
                        {
                            CodUsuario = 1,
                            Contrasena = "xxxxxxxx",
                            Dni = 39382743,
                            FechaAlta = new DateTime(2023, 9, 12, 23, 47, 41, 817, DateTimeKind.Local).AddTicks(8971),
                            Nombre = "random",
                            Tipo = 0
                        });
                });

            modelBuilder.Entity("IntegradorSofttekImanol.Entities.Trabajo", b =>
                {
                    b.HasOne("IntegradorSofttekImanol.Entities.Proyecto", "Proyecto")
                        .WithMany("Trabajo")
                        .HasForeignKey("CodProyecto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IntegradorSofttekImanol.Entities.Servicio", "Servicio")
                        .WithMany("Trabajo")
                        .HasForeignKey("CodServicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proyecto");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("IntegradorSofttekImanol.Entities.Proyecto", b =>
                {
                    b.Navigation("Trabajo");
                });

            modelBuilder.Entity("IntegradorSofttekImanol.Entities.Servicio", b =>
                {
                    b.Navigation("Trabajo");
                });
#pragma warning restore 612, 618
        }
    }
}
