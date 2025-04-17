using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Shared.Common.ApiIntegration;
using Shared.Common.ApiIntegration.KeyApp;
using Shared.Common.Constants;
using Shared.Common.Interfaces;
using Shared.Enums;
using static Shared.Common.Constants.SystemConstants;
using ILogger = Serilog.ILogger;

namespace Warehouse.API.Identity.Authorization
{
    public class ClaimRequirementFilter : IAuthorizationFilter
    {
        private readonly FunctionCode _functionCode;
        private readonly CommandCode _commandCode;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly IWebHostEnvironment _env;
        private readonly IDistributedCache _redisCacheService;
        private readonly ISerializeService _serializeService;
        private readonly IKeyAppApiClient _keyAppApiClient;
        private readonly IPermissionsApiClient _permissionsApiClient;

        public ClaimRequirementFilter(FunctionCode functionCode,
            CommandCode commandCode,
            IConfiguration configuration,
            ILogger logger,
            IWebHostEnvironment env,
            IDistributedCache redisCacheService,
            ISerializeService serializeService,
            IKeyAppApiClient keyAppApiClient,
            IPermissionsApiClient permissionsApiClient)
        {
            _functionCode = functionCode;
            _commandCode = commandCode;
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _env = env ?? throw new ArgumentNullException(nameof(env));
            _redisCacheService = redisCacheService ?? throw new ArgumentNullException(nameof(redisCacheService));
            _serializeService = serializeService ?? throw new ArgumentNullException(nameof(serializeService));
            _keyAppApiClient = keyAppApiClient ?? throw new ArgumentNullException(nameof(keyAppApiClient));
            _permissionsApiClient = permissionsApiClient ?? throw new ArgumentNullException(nameof(permissionsApiClient));
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Call the asynchronous authorization logic and block until it completes
            AuthorizeAsync(context).GetAwaiter().GetResult();
        }

        private async Task AuthorizeAsync(AuthorizationFilterContext context)
        {
            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(30));

            #region ConfigKey
            var configKeyCache = await _redisCacheService.GetStringAsync(CacheConstants.ResClientId);

            // If cache is not found, get it from the API and store it
            if (string.IsNullOrEmpty(configKeyCache))
            {
                try
                {
                    var configKey = await _keyAppApiClient.GetServiceAsync(_env.ApplicationName + "." + _env.EnvironmentName);
                    if (!configKey.Success)
                    {
                        _logger.Information($"{nameof(AuthorizeAsync)} Response: {configKey.Message}");
                        context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
                        return;
                    }

                    var resClientId = configKey.Data.FirstOrDefault(c => c.NameKey == SystemConstants.AppSettings.ClientId)?.Description;
                    if (resClientId != null)
                    {
                        await _redisCacheService.SetStringAsync(CacheConstants.ResClientId, _serializeService.Serialize(resClientId), options);
                    }
                    configKeyCache = resClientId; // Update value after setting it
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "Error fetching config key.");
                    context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
                    return;
                }
            }
            if (configKeyCache.StartsWith("\"") && configKeyCache.EndsWith("\""))
            {
                configKeyCache = JsonConvert.DeserializeObject<string>(configKeyCache);
            }
            var clientId = string.IsNullOrEmpty(configKeyCache) ? string.Empty : configKeyCache;
            #endregion

            var userIdClaim = context.HttpContext.User.Claims
                .SingleOrDefault(c => c.Type == SystemConstants.Claims.Id);

            if (userIdClaim == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                return;
            }

            // Create cache key based on ApiGateWay, userId and clientId
            var cacheKey = CacheConstants.GetApiPermissions + _configuration[SystemConstants.AppSettings.ApiGateWay] + userIdClaim.Value + clientId;
            var permissionsCache = await _redisCacheService.GetStringAsync(cacheKey);

            if (string.IsNullOrEmpty(permissionsCache))
            {
                try
                {
                    var res = await _permissionsApiClient.GetPermissionsAsync(userIdClaim.Value, clientId);
                    if (res.Success)
                    {
                        await _redisCacheService.SetStringAsync(cacheKey, _serializeService.Serialize(res.Data), options);
                        permissionsCache = res.Data; // Update cache after saving
                    }
                    else
                    {
                        context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "Error fetching permissions.");
                    context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
                    return;
                }
            }

            if (permissionsCache.StartsWith("\"") && permissionsCache.EndsWith("\""))
            {
                permissionsCache = JsonConvert.DeserializeObject<string>(permissionsCache);
            }

            // Deserialize cache data and check permissions
            var permissions = JsonConvert.DeserializeObject<List<string>>(permissionsCache);
            if (!permissions.Contains(_functionCode + "_" + _commandCode))
            {
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            }
        }
    }
}
