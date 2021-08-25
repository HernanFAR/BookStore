using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharedKernel.Domain.Interfaces.Abstracts
{
    public interface IAggregateRoot : IEntity
    {
        IEnumerable<object> GetEvents();

        void AddEvent(object eventData);

        void ClearEvents();

        Task Validate();
    }

    public interface IAggregateRoot<TKey> : IAggregateRoot, IEntity<TKey> { }
}
