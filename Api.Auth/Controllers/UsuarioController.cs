using Admin.Interfaces.Utilidades;
using Auth.Service;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;

namespace Api.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ILogger<RequestActivarEmpleado> _logger;
        //private readonly IManejadorCorreosMailKit _manejadorCorreos;


        public UsuarioController(IUsuarioService usuarioService, ILogger<RequestActivarEmpleado> logger)
        {
            _usuarioService = usuarioService;
            _logger = logger;
            //_manejadorCorreos = manejadorCorreos;
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
            Thread.Sleep(2000);
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
            Thread.Sleep(2000);
            await _usuarioService.DarBajaEmpleado(dtos);

            var result = new BaseResponse<bool>
            {
                Message = "Operación exitosa",
                Result = true,
                StatusCode = System.Net.HttpStatusCode.OK
            };
            return Ok(result);
        }

        //[HttpPost("PruebaDeEnvio")]
        //public async Task<IActionResult> SendEmail([FromBody] DatosEnvioCorreoDTO request)
        //{
        //    try
        //    {
        //        await _manejadorCorreos.Enviar(request);
        //        return Ok("Email sent successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}
    }
}
