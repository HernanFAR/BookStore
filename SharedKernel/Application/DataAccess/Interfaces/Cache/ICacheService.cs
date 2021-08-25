using System.Threading;
using System.Threading.Tasks;

namespace SharedKernel.Application.DataAccess.Interfaces.Cache
{
    public interface ICacheService
    {
        Task Set<T>(T entity, string key, CancellationToken token = default);

        Task<T?> Get<T>(string key, CancellationToken token = default);

        Task Remove(string cacheKey);
    }
}
