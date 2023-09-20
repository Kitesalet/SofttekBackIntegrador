using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.DAL.DBSeeding
{
    /// <summary>
    /// Is the implementation of the interface IEntitySeeder, that seeds Service objects into the database.
    /// </summary>
    public class ServiceSeeder : IEntitySeeder
    {

        /// <summary>
        /// Performs seeding of Service objects into the database during migration.
        /// </summary>
        /// <param name="modelBuilder">Takes a modelBuilder object to use Fluent API.</param>
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>().HasData(
                new Service
                {
                    CodService = 1,
                    Descr = "xxxxxxxx",
                    State = true,
                    CreatedDate = DateTime.Now,
                    HourValue = 100
                }
                );
        }

    }
}
