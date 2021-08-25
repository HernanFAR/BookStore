using SharedKernel.Domain.Interfaces.Abstracts.Audited.Entities;
using System;

#nullable enable

namespace SharedKernel.Domain.Abstracts.Audited.Entities
{
    public abstract class CUDAuditedEntity : CUAuditedEntity, ICUDAuditedEntity
    {
        protected CUDAuditedEntity() { }

        public bool Deleted { get; private set; }

        public DateTime? DeletedDate { get; private set; }

        public virtual void Delete()
        {
            Deleted = true;
            DeletedDate = DateTime.Now;
        }
    }

    public abstract class CUDAuditedEntity<TKey> : CUAuditedEntity<TKey>, ICUDAuditedEntity<TKey>
    {
        protected CUDAuditedEntity() { }

        protected CUDAuditedEntity(TKey id) : base(id) { }

        public bool Deleted { get; private set; }

        public DateTime? DeletedDate { get; private set; }

        public virtual void Delete()
        {
            Deleted = true;
            DeletedDate = DateTime.Now;
        }
    }

    public abstract class CUDUserAuditedEntity<TUserKey> : CUUserAuditedEntity<TUserKey>, ICUDUserAuditedEntity<TUserKey>
    {
        protected CUDUserAuditedEntity() { }

        public bool Deleted { get; private set; }

        public DateTime? DeletedDate { get; private set; }

        public TUserKey? DeletedBy { get; private set; }

        public virtual void Delete(TUserKey? by)
        {
            Deleted = true;
            DeletedDate = DateTime.Now;
            DeletedBy = by;
        }

        public virtual void Delete()
        {
            Deleted = true;
            DeletedDate = DateTime.Now;
        }
    }

    public abstract class CUDUserAuditedEntity<TKey, TUserKey> : CUUserAuditedEntity<TKey, TUserKey>, ICUDUserAuditedEntity<TKey, TUserKey>
    {
        protected CUDUserAuditedEntity() { }

        protected CUDUserAuditedEntity(TKey id) : base(id) { }

        public bool Deleted { get; private set; }

        public DateTime? DeletedDate { get; private set; }

        public TUserKey? DeletedBy { get; private set; }

        public virtual void Delete(TUserKey? by)
        {
            Deleted = true;
            DeletedDate = DateTime.Now;
            DeletedBy = by;
        }

        public virtual void Delete()
        {
            Deleted = true;
            DeletedDate = DateTime.Now;
        }
    }
}
