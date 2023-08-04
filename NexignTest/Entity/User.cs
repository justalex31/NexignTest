using System;

namespace NexignTest.Entity
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserName { get; set; }
    }
}
