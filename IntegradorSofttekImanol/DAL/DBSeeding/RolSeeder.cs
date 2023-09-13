using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.DAL.DBSeeding
{
    public class RolSeeder : IEntitySeeder
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
                    codRol = 1,
                    Descripcion = "xxxxxxxx",
                    FechaAlta = DateTime.Now

                }
                );
        }

    }
}
