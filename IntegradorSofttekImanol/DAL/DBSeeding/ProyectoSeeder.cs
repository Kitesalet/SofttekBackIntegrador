using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.DAL.DBSeeding
{
    public class ProyectoSeeder : IEntitySeeder
    {
        /// <summary>
        /// Performs seeding of Proyecto objects into the database during migration.
        /// </summary>
        /// <param name="modelBuilder">Takes a modelBuilder object to use Fluent API.</param>
        public void SeedDatabase(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Proyecto>().HasData(
                new Proyecto
                {
                    CodProyecto = 1,
                    Direccion = "xxxxxxxx",
                    Estado = (Estado)2,
                    Nombre = "random",
                    FechaAlta = DateTime.Now
                },
                new Proyecto
                {
                    CodProyecto = 2,
                    Direccion = "xxxxxxxx",
                    Estado = Estado.Pendiente,
                    Nombre = "random",
                    FechaAlta = DateTime.Now
                }
                );
        }
    }
}
