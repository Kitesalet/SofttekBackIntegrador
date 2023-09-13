using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.DAL.DBSeeding.Interface
{
    public interface IEntitySeeder
    {

        void SeedDatabase(ModelBuilder modelbuilder);

    }
}
