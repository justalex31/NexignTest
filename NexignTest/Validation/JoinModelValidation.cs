using NexignTest.Interfaces;
using NexignTest.Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexignTest.Validation
{
    public class JoinModelValidation : IValidation<JoinModel>
    {
        public bool Validate(JoinModel t)
        {
            var sb = new StringBuilder();

            if (string.IsNullOrEmpty(t.UserName))
                sb.AppendLine("Заполните Username");

            if (t.GameId == Guid.Empty)
                sb.AppendLine("Заполните gameId");

            if (sb.Length > 0)
                throw new Exception(sb.ToString());

            return true;
        }
    }
}
