using Auth.Service;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ILogger<RequestActivarEmpleado> _logger;

        public UsuarioController(IUsuarioService usuarioService, ILogger<RequestActivarEmpleado> logger)
        {
            _usuarioService = usuarioService;
            _logger = logger;
        }

        [HttpGet("GetToAll")]
        public async Task<IActionResult> Get()
        {
            var date = await _usuarioService.GetAll();
            return Ok(date);
        }

        [HttpPost("ActivarEmpleado")]
        public async Task<IActionResult> DarAltaUsuario(RequestActivarEmpleado dtos)
        {
            try 
            {
                await _usuarioService.DarAltaUsuario(dtos);

                return Ok();
            } 
            catch 
            {
                return StatusCode(400, "Falla critica");
            }

        }

        [HttpPut("DarBajaEmpleado")]
        public async Task<IActionResult> DarBajaEmpleado(RequestDesactivarEmpleado dtos)
        {
            await _usuarioService.DarBajaEmpleado(dtos);
            return Ok();
        }
    }
}
