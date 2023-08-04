using NexignTest.Entity;
using NexignTest.Enums;
using NexignTest.Interfaces;
using NexignTest.Models.Game;
using System.Linq;

namespace NexignTest.Services
{
    public class TurnGameHandler : IHandler<TurnModel>
    {
        private readonly IUnitOfWork _uow;
        private readonly IValidation<TurnModel> _validation;

        public TurnGameHandler(
            IUnitOfWork uow,
            IValidation<TurnModel> validation
            )
        {
            _uow = uow;
            _validation = validation;
        }

        public IUnitOfWork Uow => _uow;
        public IValidation<TurnModel> Validation => _validation;

        public void Handle(TurnModel model)
        {
            Validation.Validate(model);

            var game = Uow.Games.Read(model.GameId);

            bool isOnePlayer = game.PlayerOne == model.UserId;
            
            var roundAllGame = Uow.Rounds.ReadAllRoundByGameId(game.Id);

            if (roundAllGame.Count == 0)
            {
                var newRound = new Round() { GameId = game.Id };
                if (isOnePlayer)
                {
                    newRound.PlayerOneTurn = model.Turn;
                } else
                {
                    newRound.PlayerTwoTurn = model.Turn;
                }
                Uow.Rounds.Add(newRound);
            } else
            {
                var rRight = roundAllGame.Where(x => x.PlayerOneTurn == ETurn.None).OrderBy(x => x.DateTime).ToList();
                var rLeft = roundAllGame.Where(x => x.PlayerTwoTurn == ETurn.None).OrderBy(x => x.DateTime).ToList();

                if (isOnePlayer)
                {
                    if (rRight.Count > rLeft.Count)
                    {
                        var round = rLeft.First();
                        round.PlayerOneTurn = model.Turn;
                        Uow.Rounds.Update(round);
                    } else
                    {
                        Uow.Rounds.Add(new Round()
                        {
                            GameId = game.Id,
                            PlayerOneTurn = model.Turn
                        });
                    }
                } else
                {
                    if (rLeft.Count > rRight.Count)
                    {
                        var round = rRight.First();
                        round.PlayerTwoTurn = model.Turn;
                        Uow.Rounds.Update(round);
                    }
                    else
                    {
                        Uow.Rounds.Add(new Round()
                        {
                            GameId = game.Id,
                            PlayerTwoTurn = model.Turn
                        });
                    }
                }
            }

            var roundCount = Uow.Rounds.CountRoundByGameId(game.Id);
            if (roundCount == 10)
                game.Status = EStatus.Closed;

            Uow.Games.Update(game);
        }
    }
}
