using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Common.ApiIntegration.ResClient
{
    public interface IStringRedisCacheService
    {
        Task<string> GetStringAsync(string key);
        Task SetStringAsync(string key, string value, DistributedCacheEntryOptions options);
    }
}
