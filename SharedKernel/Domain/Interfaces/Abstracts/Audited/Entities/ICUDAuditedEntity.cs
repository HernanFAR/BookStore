namespace SharedKernel.Domain.Interfaces.Abstracts.Audited.Entities
{
    public interface ICUDAuditedEntity : ICUAuditedEntity, IHasDeletedDate { }

    public interface ICUDAuditedEntity<TKey> : ICUAuditedEntity<TKey>, IHasDeletedDate { }

    public interface ICUDUserAuditedEntity<TUserKey> : ICUUserAuditedEntity<TUserKey>, IHasDeletedDate<TUserKey> { }

    public interface ICUDUserAuditedEntity<TKey, TUserKey> : ICUserAuditedEntity<TKey, TUserKey>, IHasDeletedDate<TUserKey> { }
}
