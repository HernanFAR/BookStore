using System;
using System.Threading;
using System.Threading.Tasks;

namespace SharedKernel.Application.DataAccess.Interfaces
{
    public interface IUnitOfWork<TUnitOfWork>
        where TUnitOfWork : IUnitOfWork<TUnitOfWork>
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default);

        Task CommitAsync(CancellationToken cancellationToken = default);

        Task RollbackAsync(CancellationToken cancellationToken = default);

        Task CreateTransactionAsync(CancellationToken cancellationToken = default);

        Task FinishTransactionAsync(CancellationToken cancellationToken = default);

        Task UseTransactionAsync(Func<TUnitOfWork, CancellationToken, Task> action, CancellationToken cancellationToken = default);

        Task<T> UseTransactionAsync<T>(Func<TUnitOfWork, CancellationToken, Task<T>> action, CancellationToken cancellationToken = default);
    }
}
