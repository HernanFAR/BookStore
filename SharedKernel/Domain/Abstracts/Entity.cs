using SharedKernel.Domain.Interfaces.Abstracts;

namespace SharedKernel.Domain.Abstracts
{
    public abstract class Entity : IEntity
    {
        protected Entity() { }

        public override string ToString()
        {
            return $"[Entity name: {GetType().Name}] | Keys = {WriteKeys()}]";
        }

        public abstract object[] GetKeys();

        public abstract string StringifyKeys();

        private string WriteKeys()
        {
            return string.Join(", ", GetKeys());
        }

        public bool EntityEquals(Entity other)
        {
            if (other == null || this == null)
            {
                return false;
            }

            //Same instances must be considered as equal
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            //Must have a IS-A relation of types or must be same type
            var typeOfEntity1 = GetType();
            var typeOfEntity2 = other.GetType();

            if (!typeOfEntity1.IsAssignableFrom(typeOfEntity2) && !typeOfEntity2.IsAssignableFrom(typeOfEntity1))
            {
                return false;
            }

            var entity1Keys = GetKeys();
            var entity2Keys = other.GetKeys();

            if (entity1Keys.Length != entity2Keys.Length)
            {
                return false;
            }

            for (var i = 0; i < entity1Keys.Length; i++)
            {
                var entity1Key = entity1Keys[i];
                var entity2Key = entity2Keys[i];

                if (entity1Key == null)
                {
                    if (entity2Key == null)
                    {
                        //Both null, so considered as equals
                        continue;
                    }

                    //entity2Key is not null!
                    return false;
                }

                if (entity2Key == null)
                {
                    //entity1Key was not null!
                    return false;
                }


                if (!entity1Key.Equals(entity2Key))
                {
                    return false;
                }
            }

            return true;
        }
    }

    public abstract class Entity<TKey> : Entity, IEntity<TKey>
    {
        public TKey Id { get; private set; }

        protected Entity() { }

        protected Entity(TKey id)
        {
            Id = id;
        }

        public override string StringifyKeys()
        {
            return Id.ToString();
        }

        public override object[] GetKeys()
        {
            return new object[] { Id };
        }

        public override string ToString()
        {
            return $"[Entity name: {GetType().Name}] | Id = {Id}]";
        }
    }
}
