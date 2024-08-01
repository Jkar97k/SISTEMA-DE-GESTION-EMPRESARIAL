using Admin.Interfaces;
using Admin.Interfaces.ServiceCall;
using AutoMapper;
using DTO;
using DTO.BacklogsEvent;
using Exceptions;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Admin.Services.BackGroundsEvents
{
    public class DarAltaEmpleadoBG(
        IUnitofWork _unitOfWork, 
        IAuthService _apiAuthService, 
        ILogger<DarAltaEmpleadoBG> _logger)
    {
        public async Task BGExecute() 
        {
            _logger.LogInformation("Tarea dar de Alta ejecutada");

            var data = await _unitOfWork.BacklLogsRepository.GetAllAsync(x => x.CompletedAt == null && 
            x.EventType == (int)EventsEnum.DarAltaEmpleado);

            if (data.Count == 0) 
            {
                _logger.LogInformation("No hay datos para Ejecutar la tarea");
                return; 
            }
            foreach (var item in data)
            {
                var json = JsonSerializer.Deserialize<RequestActivarEmpleado>(item.Json);
                try
                {
                    var task = _apiAuthService.ActivarEmpleado(json);
                    task.Wait(5000);

                    if (!task.IsCompleted || !task.IsCompletedSuccessfully)
                    {
                        throw new ClientErrorException("Error Al dar De alta");
                        
                    }
                    item.CompletedAt = DateTime.Now;
                    _unitOfWork.BacklLogsRepository.UpdateAsync(item);
                    await _unitOfWork.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new ClientErrorException($"error en {e}");
                }
            }
        }
    }
}
