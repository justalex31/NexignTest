using NexignTest.Entity;
using NexignTest.Interfaces;
using NexignTest.Models.Game;

namespace NexignTest.Services
{
    public class CreateGameHandler : IHandler<CreateModel>
    {
        private readonly IUnitOfWork _uow;
        private readonly IValidation<CreateModel> _validation;

        public CreateGameHandler(
            IUnitOfWork uow,
            IValidation<CreateModel> validation
            )
        {
            _uow = uow;
            _validation = validation;
        }

        public IUnitOfWork Uow => _uow;
        public IValidation<CreateModel> Validation => _validation;

        public void Handle(CreateModel model)
        {
            Validation.Validate(model);

            var user = Uow.Users.Add(
                new User() {
                    UserName = model.UserName 
                });

            Uow.Games.Add(
                new Game()
                {
                    PlayerOne = user.Id
                });
        }
    }
}
