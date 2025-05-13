using E_commerceWebsite.API.Identity.Authorization;
using E_commerceWebsite.Application.Features.Role.Commands.CreateRole;
using E_commerceWebsite.Application.Features.RolePermission.CreateRolePermission;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared.DTOs;
using Shared.DTOs.RolePermission;
using Shared.Enums;
using Shared.SeedWork;
using ILogger = Serilog.ILogger;

namespace E_commerceWebsite.API.Controllers
{
    public class RolePermissionController : ApiController
    {
        #region Fields
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        private static string Methods = "RolePermissionController";
        #endregion

        #region Ctor
        public RolePermissionController(IMediator mediator, ILogger logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        #endregion

        #region Methods
        [ClaimRequirement(FunctionCode.Admin, CommandCode.CREATE)]
        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody] CreateRolePermissionDto entity)
        {
            try
            {
                _logger.Information($"Begin {Methods} {nameof(Create)} request: {JsonConvert.SerializeObject(entity)}");
                var query = new CreateRolePermissionCommand(entity);
                var result = await _mediator.Send(query);
                _logger.Information($"End {Methods} {nameof(Create)} repose: {result}");
                return Ok(new ApiResultBase
                {
                    success = true,
                    message = result
                });
            }
            catch (Exception ex)
            {
                _logger.Information($"Exception {Methods} {nameof(Create)}: {ex.Message}");
                return BadRequest(new ApiResultBase
                {
                    message = ex.Message,
                    success = false
                });
            }
        }
        #endregion
    }
}
