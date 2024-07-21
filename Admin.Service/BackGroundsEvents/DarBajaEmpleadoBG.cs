using Admin.Interfaces;
using Admin.Interfaces.ServiceCall;
using AutoMapper;
using DTO;
using DTO.BacklogsEvent;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Admin.Services.BackGroundsEvents
{
    public class DarBajaEmpleadoBG(
        IUnitofWork _unitOfWork,
        IAuthService _apiAuthService, 
        IMapper _mapper,
        ILogger<DarBajaEmpleadoBG> _logger)
    {
        public async Task BGExecute()
        {
            _logger.LogInformation("Tarea dar de baja ejecutada");

            var data = await _unitOfWork.BacklLogsRepository.GetAllAsync(x => x.CompletedAt == null &&
                    x.EventType == (int)EventsEnum.DarBajaEmpleado);

            foreach (var item in data)
            {
                var json = JsonSerializer.Deserialize<RequestDesactivarEmpleado>(item.Json);
                try
                {
                    var task = _apiAuthService.DarBajaEmpleado(json);
                    task.Wait(5000);

                    if (!task.IsCompleted || !task.IsCompletedSuccessfully)
                    {
                        throw new Exception("Error Al dar de baja");
                        continue;
                    }
                    item.CompletedAt = DateTime.Now;
                    _unitOfWork.BacklLogsRepository.UpdateAsync(item);
                    await _unitOfWork.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception($"error en {e}");
                }
            }

        }
    }
}
