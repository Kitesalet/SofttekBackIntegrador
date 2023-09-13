using IntegradorSofttekImanol.DAL.DBSeeding.Interface;
using IntegradorSofttekImanol.Entities;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.DAL.DBSeeding
{
    public class RoleSeeder : IEntitySeeder
    {

        /// <summary>
        /// Realiza el seedeo de objetos Role en la base de datos al
        /// realizar la migracion
        /// </summary>
        /// <param name="modelbuilder">Toma un objeto modelbuilder para utilizar fluent api</param>
        public void SeedDatabase(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Rol>().HasData(
                new Rol
                {
                    Id = 1,
                    Description = "xxxxxxxx",
                    Activo = true

                }
                );
        }

    }
}
