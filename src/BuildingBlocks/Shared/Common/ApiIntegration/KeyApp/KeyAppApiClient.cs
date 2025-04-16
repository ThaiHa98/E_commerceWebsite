using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Serilog;
using Shared.Common.Interfaces;
using Shared.DTOs;
using Shared.SeedWork;
using static Shared.Common.Constants.SystemConstants;

namespace Shared.Common.ApiIntegration.KeyApp
{
    public class KeyAppApiClient : BaseApiClient, IKeyAppApiClient
    {
        private readonly ILogger _logger;
        private readonly IDistributedCache _redisCacheService;
        private readonly ISerializeService _serializeService;
        private static string Methods = "KeyAppApiClient";
        public KeyAppApiClient(IHttpClientFactory httpClientFactory,
                                       IConfiguration configuration,
                                       ILogger logger,
                                       IDistributedCache redisCacheService,
                                       ISerializeService serializeService)
            : base(httpClientFactory, configuration)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _redisCacheService = redisCacheService ?? throw new ArgumentNullException(nameof(redisCacheService));
            _serializeService = serializeService ?? throw new ArgumentNullException(nameof(serializeService));
        }

        public async Task<ApiResult<IList<KeyConfigDto>>> GetServiceAsync(string value)
        {
            try
            {
                var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(30));

                var cache = await _redisCacheService.GetStringAsync(CacheConstants.ConfigServiceApp + value);
                if (string.IsNullOrEmpty(cache))
                {
                    var data = await GetAsync<IList<KeyConfigDto>>(KeyAppRouteSettings.GetServiceKeyId + value, null);

                    await _redisCacheService.SetStringAsync(CacheConstants.ConfigServiceApp + value, _serializeService.Serialize(data), options);
                    return data;
                }
                return string.IsNullOrEmpty(cache) ? new ApiResult<IList<KeyConfigDto>>() : _serializeService.Deserialize<ApiResult<IList<KeyConfigDto>>>(cache);
            }
            catch (Exception ex)
            {
                _logger.Information($"Exception {Methods} {nameof(GetServiceAsync)}: {ex.Message}");
                return new ApiResult<IList<KeyConfigDto>>
                {
                    Message = ex.Message,
                    Success = false,
                };
            }
        }
    }
}
