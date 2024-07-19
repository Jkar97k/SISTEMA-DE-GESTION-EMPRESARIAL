using Admin.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Admin.api.Controllers.Maestros
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoService _empleadosService;
        private readonly ILogger<EmpleadosController> _logger;

        public EmpleadosController(IEmpleadoService empleadosRepository, ILogger<EmpleadosController> logger)
        {
            _empleadosService = empleadosRepository;
            _logger = logger;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var date = await _empleadosService.GetToAll();
            return Ok(date);
        }

        // [AllowAnonymous]
        [HttpPost("CreateCargo")]
        public async Task<IActionResult> Create(RequestCreateEmpleado dtos)
        {
             await _empleadosService.CreateEmpleado(dtos);
            return Ok();
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(RequestEmpleado dtos)
        {
            await _empleadosService.UpdateEmpleado(dtos);
            return Ok();
        }
    }
}
