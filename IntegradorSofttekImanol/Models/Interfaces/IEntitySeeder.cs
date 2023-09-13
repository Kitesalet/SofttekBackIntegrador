using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.Models.Interfaces
{
    public interface IEntitySeeder
    {

        void SeedDatabase(ModelBuilder modelbuilder);

    }
}
