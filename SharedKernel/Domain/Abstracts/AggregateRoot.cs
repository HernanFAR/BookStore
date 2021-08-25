using SharedKernel.Domain.Interfaces.Abstracts;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SharedKernel.Domain.Abstracts
{
    public abstract class AggregateRoot : Entity, IAggregateRoot
    {
        protected AggregateRoot() { }

        private readonly ICollection<object> _Events = new Collection<object>();

        public IEnumerable<object> GetEvents()
        {
            return _Events;
        }

        public void AddEvent(object eventData)
        {
            _Events.Add(eventData);
        }

        public void ClearEvents()
        {
            _Events.Clear();
        }

        public abstract Task ValidateAsync();
    }

    public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot<TKey>
    {
        protected AggregateRoot() { }

        protected AggregateRoot(TKey id) : base(id) { }

        private readonly ICollection<object> _Events = new Collection<object>();

        public IEnumerable<object> GetEvents()
        {
            return _Events;
        }

        public void AddEvent(object eventData)
        {
            _Events.Add(eventData);
        }

        public void ClearEvents()
        {
            _Events.Clear();
        }

        public abstract Task ValidateAsync();
    }
}
