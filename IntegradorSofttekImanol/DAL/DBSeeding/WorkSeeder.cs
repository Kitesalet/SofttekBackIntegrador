using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces.OtherInterfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.DAL.DBSeeding
{
    /// <summary>
    /// Is the implementation of the interface IEntitySeeder, that seeds Work objects into the database.
    /// </summary>
    public class WorkSeeder : IEntitySeeder
    {
        /// <summary>
        /// Performs seeding of Work objects into the database during migration.
        /// </summary>
        /// <param name="modelBuilder">Takes a modelBuilder object to use Fluent API.</param>
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Work>().HasData(
                new Work
                {
                    CodWork = 1,
                    Date = DateTime.Now,
                    HourQty = 2,
                    CodProject = 1,
                    CodService = 1,
                    HourValue = 4,
                    CreatedDate = DateTime.Now
                }
                );
        }

    }
}
