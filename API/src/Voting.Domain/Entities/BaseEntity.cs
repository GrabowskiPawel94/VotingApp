namespace Voting.Domain.Entities
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; private set; }

        protected BaseEntity()
        {
        }
    }
}
