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
    public class DarAltaEmpleadoBG
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IAuthService _apiAuthService;
        private readonly IManejadorCorreosMailKit _manejadorCorreos;
        private readonly ILogger<DarBajaEmpleadoBG> _logger;
        private readonly EmailSettingsDTO _emailconfig;

        public DarAltaEmpleadoBG(
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
                    task.Wait(6000);

                    if (!task.IsCompleted || !task.IsCompletedSuccessfully)
                    {
                        throw new ClientErrorException("Error Al dar De alta");
                        
                    }
                    item.CompletedAt = DateTime.Now;

                    _unitOfWork.BacklLogsRepository.UpdateAsync(item);

                    await Mensaje(json);

                    await _unitOfWork.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new ClientErrorException($"error en {e}");
                }
            }
        }

        private async Task Mensaje(RequestActivarEmpleado Datos)
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
                    Asunto = $"Bienvenid@ De parte de JK sr {info.Nombres}",
                    ContenidoHTML = $" Se Informa por este medio Es una prueba del envio de correos de jk donde te tengo registra@ con " +
                    $" la identificacion {info.NumeroDocumento} y te servira para el primer inicio de sesion, de tu correo empresarial" +
                    $" te aconsejamos que la cambies lo antes posible." +
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
