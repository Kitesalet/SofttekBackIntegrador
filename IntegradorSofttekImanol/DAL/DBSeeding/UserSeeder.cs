using IntegradorSofttekImanol.Helpers;
using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.DAL.DBSeeding
{
    /// <summary>
    /// Is the implementation of the interface IEntitySeeder, that seeds User objects into the database
    /// </summary>
    public class UserSeeder : IEntitySeeder
    {

        /// <summary>
        /// Performs seeding of User objects into the database during migration.
        /// </summary>
        /// <param name="modelBuilder">Takes a modelBuilder object to use Fluent API.</param>
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    CodUser = 1,
                    Password = EncrypterHelper.Encrypter("random", "RaNdOmCoDe"),
                    Dni = 39321874,
                    Name = "random",
                    Type = 1,
                    CreatedDate = DateTime.Now
                }, new User
                {
                    CodUser = 2,
                    Password = EncrypterHelper.Encrypter("random", "RaNdOmCoDe"),
                    Dni = 39382743,
                    Name = "randoms",
                    Type = 2,
                    CreatedDate = DateTime.Now
                }, new User
                {
                    CodUser = 3,
                    Password = EncrypterHelper.Encrypter("xxxdsaddsds", "RaNdOmCoDe"),
                    Dni = 39382743,
                    Name = "randomdd",
                    Type = 2,
                    CreatedDate = DateTime.Now
                }
                );
        }
    }
}
