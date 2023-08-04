using NexignTest.Entity;

namespace NexignTest.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }
        IRepository<Game> Games { get; }
        IRepositoryExt<Round> Rounds { get; }
    }
}
