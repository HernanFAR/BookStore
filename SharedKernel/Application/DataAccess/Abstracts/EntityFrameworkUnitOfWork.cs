using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SharedKernel.Application.DataAccess.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SharedKernel.Application.DataAccess.Abstracts
{
    public abstract class EntityFrameworkUnitOfWork<TUnitOfWork> : IUnitOfWork<TUnitOfWork>
        where TUnitOfWork : class, IUnitOfWork<TUnitOfWork> 
    {
        private readonly DbContext _Context;

        protected IDbContextTransaction? DbContextTransaction;

        protected EntityFrameworkUnitOfWork(DbContext context) 
        {
            _Context = context;
        }

        public virtual Task CommitAsync(CancellationToken cancellationToken = default)
        {
            if (DbContextTransaction is null)
            {
                return Task.CompletedTask;
            }

            return DbContextTransaction.CommitAsync(cancellationToken);
        }

        public virtual async Task CreateTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (DbContextTransaction is not null)
            {
                return;
            }

            DbContextTransaction = await _Context.Database.BeginTransactionAsync(cancellationToken);
        }

        public virtual async Task FinishTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (DbContextTransaction is null)
            {
                return;
            }

            await DbContextTransaction.DisposeAsync();

            DbContextTransaction = null;
        }

        public virtual Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            if (DbContextTransaction is null)
            {
                return Task.CompletedTask;
            }

            return DbContextTransaction.RollbackAsync(cancellationToken);
        }

        public virtual Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _Context.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task UseTransactionAsync(Func<TUnitOfWork, CancellationToken, Task> action, CancellationToken cancellationToken = default)
        {
            await CreateTransactionAsync(cancellationToken);

            try
            {
                await action((this as TUnitOfWork)!, cancellationToken);

                await CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                await RollbackAsync(cancellationToken);

                throw;
            }
            finally
            {
                await FinishTransactionAsync(cancellationToken);
            }
        }

        public virtual async Task<T> UseTransactionAsync<T>(Func<TUnitOfWork, CancellationToken, Task<T>> action, CancellationToken cancellationToken = default)
        {
            await CreateTransactionAsync(cancellationToken);

            try
            {
                var toReturn = await action((this as TUnitOfWork)!, cancellationToken);

                await CommitAsync(cancellationToken);

                return toReturn;
            }
            catch (Exception)
            {
                await RollbackAsync(cancellationToken);

                throw;
            }
            finally
            {
                await FinishTransactionAsync(cancellationToken);
            }
        }
    }
}
