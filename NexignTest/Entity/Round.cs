using NexignTest.Enums;
using System;

namespace NexignTest.Entity
{
    public class Round
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DateTime { get; set; } = DateTime.Now;
        public ETurn PlayerOneTurn { get; set; } = ETurn.None;
        public ETurn PlayerTwoTurn { get; set; } = ETurn.None;
        public Guid GameId { get; set; }
    }
}
