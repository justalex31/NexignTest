using NexignTest.Interfaces;
using NexignTest.Models.Game;
using System;
using System.Text;

namespace NexignTest.Validation
{
    public class StatModelValidation : IValidation<StatModel>
    {
        public bool Validate(StatModel t)
        {
            var sb = new StringBuilder();

            if (t.GameId == Guid.Empty)
                sb.AppendLine("Заполните gameId");

            if (sb.Length > 0)
                throw new Exception(sb.ToString());

            return true;
        }
    }
}
