using IntegradorSofttekImanol.DAL.DBSeeding;
using IntegradorSofttekImanol.DAL.DBSeeding.Interface;
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
             * Seedeo de las entidades a la DB
             */

            var seeder = new List<IEntitySeeder>()
            {         
                new ProyectoSeeder(),
                new ServicioSeeder(),
                new TrabajoSeeder(),
                new UsuarioSeeder(),
            };

            foreach(var seed in seeder)
            {
                seed.SeedDatabase(modelBuilder);
            }


            /*
            //Setteo de las relaciones entre entidades
           

            //Se settea la relacion one to many entre las entidades Trabajo - Proyecto
            modelBuilder.Entity<Trabajo>()
                .HasOne(e => e.Proyecto)
                .WithMany(e => e.Trabajo)
                .HasForeignKey("CodTrabajo");

            //Se settea la relacion one to many entre las entidades Trabajo - Proyecto
            modelBuilder.Entity<Trabajo>()
                .HasOne(e => e.Servicio)
                .WithMany(e => e.Trabajo)
                .HasForeignKey("CodServicio");

             */

            /*
             * Setteo de las propiedades de las entidades
             */

            /*
             
            //Se settean las PKs de las entidades
            
            modelBuilder.Entity<Usuario>().HasKey(e => e.CodUsuario);
            modelBuilder.Entity<Proyecto>().HasKey(e => e.CodProyecto);
            modelBuilder.Entity<Trabajo>().HasKey(e => e.CodTrabajo);
            modelBuilder.Entity<Servicio>().HasKey(e => e.CodServicio);

            */

            //Se settea y se arregla el problema del decimal

            modelBuilder.Entity<Servicio>()
                 .Property(e => e.ValorHora)
                 .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Trabajo>()
                .Property(e => e.valorHora)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Trabajo>()
                .Property(e => e.Costo)
                .HasColumnType("decimal(18, 2)");

            base.OnModelCreating(modelBuilder);


        }

    }
}
