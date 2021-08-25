using SharedKernel.Application.DataAccess.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SharedKernel.Application.DataAccess.Abstracts
{
    public abstract class CacheDecoratorUnitOfWork<TUnitOfWork> : IUnitOfWork<TUnitOfWork>
        where TUnitOfWork : class, IUnitOfWork<TUnitOfWork>
    {
        private readonly IUnitOfWork<TUnitOfWork> _DataAccess;

        protected CacheDecoratorUnitOfWork(IUnitOfWork<TUnitOfWork> dataAccess)
        {
            _DataAccess = dataAccess;
        }

        public Task CommitAsync(CancellationToken cancellationToken = default)
            => _DataAccess.CommitAsync(cancellationToken);

        public Task CreateTransactionAsync(CancellationToken cancellationToken = default)
            => _DataAccess.CreateTransactionAsync(cancellationToken);

        public Task FinishTransactionAsync(CancellationToken cancellationToken = default)
            => _DataAccess.FinishTransactionAsync(cancellationToken);

        public Task RollbackAsync(CancellationToken cancellationToken = default)
            => _DataAccess.RollbackAsync(cancellationToken);

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await ClearCaches();

            await _DataAccess.SaveChangesAsync(cancellationToken);
        }

        public Task UseTransactionAsync(Func<TUnitOfWork, CancellationToken, Task> action, CancellationToken cancellationToken = default)
            => _DataAccess.UseTransactionAsync(action, cancellationToken);

        public Task<T> UseTransactionAsync<T>(Func<TUnitOfWork, CancellationToken, Task<T>> action, CancellationToken cancellationToken = default)
            => _DataAccess.UseTransactionAsync(action, cancellationToken);

        protected abstract Task ClearCaches();
    }
}

