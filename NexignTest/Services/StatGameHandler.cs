using NexignTest.Interfaces;
using NexignTest.Models;
using NexignTest.Models.Game;
using System.Text.Json;

namespace NexignTest.Services
{
    public class StatGameHandler : IHandler<StatModel, HttpResult>
    {
        private readonly IUnitOfWork _uow;
        private readonly IValidation<StatModel> _validation;

        public StatGameHandler(
            IUnitOfWork uow,
            IValidation<StatModel> validation
            )
        {
            _uow = uow;
            _validation = validation;
        }

        public IUnitOfWork Uow => _uow;
        public IValidation<StatModel> Validation => _validation;

        public HttpResult Handle(StatModel model)
        {
            Validation.Validate(model);

            var game = Uow.Games.Read(model.GameId);

            var result = new HttpResult();
            var roundList = Uow.Rounds.ReadAllRoundByGameId(game.Id);

            result.Message = JsonSerializer.Serialize(roundList);

            return result;
        }
    }
}
