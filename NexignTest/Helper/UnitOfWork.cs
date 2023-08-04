using NexignTest.Entity;
using NexignTest.Interfaces;

namespace NexignTest.Helper
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Game> _gameRepository;
        private readonly IRepositoryExt<Round> _roundRepository;

        public UnitOfWork(
            IRepository<User> userRepository,
            IRepository<Game> gameRepository,
            IRepositoryExt<Round> roundRepository)
        {
            _userRepository = userRepository;
            _gameRepository = gameRepository;
            _roundRepository = roundRepository;
        }

        public IRepository<User> Users => _userRepository;

        public IRepository<Game> Games => _gameRepository;

        public IRepositoryExt<Round> Rounds => _roundRepository;
    }
}
