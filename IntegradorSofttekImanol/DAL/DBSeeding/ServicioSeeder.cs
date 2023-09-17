using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.DAL.DBSeeding
{
    public class ServicioSeeder : IEntitySeeder
    {

        /// <summary>
        /// Performs seeding of Servicio objects into the database during migration.
        /// </summary>
        /// <param name="modelBuilder">Takes a modelBuilder object to use Fluent API.</param>
        public void SeedDatabase(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Servicio>().HasData(
                new Servicio
                {
                    CodServicio = 1,
                    Descr = "xxxxxxxx",
                    Estado = true,
                    FechaAlta = DateTime.Now,
                }
                );
        }

    }
}
