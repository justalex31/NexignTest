namespace NexignTest.Interfaces
{
    public interface IHandler<T>
    {
        public void Handle(T t);
    }

    public interface IHandler<T, out K>
    {
        public K Handle(T t);
    }
}
