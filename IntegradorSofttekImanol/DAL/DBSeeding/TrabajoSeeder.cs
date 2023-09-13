using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.DAL.DBSeeding
{
    public class TrabajoSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Trabajo>().HasData(
                new Trabajo
                {
                    CodTrabajo = 1,
                    Fecha = DateTime.Now,
                    CantHoras = 2,
                    CodProyecto = 1,
                    CodServicio = 1,
                    valorHora = 4,
                    FechaAlta = DateTime.Now
                }
                );
        }

    }
}
