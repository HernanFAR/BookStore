using System;

namespace SharedKernel.Domain.Interfaces
{
    public interface IHasCreatedDate
    {
        DateTime? CreatedDate { get; }

        void Create();
    }

    public interface IHasCreatedDate<TUserKey> : IHasCreatedDate
    {
        TUserKey? CreatedBy { get; }

        void Create(TUserKey? by);
    }
}
