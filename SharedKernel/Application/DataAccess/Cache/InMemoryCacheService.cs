using Microsoft.Extensions.Caching.Memory;
using SharedKernel.Application.DataAccess.Interfaces.Cache;
using System.Threading;
using System.Threading.Tasks;

namespace SharedKernel.Application.DataAccess.Cache
{
    public class InMemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _Cache;
        private readonly MemoryCacheEntryOptions _Configuration;

        public InMemoryCacheService(IMemoryCache cache, MemoryCacheEntryOptions configuration)
        {
            _Cache = cache;
            _Configuration = configuration;
        }

        public Task<T?> Get<T>(string key, CancellationToken token = default)
        {
            return Task.FromResult(_Cache.Get<T?>(key));
        }

        public Task Set<T>(T entity, string key, CancellationToken token = default)
        {
            _Cache.Set(key, entity, _Configuration);

            return Task.CompletedTask;
        }

        public Task Remove(string cacheKey)
        {
            _Cache.Remove(cacheKey);

            return Task.CompletedTask;
        }
    }
}
