namespace SharedKernel.Domain.Interfaces.Abstracts.Audited.Entities
{
    public interface ICUAuditedEntity : ICAuditedEntity, IHasUpdatedDate { }

    public interface ICUAuditedEntity<TKey> : ICAuditedEntity<TKey>, IHasUpdatedDate { }

    public interface ICUUserAuditedEntity<TUserKey> : ICUserAuditedEntity<TUserKey>, IHasUpdatedDate<TUserKey> { }

    public interface ICUUserAuditedEntity<TKey, TUserKey> : ICUserAuditedEntity<TKey, TUserKey>, IHasUpdatedDate<TUserKey> { }
}
