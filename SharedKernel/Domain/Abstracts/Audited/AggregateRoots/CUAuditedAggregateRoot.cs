using SharedKernel.Domain.Interfaces.Abstracts.Audited.AggregateRoots;
using System;

#nullable enable

namespace SharedKernel.Domain.Abstracts.Audited.AggregateRoots
{
    public abstract class CUAuditedAggregateRoot : CAuditedAggregateRoot, ICUAuditedAggregateRoot
    {
        protected CUAuditedAggregateRoot() { }

        public DateTime? UpdatedDate { get; private set; }

        public virtual void Update()
        {
            UpdatedDate = DateTime.Now;
        }
    }

    public abstract class CUAuditedAggregateRoot<TKey> : CAuditedAggregateRoot<TKey>, ICUAuditedAggregateRoot<TKey>
    {
        protected CUAuditedAggregateRoot() { }

        protected CUAuditedAggregateRoot(TKey id) : base(id) { }

        public DateTime? UpdatedDate { get; private set; }

        public virtual void Update()
        {
            UpdatedDate = DateTime.Now;
        }
    }

    public abstract class CUUserAuditedAggregateRoot<TUserKey> : CUserAuditedAggregateRoot<TUserKey>, ICUUserAuditedAggregateRoot<TUserKey>
    {
        protected CUUserAuditedAggregateRoot() { }

        public DateTime? UpdatedDate { get; private set; }

        public TUserKey? UpdatedBy { get; private set; }

        public void Update(TUserKey? by)
        {
            UpdatedDate = DateTime.Now;
            UpdatedBy = by;
        }

        public virtual void Update()
        {
            UpdatedDate = DateTime.Now;
        }
    }

    public abstract class CUUserAuditedAggregateRoot<TKey, TUserKey> : CUserAuditedAggregateRoot<TKey, TUserKey>, ICUUserAuditedAggregateRoot<TKey, TUserKey>
    {
        protected CUUserAuditedAggregateRoot() { }

        protected CUUserAuditedAggregateRoot(TKey id) : base(id) { }

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
