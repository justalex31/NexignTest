using NexignTest.Entity;
using NexignTest.Extensions;
using NexignTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NexignTest.Repositories
{
    public class GameRepository : IRepository<Game>
    {
        public static List<Game> GameList { get; set; }

        static GameRepository() => GameList = new List<Game>();

        public Game Add(Game t) => GameList.AddItem(t);

        public void Remove(Game t) => throw new NotImplementedException();

        public Game Update(Game t) => t;

        public Game Read(Guid id) => GameList.FirstOrDefault(x => x.Id == id) ?? throw new Exception("Не существует записи по такому ИД");
    }
}
