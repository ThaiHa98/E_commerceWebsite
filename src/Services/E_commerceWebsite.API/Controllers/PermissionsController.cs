using E_commerceWebsite.API.Identity.Authorization;
using E_commerceWebsite.Application.Features.Permission.Commands.Create;
using E_commerceWebsite.Application.Features.Role.Commands.CreateRole;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared.DTOs;
using Shared.Enums;
using Shared.SeedWork;
using ILogger = Serilog.ILogger;

namespace E_commerceWebsite.API.Controllers
{
    public class PermissionsController : ApiController
    {
        #region Fields
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        private static string Methods = "PermissionsController";
        #endregion

        #region Ctor
        public PermissionsController(IMediator mediator, ILogger logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        #endregion

        #region Methods
        [ClaimRequirement(FunctionCode.Admin, CommandCode.CREATE)]
        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody] CreatePermissionsDto entity)
        {
            try
            {
                _logger.Information($"Begin {Methods} {nameof(Create)} request: {JsonConvert.SerializeObject(entity)}");
                var query = new CreatePermissionsCommand(entity);
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
