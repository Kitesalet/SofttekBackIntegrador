using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Enums;
using IntegradorSofttekImanol.Models.Interfaces.OtherInterfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.DAL.DBSeeding
{
    /// <summary>
    /// Is the implementation of the interface IEntitySeeder, that seeds Project objects into the database.
    /// </summary>
    public class ProjectSeeder : IEntitySeeder
    {
        /// <summary>
        /// Performs seeding of Project objects into the database during migration.
        /// </summary>
        /// <param name="modelBuilder">Takes a modelBuilder object to use Fluent API.</param>
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    CodProject = 1,
                    Address = "123 Oil Avenue",
                    State = ProjectState.Pendiente,
                    Name = "Oil Rig",
                    CreatedDate = DateTime.Now
                },
                new Project
                {
                    CodProject = 2,
                    Address = "456 Drilling Avenue",
                    State = ProjectState.Confirmado,
                    Name = "Drilling",
                    CreatedDate = DateTime.Now
                },
                new Project
                {
                    CodProject = 3,
                    Address = "789 Refinery Avenuen",
                    State = ProjectState.Terminado,
                    Name = "Refinery",
                    CreatedDate = DateTime.Now
                }
            );
        }
    }
}
