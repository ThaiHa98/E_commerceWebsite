using Microsoft.Extensions.Caching.Distributed;
using Shared.Common.ApiIntegration.ResClient;

namespace Shared.Common.Services
{
    public class StringRedisCacheServiceImpl : IStringRedisCacheService
    {
        private readonly IDistributedCache _distributedCache;

        public StringRedisCacheServiceImpl(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task SetStringAsync(string key, string value, DistributedCacheEntryOptions options)
        {
            await _distributedCache.SetStringAsync(key, value, options);
        }

        public async Task<string?> GetStringAsync(string key)
        {
            return await _distributedCache.GetStringAsync(key);
        }
    }
}
