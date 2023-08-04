using NexignTest.Entity;
using NexignTest.Interfaces;
using NexignTest.Models.Game;

namespace NexignTest.Services
{
    public class JoinGameHandler : IHandler<JoinModel>
    {
        private readonly IUnitOfWork _uow;
        private readonly IValidation<JoinModel> _validation;

        public JoinGameHandler(
            IUnitOfWork uow,
            IValidation<JoinModel> validation
            )
        {
            _uow = uow;
            _validation = validation;
        }

        public IUnitOfWork Uow => _uow;
        public IValidation<JoinModel> Validation => _validation;

        public void Handle(JoinModel model)
        {
            Validation.Validate(model);

            var user = Uow.Users.Add(
                new User()
                {
                    UserName = model.UserName
                });

            var game = Uow.Games.Read(model.GameId);
            game.PlayerTwo = user.Id;
            Uow.Games.Update(game);
        }
    }
}
