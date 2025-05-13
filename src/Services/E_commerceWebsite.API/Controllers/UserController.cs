using E_commerceWebsite.API.Identity.Authorization;
using E_commerceWebsite.Application.Features.Role.Queries.GetPaging;
using E_commerceWebsite.Application.Features.User.Commands.CreateUser;
using E_commerceWebsite.Application.Features.User.Commands.CreateUserEmployee;
using E_commerceWebsite.Application.Features.User.Commands.Login;
using E_commerceWebsite.Application.Features.User.Commands.Logout;
using E_commerceWebsite.Application.Features.User.Commands.Update;
using E_commerceWebsite.Application.Features.User.Queries.GetById;
using E_commerceWebsite.Application.Features.User.Queries.GetPaging;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared.DTOs;
using Shared.DTOs.User;
using Shared.Enums;
using Shared.SeedWork;
using System.Net;
using System.Security.Claims;
using ILogger = Serilog.ILogger;

namespace E_commerceWebsite.API.Controllers
{
    public class UserController : ApiController
    {
        #region Fields
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        private static string Methods = "UserController";
        #endregion

        #region Ctor
        public UserController(IMediator mediator, ILogger logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        #endregion

        #region Methods
        [Route("create-customer")]
        [HttpPost]
        public async Task<ActionResult<string>> CreateCustomer([FromBody] CreateUserCustomerDto entity)
        {
            try
            {
                _logger.Information($"Begin {Methods} {nameof(CreateCustomer)} request: {JsonConvert.SerializeObject(entity)}");

                var query = new CreateUserCommand(entity);
                var result = await _mediator.Send(query);

                _logger.Information($"End {Methods} {nameof(CreateCustomer)} repose: {result}");
                return Ok(new ApiResultBase
                {
                    success = true,
                    message = result
                });
            }
            catch (Exception ex)
            {
                _logger.Information($"Exception {Methods} {nameof(CreateCustomer)}: {ex.Message}");
                return BadRequest(new ApiResultBase
                {
                    message = ex.Message,
                    success = false
                });
            }
        }

        [ClaimRequirement(FunctionCode.Admin, CommandCode.CREATE)]
        [Route("create-employee")]
        [HttpPost]
        public async Task<ActionResult<string>> CreateEmployee([FromBody] CreateUserDto entity)
        {
            try
            {
                _logger.Information($"Begin {Methods} {nameof(CreateEmployee)} request: {JsonConvert.SerializeObject(entity)}");

                var query = new CreateUserEmployeeCommand(entity);
                var result = await _mediator.Send(query);

                _logger.Information($"End {Methods} {nameof(CreateEmployee)} repose: {result}");
                return Ok(new ApiResultBase
                {
                    success = true,
                    message = result
                });
            }
            catch (Exception ex)
            {
                _logger.Information($"Exception {Methods} {nameof(CreateEmployee)}: {ex.Message}");
                return BadRequest(new ApiResultBase
                {
                    message = ex.Message,
                    success = false
                });
            }
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<string>> LoginUser([FromBody] LoginRequest request)
        {
            try
            {
                _logger.Information($"Begin {Methods} LoginUser");
                var query = new LoginCommand(request);
                var result = await _mediator.Send(query);
                _logger.Information($"End LoginUser reponse: {JsonConvert.SerializeObject(result)}");
                return Ok(new ApiResultBase
                {
                    success = true,
                    httpStatusCode = (int)HttpStatusCode.OK,
                    message = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResultBase
                {
                    success = false,
                    httpStatusCode = (int)HttpStatusCode.BadRequest,
                    message = ex.Message
                });
            }
        }

        [Authorize]
        [Route("logout")]
        [HttpPost]
        public async Task<IActionResult> LogoutUser()
        {
            try
            {
                _logger.Information($"Begin {Methods} LogoutUser");
                var userIdClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out Guid GuidId))
                {
                    _logger.Error("User not found or invalid user ID");
                    return BadRequest(new ApiResultBase
                    {
                        success = false,
                        httpStatusCode = (int)HttpStatusCode.BadRequest,
                        message = "User not found or invalid user ID"
                    });
                }
                var response = await _mediator.Send(new LogoutCommand(GuidId.ToString()));

                _logger.Information($"End LogoutUser reponse:{JsonConvert.SerializeObject(response)}");
                return Ok(new ApiResultBase
                {
                    data = response,
                    success = true,
                    httpStatusCode = (int)HttpStatusCode.OK,
                    message = "Logout Successfully"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResultBase
                {
                    success = false,
                    httpStatusCode = (int)HttpStatusCode.BadRequest,
                    message = ex.Message
                });
            }
        }

        [ClaimRequirement(FunctionCode.Admin, CommandCode.UPDATE)]
        [Route("update")]
        [HttpPost]
        public async Task<ActionResult<string>> Update([FromBody] UpdateUserDto entity)
        {
            try
            {
                _logger.Information($"Begin {Methods} {nameof(Update)} request: {JsonConvert.SerializeObject(entity)}");

                var query = new UpdateUserCommand(entity);
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

        [ClaimRequirement(FunctionCode.Admin, CommandCode.VIEW)]
        [Route("get-paging")]
        [HttpGet]
        public async Task<ActionResult<Pagination<UserDto>>> GetPaging([FromQuery] UserSearchDto request)
        {
            try
            {
                _logger.Information($"Begin {Methods} {nameof(GetPaging)} request: {JsonConvert.SerializeObject(request)}");
                var query = new GetPagingUserQuery(request);
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

        [ClaimRequirement(FunctionCode.Admin, CommandCode.VIEW)]
        [Route("get-by-id")]
        [HttpGet]
        public async Task<ActionResult<ApiResultBase>> GetById([FromQuery] Guid id)
        {
            try
            {
                _logger.Information($"Begin {Methods} {nameof(GetById)} request: {id}");

                var query = new GetByIdUserQuery(id);
                var result = await _mediator.Send(query);

                _logger.Information($"End {Methods} {nameof(GetById)} response: {JsonConvert.SerializeObject(result)}");

                return Ok(new ApiResultBase
                {
                    success = true,
                    data = result
                });
            }
            catch (Exception ex)
            {
                _logger.Information($"Exception {Methods} {nameof(GetById)}: {ex.Message}");

                return Ok(new ApiResultBase
                {
                    success = false,
                    message = ex.Message
                });
            }
        }
        #endregion
    }
}
