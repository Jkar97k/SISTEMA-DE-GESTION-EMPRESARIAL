﻿using Admin.DTO.Masters;
using Admin.Interfaces.Repositories.Repositories;
using Admin.Services.Masters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admin.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargosController : ControllerBase
    {
        private readonly ICargoService _cargoService;

        public CargosController(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            return Ok(new { Result = await _cargoService.GetAllAsync()});
        }


       // [AllowAnonymous]
        [HttpPost("CreateCargo")]
        public async Task<IActionResult> CreateUser(CreateCargoDTO dto)
        {
            await _cargoService.Create(dto);
            return Ok(new { Message = "ok" });
        }


        [HttpPut("Put")]
        public async Task<ActionResult> Update(CargoDTO dto)
        {
            await _cargoService.Update(dto);
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
