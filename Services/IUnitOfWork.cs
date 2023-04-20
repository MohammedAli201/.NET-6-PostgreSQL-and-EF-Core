namespace PostgresDB.Services
{
    public interface IUnitOfWork
    {
        ITeamRepo Teams { get; }
        Task CompleteAsync();

    }
}