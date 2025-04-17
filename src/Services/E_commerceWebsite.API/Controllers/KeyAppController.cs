using E_commerceWebsite.Domain.Entities;
using E_commerceWebsite.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.SeedWork;

namespace E_commerceWebsite.API.Controllers
{
    public class KeyAppController : ApiController
    {
        private readonly CreateKeyAppRepositories _keyAppService;

        public KeyAppController(CreateKeyAppRepositories keyAppService)
        {
            _keyAppService = keyAppService;
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateKeyApp([FromBody] KeyAppDto model)
        {
            var result = await _keyAppService.CreateAsync(model);
            if (result == null)
            {
                return BadRequest("Thiếu thông tin bắt buộc.");
            }

            return Ok(new { Success = true, Data = result });
        }

        [HttpGet("get-by-id")]
        public async Task<ActionResult<IList<KeyConfigDto>>> GetByServiceKeyId([FromQuery] string value)
        {
            try
            {
                var result = await _keyAppService.GetByServiceKeyId(value);

                if (result == null || result.Count == 0)
                {
                    return NotFound(new { Success = false, Message = "Không tìm thấy dữ liệu." });
                }

                return Ok(new { Success = true, Data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "Lỗi hệ thống", Error = ex.Message });
            }
        }
    }
}
