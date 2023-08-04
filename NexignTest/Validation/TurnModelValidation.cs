using NexignTest.Interfaces;
using NexignTest.Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexignTest.Validation
{
    public class TurnModelValidation : IValidation<TurnModel>
    {
        public bool Validate(TurnModel t)
        {
            var sb = new StringBuilder();

            if (t.GameId == Guid.Empty)
                sb.AppendLine("Заполните gameId");

            if (t.UserId == Guid.Empty)
                sb.AppendLine("Заполните userId");

            if (t.Turn == Enums.ETurn.None)
                sb.AppendLine("Заполните ход");

            if (sb.Length > 0)
                throw new Exception(sb.ToString());

            return true;
        }
    }
}
