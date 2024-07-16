using Admin.DTO;
using Admin.Interfaces;
using Admin.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin.api.Controllers.Maestros
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArlController : ControllerBase
    {
        private readonly IArlService _arlService;
        private readonly ILogger<ArlController> _logger;

        public ArlController(IArlService arlService, ILogger<ArlController> logger)
        {
            _arlService = arlService;
            _logger = logger;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var date = await _arlService.GetAll();
            return Ok(date);
        }


        // [AllowAnonymous]
        [HttpPost("CreateCargo")]
        public async Task<IActionResult> CreateUser(CreateGenericDTO dto)
        {
            await _arlService.Add(dto);

            //_logger.LogInformation();
            return Ok();
        }


        [HttpPut("Put")]
        public async Task<ActionResult> Update(GenericDTO dto)
        {
            await _arlService.Update(dto);
            return Ok(new { Message = "ok" });

        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _arlService.Delete(id);
            return Ok();

        }
    }
}
