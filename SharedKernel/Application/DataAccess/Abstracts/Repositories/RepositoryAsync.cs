using Microsoft.EntityFrameworkCore;
using SharedKernel.Application.DataAccess.Interfaces.Repositories;
using SharedKernel.Domain.Interfaces.Abstracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace SharedKernel.Application.DataAccess.Abstracts.Repositories
{
    public abstract class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity>
        where TEntity : class, IEntity
    {
        private readonly DbContext _Context;

        public RepositoryAsync(DbContext context)
        {
            _Context = context;
        }

        public Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var entry = _Context.Add(entity);

            return Task.FromResult(entry.Entity);
        }

        public async Task<TEntity?> DeleteAsync(object[] keys, CancellationToken cancellationToken = default)
        {
            var entity = await _Context.Set<TEntity>()
                .FindAsync(keys, cancellationToken);

            if (entity == null) return null;

            var entry = _Context.Remove(entity);

            return entry.Entity;
        }

        public async Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await _Context.Set<TEntity>()
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<TEntity?> GetAsync(object[] keys, CancellationToken cancellationToken = default)
        {
            var entity = await _Context.Set<TEntity>()
                .FindAsync(keys, cancellationToken);

            if (entity == null) return null;

            _Context.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var entry = _Context.Update(entity);

            return Task.FromResult(entry.Entity);
        }

        public async Task<IEnumerable<TEntity>> PaginateAsync(int page, int take, CancellationToken cancellationToken = default)
        {
            return await _Context.Set<TEntity>()
                .Skip(page * take).Take(take)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public abstract Task<bool> CheckExistAsync(object[] keys, CancellationToken cancellationToken = default);

        public async Task<ulong> GetCountAsync(CancellationToken cancellationToken = default)
        {
            return (ulong)await _Context.Set<TEntity>()
                .LongCountAsync(cancellationToken);
        }
    }

    public abstract class RepositoryAsync<TEntity, TKey> : IRepositoryAsync<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        private readonly DbContext _Context;

        public RepositoryAsync(DbContext context)
        {
            _Context = context;
        }

        public Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var entry = _Context.Add(entity);

            return Task.FromResult(entry.Entity);
        }

        public async Task<TEntity?> DeleteAsync(TKey key, CancellationToken cancellationToken = default)
        {
            var entity = await _Context.Set<TEntity>()
                .AsNoTracking()
                .Where(e => e.Id!.Equals(key))
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null) return null;

            var entry = _Context.Remove(entity);

            return entry.Entity;
        }

        public async Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await _Context.Set<TEntity>()
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<TEntity?> GetAsync(TKey key, CancellationToken cancellationToken = default)
        {
            return await _Context.Set<TEntity>()
                .Where(e => e.Id!.Equals(key))
                .AsNoTracking()
                .SingleOrDefaultAsync(cancellationToken);
        }

        public Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var entry = _Context.Update(entity);

            return Task.FromResult(entry.Entity);
        }

        public async Task<IEnumerable<TEntity>> PaginateAsync(int page, int take, CancellationToken cancellationToken = default)
        {
            return await _Context.Set<TEntity>()
                .Skip(page * take).Take(take)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> CheckExistAsync(TKey key, CancellationToken cancellationToken = default)
        {
            return await _Context.Set<TEntity>()
                .Where(e => e.Id!.Equals(key))
                .AnyAsync(cancellationToken);
        }

        public async Task<ulong> GetCountAsync(CancellationToken cancellationToken = default)
        {
            return (ulong)await _Context.Set<TEntity>()
                .LongCountAsync(cancellationToken);
        }
    }
}
