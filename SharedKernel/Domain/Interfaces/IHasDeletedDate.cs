using System;

namespace SharedKernel.Domain.Interfaces
{
    public interface IHasDeletedDate
    {
        bool Deleted { get; }

        DateTime? DeletedDate { get; }

        void Delete();
    }

    public interface IHasDeletedDate<TUserKey> : IHasDeletedDate
    {

        TUserKey? DeletedBy { get; }

        void Delete(TUserKey? by);
    }
}
