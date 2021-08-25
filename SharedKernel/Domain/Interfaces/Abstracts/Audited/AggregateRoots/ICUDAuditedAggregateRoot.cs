namespace SharedKernel.Domain.Interfaces.Abstracts.Audited.AggregateRoots
{
    public interface ICUDAuditedAggregateRoot : ICUAuditedAggregateRoot, IHasDeletedDate { }

    public interface ICUDAuditedAggregateRoot<TKey> : ICUAuditedAggregateRoot<TKey>, IHasUpdatedDate { }

    public interface ICUDUserAuditedAggregateRoot<TUserKey> : ICUUserAuditedAggregateRoot<TUserKey>, IHasDeletedDate<TUserKey> { }

    public interface ICUDUserAuditedAggregateRoot<TKey, TUserKey> : ICUUserAuditedAggregateRoot<TKey, TUserKey>, IHasUpdatedDate<TUserKey> { }
}
