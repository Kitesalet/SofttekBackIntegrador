using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces;
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
                    Address = "xxxxxxxx",
                    State = (ProjectState)2,
                    Name = "random",
                    CreatedDate = DateTime.Now
                },
                new Project
                {
                    CodProject = 2,
                    Address = "xxxxxxxx",
                    State = ProjectState.Pendiente,
                    Name = "random",
                    CreatedDate = DateTime.Now
                }
                );
        }
    }
}
