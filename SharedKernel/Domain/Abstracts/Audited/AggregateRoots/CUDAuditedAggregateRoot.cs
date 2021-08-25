using SharedKernel.Domain.Interfaces.Abstracts.Audited.AggregateRoots;
using System;

#nullable enable

namespace SharedKernel.Domain.Abstracts.Audited.AggregateRoots
{
    public abstract class CUDAuditedAggregateRoot : CUAuditedAggregateRoot, ICUDAuditedAggregateRoot
    {
        protected CUDAuditedAggregateRoot() { }

        public bool Deleted { get; private set; }

        public DateTime? DeletedDate { get; private set; }

        public virtual void Delete()
        {
            Deleted = true;
            DeletedDate = DateTime.Now;
        }
    }

    public abstract class CUDAuditedAggregateRoot<TKey> : CUAuditedAggregateRoot<TKey>, ICUDAuditedAggregateRoot<TKey>
    {
        protected CUDAuditedAggregateRoot() { }

        protected CUDAuditedAggregateRoot(TKey id) : base(id) { }

        public bool Deleted { get; private set; }

        public DateTime? DeletedDate { get; private set; }

        public virtual void Delete()
        {
            Deleted = true;
            DeletedDate = DateTime.Now;
        }
    }

    public abstract class CUDUserAuditedAggregateRoot<TUserKey> : CUUserAuditedAggregateRoot<TUserKey>, ICUDUserAuditedAggregateRoot<TUserKey>
    {
        protected CUDUserAuditedAggregateRoot() { }

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

    public abstract class CUDUserAuditedAggregateRoot<TKey, TUserKey> : CUUserAuditedAggregateRoot<TKey, TUserKey>, ICUDUserAuditedAggregateRoot<TKey, TUserKey>
    {
        protected CUDUserAuditedAggregateRoot() { }

        protected CUDUserAuditedAggregateRoot(TKey id) : base(id) { }

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
