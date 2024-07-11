using Admin.DTO;
using Admin.Interfaces;
using Admin.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin.api.Controllers
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
            return Ok(new { Result = await _arlService.GetAll()});
        }


        // [AllowAnonymous]
        [HttpPost("CreateCargo")]
        public async Task<IActionResult> CreateUser(CreateArlDTO dto)
        {
            await _arlService.Add(dto);

            //_logger.LogInformation();
            return Ok();
        }


        [HttpPut("Put")]
        public async Task<ActionResult> Update(ArlDTO dto)
        {
            await _arlService.Update(dto);
            return Ok(new { Message = "ok" });

        }

        //[HttpDelete("Delete/{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    await _usuarioService.Deletebyguild(guid);

        //    if (_usuarioService.StatusCode != 200)
        //        return StatusCode(_usuarioService.StatusCode, _usuarioService.Message);

        //    return Ok(new { Message = _usuarioService.Message });

        //}
    }
}
