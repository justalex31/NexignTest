namespace NexignTest.Interfaces
{
    public interface IValidation<T>
    {
        public bool Validate(T t);
    }
}
