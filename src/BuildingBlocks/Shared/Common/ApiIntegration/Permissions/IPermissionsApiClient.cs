using Shared.SeedWork;

namespace Shared.Common.ApiIntegration
{
    public interface IPermissionsApiClient
    {
        Task<ApiResult<string>> GetPermissionsAsync(string userId, string clientId);
    }
}
