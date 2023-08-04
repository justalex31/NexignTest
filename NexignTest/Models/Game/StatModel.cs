using Microsoft.AspNetCore.Mvc;
using System;

namespace NexignTest.Models.Game
{
    public class StatModel
    {
        [FromRoute(Name = "gameId")]
        public Guid GameId { get; set; }
    }
}
