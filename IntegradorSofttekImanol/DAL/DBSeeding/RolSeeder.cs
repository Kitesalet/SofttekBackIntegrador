using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.DAL.DBSeeding
{
    public class RolSeeder : IEntitySeeder
    {

        /// <summary>
        /// Performs seeding of Rol objects into the database during migration.
        /// </summary>
        /// <param name="modelBuilder">Takes a modelBuilder object to use Fluent API.</param>
        public void SeedDatabase(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Rol>().HasData(
                new Rol
                {
                    codRol = 1,
                    Nombre = "Administrador",
                    Descripcion = "Usuario con derechos maximos",
                    FechaAlta = DateTime.Now

                },
                new Rol
                {
                    codRol = 2,
                    Nombre = "Consultor",
                    Descripcion = "Usuario con derechos basicos"
                }
                );
        }

    }
}
