using NexignTest.Interfaces;
using NexignTest.Models.Game;
using System;
using System.Text;

namespace NexignTest.Validation
{
    public class CreateModelValidation : IValidation<CreateModel>
    {
        public bool Validate(CreateModel t)
        {
            var sb = new StringBuilder();

            if (string.IsNullOrEmpty(t.UserName))
                sb.AppendLine("Заполните Username");

            if (sb.Length > 0)
                throw new Exception(sb.ToString());

            return true;
        }
    }
}
