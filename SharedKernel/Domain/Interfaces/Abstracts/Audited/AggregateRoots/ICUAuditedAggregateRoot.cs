namespace SharedKernel.Domain.Interfaces.Abstracts.Audited.AggregateRoots
{
    public interface ICUAuditedAggregateRoot : ICAuditedAggregateRoot, IHasUpdatedDate { }

    public interface ICUAuditedAggregateRoot<TKey> : ICAuditedAggregateRoot<TKey>, IHasUpdatedDate { }

    public interface ICUUserAuditedAggregateRoot<TUserKey> : ICUserAuditedAggregateRoot<TUserKey>, IHasUpdatedDate<TUserKey> { }

    public interface ICUUserAuditedAggregateRoot<TKey, TUserKey> : ICUserAuditedAggregateRoot<TKey, TUserKey>, IHasUpdatedDate<TUserKey> { }
}
