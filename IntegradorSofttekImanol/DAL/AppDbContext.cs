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


        #region Database tables
        public DbSet<Project> Projects { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        #endregion

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


            base.OnModelCreating(modelBuilder);


        }

    }
}
