namespace SharedKernel.Domain.Interfaces.Abstracts.Audited.Entities
{
    public interface ICAuditedEntity : IEntity, IHasCreatedDate { }

    public interface ICAuditedEntity<TKey> : IEntity<TKey>, IHasCreatedDate { }

    public interface ICUserAuditedEntity<TUserKey> : IEntity, IHasCreatedDate<TUserKey> { }

    public interface ICUserAuditedEntity<TKey, TUserKey> : IEntity<TKey>, IHasCreatedDate<TUserKey> { }
}
