using Microsoft.AspNetCore.Mvc;
using NexignTest.Enums;
using System;

namespace NexignTest.Models.Game
{
    public class TurnModel : StatModel
    {
        [FromRoute(Name = "userId")]
        public Guid UserId { get; set; }
        [FromRoute(Name = "turn")]
        public ETurn Turn { get; set; }
    }
}
