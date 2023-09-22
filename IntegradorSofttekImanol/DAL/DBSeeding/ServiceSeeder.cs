using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces.OtherInterfaces;
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
                    Descr = "Maintenance",
                    State = true,
                    CreatedDate = DateTime.Now,
                    HourValue = 100
                },
                new Service
                {
                    CodService = 2,
                    Descr = "Inspection",
                    State = false,
                    CreatedDate = DateTime.Now,
                    HourValue = 120
                },
                new Service
                {
                    CodService = 3,
                    Descr = "Drilling",
                    State = true,
                    CreatedDate = DateTime.Now,
                    HourValue = 150
                },
                new Service
                {
                    CodService = 4,
                    Descr = "Assessment",
                    State = false,
                    CreatedDate = DateTime.Now,
                    HourValue = 200
                },
                new Service
                {
                    CodService = 5,
                    Descr = "Construction",
                    State = true,
                    CreatedDate = DateTime.Now,
                    HourValue = 250
                }
            );
        }

    }
}
