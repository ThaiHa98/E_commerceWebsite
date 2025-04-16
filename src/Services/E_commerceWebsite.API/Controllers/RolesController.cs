using E_commerceWebsite.Application.Features.Role.Commands.CreateRole;
using E_commerceWebsite.Application.Features.Role.Commands.Delete;
using E_commerceWebsite.Application.Features.Role.Commands.Update;
using E_commerceWebsite.Application.Features.Role.Queries.GetById;
using E_commerceWebsite.Application.Features.Role.Queries.GetPaging;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared.DTOs;
using Shared.SeedWork;
using ILogger = Serilog.ILogger;

namespace E_commerceWebsite.API.Controllers
{
    public class RolesController : ApiController
    {
        #region Fields
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        private static string Methods = "RolesController";
        #endregion

        #region Ctor
        public RolesController(IMediator mediator, ILogger logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        #endregion

        #region Methods
        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody] CreateRolesDto entity)
        {
            try
            {
                _logger.Information($"Begin {Methods} {nameof(Create)} request: {JsonConvert.SerializeObject(entity)}");
                var query = new CreateRoleCommand(entity);
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

        [Route("delete")]
        [HttpPost]
        public async Task<ActionResult<string>> Delete(string guidid)
        {
            try
            {
                _logger.Information($"Begin {Methods} {nameof(Delete)} request: {guidid}");
                var query = new DeleteRoleCommand(Guid.Parse(guidid));
                var result = await _mediator.Send(query);
                _logger.Information($"End {Methods} {nameof(Delete)} repose: {result}");
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

        [Route("get-paging")]
        [HttpGet]
        public async Task<ActionResult<Pagination<RolesDto>>> GetPaging([FromQuery] RolesSearchDto request)
        {
            try
            {
                _logger.Information($"Begin {Methods} {nameof(GetPaging)} request: {JsonConvert.SerializeObject(request)}");
                var query = new GetPagingRolesQuery(request);
                var result = await _mediator.Send(query);

                _logger.Information($"End {Methods} {nameof(GetPaging)} repose: {JsonConvert.SerializeObject(result)}");
                return Ok(new ApiResultBase
                {
                    success = true,
                    data = result.Items,
                    totalCount = result.TotalRecords,
                });
            }
            catch (Exception ex)
            {
                _logger.Information($"Exception {Methods} {nameof(GetPaging)}: {ex.Message}");
                return Ok(new ApiResultBase
                {
                    success = false,
                    message = ex.Message,
                });
            }
        }

        [Route("get-by-id")]
        [HttpGet]
        public async Task<ActionResult<RolesDto>> GetById(string id)
        {
            try
            {
                _logger.Information($"Begin {Methods} {nameof(GetById)} request: {id}");
                var query = new GetByIdRolesQuery(id);
                var result = await _mediator.Send(query);

                _logger.Information($"End {Methods} {nameof(GetById)} repose: {JsonConvert.SerializeObject(result)}");
                return Ok(new ApiResultBase
                {
                    success = true,
                    data = result,
                });
            }
            catch (Exception ex)
            {
                _logger.Information($"Exception {Methods} {nameof(GetById)}: {ex.Message}");
                return BadRequest(new ApiResultBase
                {
                    success = false,
                    message = ex.Message,
                });
            }
        }

        [Route("update")]
        [HttpPost]
        public async Task<ActionResult<string>> Update([FromBody] UpdateRolesDto entity)
        {
            try
            {
                _logger.Information($"Begin {Methods} {nameof(Update)} request: {JsonConvert.SerializeObject(entity)}");
                var query = new UpdateRolesCommand(entity);
                var result = await _mediator.Send(query);
                _logger.Information($"End {Methods} {nameof(Update)} repose: {result}");
                return Ok(new ApiResultBase
                {
                    success = true,
                    message = result
                });
            }
            catch (Exception ex)
            {
                _logger.Information($"Exception {Methods} {nameof(Update)}: {ex.Message}");
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
