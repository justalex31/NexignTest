using NexignTest.Enums;
using System;

namespace NexignTest.Entity
{
    public class Game
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PlayerOne { get; set; }
        public Guid PlayerTwo { get; set; }
        public EStatus Status { get; set; } = EStatus.Opened;
    }
}
