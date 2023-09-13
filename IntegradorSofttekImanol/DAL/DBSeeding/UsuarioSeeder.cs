using IntegradorSofttekImanol.Helpers;
using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.DAL.DBSeeding
{
    public class UsuarioSeeder : IEntitySeeder
    {

        /// <summary>
        /// Realiza el seedeo de objetos Usuario en la base de datos al
        /// realizar la migracion
        /// </summary>
        /// <param name="modelbuilder">Toma un objeto modelbuilder para utilizar fluent api</param>
        public void SeedDatabase(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    CodUsuario = 1,
                    Contrasena = EncrypterHelper.Encrypter("xxxdsaddsds"),
                    Dni = 39382743,
                    Nombre = "random",
                    FechaAlta = DateTime.Now
                }
                );
        }
    }
}
