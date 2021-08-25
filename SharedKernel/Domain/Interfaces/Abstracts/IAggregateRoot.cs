using System.Collections.Generic;

namespace SharedKernel.Domain.Interfaces.Abstracts
{
    public interface IAggregateRoot : IEntity
    {
        IEnumerable<object> GetEvents();

        void AddEvent(object eventData);

        void ClearEvents();

        void Validate();
    }

    public interface IAggregateRoot<TKey> : IAggregateRoot, IEntity<TKey> { }
}
