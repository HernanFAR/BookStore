using System;

namespace SharedKernel.Domain.Interfaces
{
    public interface IHasUpdatedDate
    {
        DateTime? UpdatedDate { get; }

        void Update();
    }

    public interface IHasUpdatedDate<TUserKey> : IHasUpdatedDate
    {
        TUserKey? UpdatedBy { get; }

        void Update(TUserKey? by);
    }
}
