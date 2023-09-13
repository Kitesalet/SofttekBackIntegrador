using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.DAL.DBSeeding
{
    public class ServicioSeeder : IEntitySeeder
    {

        /// <summary>
        /// Realiza el seedeo de objetos Servicio en la base de datos al
        /// realizar la migracion
        /// </summary>
        /// <param name="modelbuilder">Toma un objeto modelbuilder para utilizar fluent api</param>
        public void SeedDatabase(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Servicio>().HasData(
                new Servicio
                {
                    CodServicio = 1,
                    Descr = "xxxxxxxx",
                    Estado = true,
                    FechaAlta = DateTime.Now,
                }
                );
        }

    }
}
