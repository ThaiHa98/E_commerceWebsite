using Microsoft.Extensions.Configuration;
using Serilog;
using Shared.SeedWork;
using static Shared.Common.Constants.SystemConstants;

namespace Shared.Common.ApiIntegration.Permissions
{
    public class PermissionsApiClient : BaseApiClient, IPermissionsApiClient
    {
        private readonly ILogger _logger;
        private static string Methods = "PermissionsApiClient";
        public PermissionsApiClient(IHttpClientFactory httpClientFactory,
                                       IConfiguration configuration,
                                       ILogger logger)
            : base(httpClientFactory, configuration)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ApiResult<string>> GetPermissionsAsync(string userId, string clientId)
        {
            try
            {
                var data = await GetAsync<string>(PermissionsRouteSettings.GetPermissions + userId, clientId);
                return data;
            }
            catch (Exception ex)
            {
                _logger.Information($"Exception {Methods} {nameof(GetPermissionsAsync)}: {ex.Message}");
                return new ApiResult<string>
                {
                    Message = ex.Message,
                    Success = false,
                };
            }
        }
    }
}
