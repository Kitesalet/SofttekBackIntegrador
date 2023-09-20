using IntegradorSofttekImanol.DAL.DBSeeding;
using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.DAL
{
    /// <summary>
    /// Represents the application's database context that manages database tables.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Initializes an instance of AppDbContext.
        /// </summary>
        /// <param name="options">A DbContextOptions.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {



        }


        //Database tables
        public DbSet<Project> Projects { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
      
            #region Seeding config

            var seeder = new List<IEntitySeeder>()
            {
                new ProjectSeeder(),
                new ServiceSeeder(),
                new WorkSeeder(),
                new UserSeeder(),
                new RoleSeeder()
            };

            foreach(var seed in seeder)
            {
                seed.SeedDatabase(modelBuilder);
            }

            #endregion

            #region Unused Fluent Api relationship settings
            /*        

            modelBuilder.Entity<Trabajo>()
                .HasOne(e => e.Proyecto)
                .WithMany(e => e.Trabajo)
                .HasForeignKey("CodTrabajo");

            modelBuilder.Entity<Trabajo>()
                .HasOne(e => e.Servicio)
                .WithMany(e => e.Trabajo)
                .HasForeignKey("CodServicio");

             */

            /*
                         
            modelBuilder.Entity<Usuario>().HasKey(e => e.CodUsuario);
            modelBuilder.Entity<Proyecto>().HasKey(e => e.CodProyecto);
            modelBuilder.Entity<Trabajo>().HasKey(e => e.CodTrabajo);
            modelBuilder.Entity<Servicio>().HasKey(e => e.CodServicio);

            */
            #endregion

            #region Fluent Api Property Config

            modelBuilder.Entity<Service>()
                 .Property(e => e.ValorHora)
                 .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Work>()
                .Property(e => e.valorHora)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Work>()
                .Property(e => e.Costo)
                .HasColumnType("decimal(18, 2)");

            #endregion

            base.OnModelCreating(modelBuilder);


        }

    }
}
