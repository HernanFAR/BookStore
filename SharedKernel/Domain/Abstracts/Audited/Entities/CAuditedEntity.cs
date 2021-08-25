using SharedKernel.Domain.Interfaces.Abstracts.Audited.Entities;
using System;

#nullable enable

namespace SharedKernel.Domain.Abstracts.Audited.Entities
{
    public abstract class CAuditedEntity : Entity, ICAuditedEntity
    {
        protected CAuditedEntity() { }

        public DateTime? CreatedDate { get; private set; }

        public virtual void Create()
        {
            CreatedDate = DateTime.Now;
        }
    }

    public abstract class CAuditedEntity<TKey> : Entity<TKey>, ICAuditedEntity<TKey>
    {
        protected CAuditedEntity() { }

        protected CAuditedEntity(TKey id) : base(id) { }

        public DateTime? CreatedDate { get; private set; }

        public virtual void Create()
        {
            CreatedDate = DateTime.Now;
        }
    }

    public abstract class CUserAuditedEntity<TUserKey> : Entity, ICUserAuditedEntity<TUserKey>
    {
        protected CUserAuditedEntity() { }

        public DateTime? CreatedDate { get; private set; }

        public TUserKey? CreatedBy { get; private set; }

        public virtual void Create(TUserKey? by)
        {
            CreatedDate = DateTime.Now;
            CreatedBy = by;
        }

        public virtual void Create()
        {
            CreatedDate = DateTime.Now;
        }
    }

    public abstract class CUserAuditedEntity<TKey, TUserKey> : Entity<TKey>, ICUserAuditedEntity<TKey, TUserKey>
    {
        protected CUserAuditedEntity() { }

        protected CUserAuditedEntity(TKey id) : base(id) { }

        public DateTime? CreatedDate { get; private set; }

        public TUserKey? CreatedBy { get; private set; }

        public virtual void Create(TUserKey? by)
        {
            CreatedDate = DateTime.Now;
            CreatedBy = by;
        }

        public virtual void Create()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
