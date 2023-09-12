using IntegradorSofttekImanol.Entities;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.DAL
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {



        }


        //Tablas en la base de datos
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Trabajo> Trabajos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }



    }
}
