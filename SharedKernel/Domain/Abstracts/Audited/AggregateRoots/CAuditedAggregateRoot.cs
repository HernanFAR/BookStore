using SharedKernel.Domain.Interfaces.Abstracts.Audited.AggregateRoots;
using System;

#nullable enable

namespace SharedKernel.Domain.Abstracts.Audited.AggregateRoots
{
    public abstract class CAuditedAggregateRoot : AggregateRoot, ICAuditedAggregateRoot
    {
        protected CAuditedAggregateRoot() { }

        public DateTime? CreatedDate { get; private set; }

        public virtual void Create()
        {
            CreatedDate = DateTime.Now;
        }
    }

    public abstract class CAuditedAggregateRoot<TKey> : AggregateRoot<TKey>, ICAuditedAggregateRoot<TKey>
    {
        protected CAuditedAggregateRoot() { }

        protected CAuditedAggregateRoot(TKey id) : base(id) { }

        public DateTime? CreatedDate { get; private set; }

        public virtual void Create()
        {
            CreatedDate = DateTime.Now;
        }
    }

    public abstract class CUserAuditedAggregateRoot<TUserKey> : AggregateRoot, ICUserAuditedAggregateRoot<TUserKey>
    {
        protected CUserAuditedAggregateRoot() { }

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

    public abstract class CUserAuditedAggregateRoot<TKey, TUserKey> : AggregateRoot<TKey>, ICUserAuditedAggregateRoot<TKey, TUserKey>
    {
        protected CUserAuditedAggregateRoot() { }

        protected CUserAuditedAggregateRoot(TKey id) : base(id) { }

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
