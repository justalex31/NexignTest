using NexignTest.Entity;
using NexignTest.Extensions;
using NexignTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NexignTest.Repositories
{
    public class RoundRepository : IRepositoryExt<Round>
    {
        public static List<Round> RoundList { get; set; }

        static RoundRepository() => RoundList = new List<Round>();

        public Round Add(Round t) => RoundList.AddItem(t);

        public Round Read(Guid id) => RoundList.First(x => x.Id == id);

        public void Remove(Round t) => throw new NotImplementedException();

        public Round Update(Round t) => t;

        public List<Round> ReadAllRoundByGameId(Guid id) => RoundList.Where(x => x.GameId == id).ToList();

        public int CountRoundByGameId(Guid id) => RoundList.Where(x => x.GameId == id).ToList().Count;
    }
}
