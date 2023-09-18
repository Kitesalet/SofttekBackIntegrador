using IntegradorSofttekImanol.Helpers;
using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.DAL.DBSeeding
{
    /// <summary>
    /// Is the implementation of the interface IEntitySeeder, that seeds Usuario objects into the database
    /// </summary>
    public class UsuarioSeeder : IEntitySeeder
    {

        /// <summary>
        /// Performs seeding of Usuario objects into the database during migration.
        /// </summary>
        /// <param name="modelBuilder">Takes a modelBuilder object to use Fluent API.</param>
        public void SeedDatabase(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    CodUsuario = 1,
                    Contrasena = EncrypterHelper.Encrypter("random","d"),
                    Dni = 39321874,
                    Nombre = "random",
                    Tipo = 1,
                    FechaAlta = DateTime.Now
                }, new Usuario
                {
                    CodUsuario = 2,
                    Contrasena = EncrypterHelper.Encrypter("xxxdsaddsds","d"),
                    Dni = 39382743,
                    Nombre = "randoms",
                    Tipo = 2,
                    FechaAlta = DateTime.Now
                }, new Usuario
                {
                    CodUsuario = 3,
                    Contrasena = EncrypterHelper.Encrypter("xxxdsaddsds", "d"),
                    Dni = 39382743,
                    Nombre = "randomdd",
                    Tipo = 2,
                    FechaAlta = DateTime.Now
                }
                );
        }
    }
}
