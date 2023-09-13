using IntegradorSofttekImanol.DAL.DBSeeding.Interface;
using IntegradorSofttekImanol.Entities;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.DAL.DBSeeding
{
    public class ProyectoSeeder : IEntitySeeder
    {
        /// <summary>
        /// Realiza el seedeo de objetos Proyecto en la base de datos al
        /// realizar la migracion
        /// </summary>
        /// <param name="modelbuilder">Toma un objeto modelbuilder para utilizar fluent api</param>
        public void SeedDatabase(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Proyecto>().HasData(
                new Proyecto
                {
                    CodProyecto = 1,
                    Direccion = "xxxxxxxx",
                    Estado = 2,
                    Nombre = "random",
                    FechaAlta = DateTime.Now
                }
                );
        }
    }
}
