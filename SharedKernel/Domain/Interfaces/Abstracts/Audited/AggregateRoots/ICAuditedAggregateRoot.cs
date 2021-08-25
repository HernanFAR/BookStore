namespace SharedKernel.Domain.Interfaces.Abstracts.Audited.AggregateRoots
{
    public interface ICAuditedAggregateRoot : IEntity, IHasCreatedDate { }

    public interface ICAuditedAggregateRoot<TKey> : IEntity<TKey>, IHasCreatedDate { }

    public interface ICUserAuditedAggregateRoot<TUserKey> : IEntity, IHasCreatedDate<TUserKey> { }

    public interface ICUserAuditedAggregateRoot<TKey, TUserKey> : IEntity<TKey>, IHasCreatedDate<TUserKey> { }
}
