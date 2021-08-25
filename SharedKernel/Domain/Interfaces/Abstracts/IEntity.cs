namespace SharedKernel.Domain.Interfaces.Abstracts
{
    public interface IEntity
    {
        public object[] GetKeys();

        string StringifyKeys();
    }

    public interface IEntity<TKey> : IEntity
    {
        public TKey Id { get; }
    }
}
