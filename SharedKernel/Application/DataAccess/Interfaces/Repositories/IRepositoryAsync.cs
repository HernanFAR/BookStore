using SharedKernel.Domain.Interfaces.Abstracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace SharedKernel.Application.DataAccess.Interfaces.Repositories
{
    public interface IRepositoryAsync<TEntity>
        where TEntity : IEntity
    {
        Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken = default);

        Task<TEntity?> GetAsync(object[] keys, CancellationToken cancellationToken = default);

        Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task<TEntity?> DeleteAsync(object[] keys, CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> PaginateAsync(int page, int take, CancellationToken cancellationToken = default);

        Task<bool> CheckExistAsync(object[] keys, CancellationToken cancellationToken = default);

        Task<ulong> GetCountAsync(CancellationToken cancellationToken = default);
    }

    public interface IRepositoryAsync<TEntity, TKey>
        where TEntity : IEntity<TKey>
    {
        Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken = default);

        Task<TEntity?> GetAsync(TKey key, CancellationToken cancellationToken = default);

        Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task<TEntity?> DeleteAsync(TKey key, CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> PaginateAsync(int page, int take, CancellationToken cancellationToken = default);

        Task<bool> CheckExistAsync(TKey key, CancellationToken cancellationToken = default);

        Task<ulong> GetCountAsync(CancellationToken cancellationToken = default);
    }
}
