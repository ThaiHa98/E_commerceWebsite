using E_commerceWebsite.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Shared.SeedWork;
using Serilog;
using ILogger = Serilog.ILogger;

namespace E_commerceWebsite.API.Controllers
{
    [Route("useritems")]
    [ApiController]
    public class CheckRolesController : ControllerBase
    {
        private readonly CheckRolesRepositories _checkRolesRepo;
        private readonly ILogger _logger;

        public CheckRolesController(CheckRolesRepositories checkRolesRepo, ILogger logger)
        {
            _checkRolesRepo = checkRolesRepo;
            _logger = logger;
        }

        [HttpGet("get-permissions-role")]
        public async Task<IActionResult> GetPermissionsRoleAsync(string userId)
        {
            try
            {
                if (!Guid.TryParse(userId, out var userGuid))
                {
                    return BadRequest(new ApiResultBaseClient<string>
                    {
                        Success = false,
                        Message = "User ID không hợp lệ.",
                        Data = null,
                        TotalCount = 0
                    });
                }

                var result = await _checkRolesRepo.GetPermissionsByUserIdAsync(userGuid);

                return Ok(new ApiResultBaseClient<string>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    TotalCount = result.Data != null ? Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(result.Data).Count : 0
                });
            }
            catch (Exception ex)
            {
                _logger.Information($"Exception {nameof(GetPermissionsRoleAsync)}: {ex.Message}");

                return BadRequest(new ApiResultBaseClient<string>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null,
                    TotalCount = 0
                });
            }
        }
    }
}
