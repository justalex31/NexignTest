using System;
using System.Collections.Generic;

namespace NexignTest.Interfaces
{
    public interface IRepository<T>
    {
        public T Add(T t);
        public T Read(Guid id);
        public T Update(T t);
        public void Remove(T t);
    }

    public interface IRepositoryExt<T> : IRepository<T>
    {
        public List<T> ReadAllRoundByGameId(Guid id);
        public int CountRoundByGameId(Guid id);
    }
}
