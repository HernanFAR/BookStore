using SharedKernel.Domain.Interfaces.Abstracts.Audited.Entities;
using System;

#nullable enable

namespace SharedKernel.Domain.Abstracts.Audited.Entities
{
    public abstract class CUAuditedEntity : CAuditedEntity, ICUAuditedEntity
    {
        protected CUAuditedEntity() { }

        public DateTime? UpdatedDate { get; private set; }

        public virtual void Update()
        {
            UpdatedDate = DateTime.Now;
        }
    }

    public abstract class CUAuditedEntity<TKey> : CAuditedEntity<TKey>, ICUAuditedEntity<TKey>
    {
        protected CUAuditedEntity() { }

        protected CUAuditedEntity(TKey id) : base(id) { }

        public DateTime? UpdatedDate { get; private set; }

        public virtual void Update()
        {
            UpdatedDate = DateTime.Now;
        }
    }

    public abstract class CUUserAuditedEntity<TUserKey> : CUserAuditedEntity<TUserKey>, ICUUserAuditedEntity<TUserKey>
    {
        protected CUUserAuditedEntity() { }

        public DateTime? UpdatedDate { get; private set; }

        public TUserKey? UpdatedBy { get; private set; }

        public virtual void Update(TUserKey? by)
        {
            UpdatedDate = DateTime.Now;
            UpdatedBy = by;
        }

        public virtual void Update()
        {
            UpdatedDate = DateTime.Now;
        }
    }

    public abstract class CUUserAuditedEntity<TKey, TUserKey> : CUserAuditedEntity<TKey, TUserKey>, ICUUserAuditedEntity<TKey, TUserKey>
    {
        protected CUUserAuditedEntity() { }

        protected CUUserAuditedEntity(TKey id) : base(id) { }

        public DateTime? UpdatedDate { get; private set; }

        public TUserKey? UpdatedBy { get; private set; }

        public virtual void Update(TUserKey? by)
        {
            UpdatedDate = DateTime.Now;
            UpdatedBy = by;
        }

        public virtual void Update()
        {
            UpdatedDate = DateTime.Now;
        }
    }
}
