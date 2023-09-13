namespace IntegradorSofttekImanol.Services.Interfaces
{
    public interface IUnitOfWork
    {



        Task<int> Complete();

    }
}
