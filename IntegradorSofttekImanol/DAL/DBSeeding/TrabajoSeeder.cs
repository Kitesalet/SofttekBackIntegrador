using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.DAL.DBSeeding
{
    /// <summary>
    /// Is the implementation of the interface IEntitySeeder, that seeds Trabajo objects into the database
    /// </summary>
    public class TrabajoSeeder : IEntitySeeder
    {
        /// <summary>
        /// Performs seeding of Trabajo objects into the database during migration.
        /// </summary>
        /// <param name="modelBuilder">Takes a modelBuilder object to use Fluent API.</param>
        public void SeedDatabase(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Trabajo>().HasData(
                new Trabajo
                {
                    CodTrabajo = 1,
                    Fecha = DateTime.Now,
                    CantHoras = 2,
                    CodProyecto = 1,
                    CodServicio = 1,
                    valorHora = 4,
                    FechaAlta = DateTime.Now
                }
                );
        }

    }
}
