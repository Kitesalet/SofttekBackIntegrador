using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces.OtherInterfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.DAL.DBSeeding
{
    /// <summary>
    /// Is the implementation of the interface IEntitySeeder, that seeds RolSeeder objects into the database.
    /// </summary>
    public class RoleSeeder : IEntitySeeder
    {

        /// <summary>
        /// Performs seeding of Rol objects into the database during migration.
        /// </summary>
        /// <param name="modelBuilder">Takes a modelBuilder object to use Fluent API.</param>
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    CodRole = 1,
                    Name = "Administrador",
                    Description = "Usuario con derechos maximos",
                    CreatedDate = DateTime.Now

                },
                new Role
                {
                    CodRole = 2,
                    Name = "Consultor",
                    Description = "Usuario con derechos basicos"
                }
                );
        }

    }
}
