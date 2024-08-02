using Admin.DTO;
using Admin.Interfaces;
using Admin.Interfaces.ServiceCall;
using Admin.Interfaces.Utilidades;
using AutoMapper;
using DTO;
using DTO.BacklogsEvent;
using Exceptions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Admin.Services.BackGroundsEvents
{
    public class DarBajaEmpleadoBG
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IAuthService _apiAuthService;
        private readonly IManejadorCorreosMailKit _manejadorCorreos;
        private readonly ILogger<DarBajaEmpleadoBG> _logger;
        private readonly EmailSettingsDTO _emailconfig;

        public DarBajaEmpleadoBG(
            IUnitofWork unitOfWork,
            IAuthService apiAuthService,
            IManejadorCorreosMailKit manejadorCorreos,
            ILogger<DarBajaEmpleadoBG> logger,
            IOptions<EmailSettingsDTO> emailConfigOptions)
        {
            _unitOfWork = unitOfWork;
            _apiAuthService = apiAuthService;
            _manejadorCorreos = manejadorCorreos;
            _logger = logger;
            _emailconfig = emailConfigOptions.Value;
        }

        public async Task BGExecute()
        {
             _logger.LogInformation("Tarea dar de baja ejecutada");

            var data = await _unitOfWork.BacklLogsRepository.GetAllAsync(x => x.CompletedAt == null &&
                    x.EventType == (int)EventsEnum.DarBajaEmpleado);

            if (data.Count == 0)
            {
                _logger.LogInformation("No hay datos para Ejecutar la tarea");
                return;
            } 


            foreach (var item in data)
            {
                var json = JsonSerializer.Deserialize<RequestDesactivarEmpleado>(item.Json);
                try
                {
                   // await Mensaje(json);
                    var task = _apiAuthService.DarBajaEmpleado(json);
                    task.Wait(6000);

                    if (!task.IsCompleted || !task.IsCompletedSuccessfully)
                    {
                        _logger.LogWarning("Error Al dar de baja");

                        //throw new Exception("Error Al dar de baja");

                        continue;
                    }
                    item.CompletedAt = DateTime.Now;

                    _unitOfWork.BacklLogsRepository.UpdateAsync(item);

                    await Mensaje(json);

                    await _unitOfWork.SaveChanges();

                    _logger.LogInformation("Se Actualizo el registro por ende  se dio de baja");
                }
                catch (Exception e)
                {
                    throw new Exception($"error en {e}");
                }
            }

        }

        private async Task Mensaje(RequestDesactivarEmpleado Datos) 
        {
            try
            {
                //este metodo prepara el mensaje para luego enviarlo

                var info = await _unitOfWork.EmpleadosRepository.GetOne(x => x.NumeroDocumento == Datos.IdenficadorEmpleado);

                if (info == null)
                {
                    throw new ClientErrorException("Error en el proceso , El usuario no existe");
                }

                var mensajePreparado = new DatosEnvioCorreoDTO() 
                {
                    Asunto = $"Se te dado se baja {info.Nombres}",
                    ContenidoHTML =" Se Informa por este medio que actualmente ya no se encuentra vigente dentro de la organizacion." +
                    " Agradecemos su comprension y que tenga un buen dia.",
                    CorreoRemitente = _emailconfig.FromAddress,
                    NombreRemitente = _emailconfig.FromName,
                    CorreoDestinatario = info.CorreoPersonal,
                    NombreDestinatario = info.Nombres
                };

                await _manejadorCorreos.Enviar(mensajePreparado);

                _logger.LogInformation("Correo Enviado");

            }
            catch
            {
                throw new ClientErrorException("Error en el proceso , Falla en el envio");
            }
        }
    }
}
