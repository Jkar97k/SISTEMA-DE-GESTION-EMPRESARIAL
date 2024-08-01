using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Configuration;
using Admin.Interfaces.Utilidades;
using DTO;
using System.Net.Mail;

public class ManejadorCorreosMailKit : IManejadorCorreosMailKit
{
    private readonly IConfiguration _configuration;

    public ManejadorCorreosMailKit(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task Enviar(DatosEnvioCorreoDTO dto)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(dto.NombreRemitente, dto.CorreoRemitente));
        message.To.Add(new MailboxAddress(dto.NombreDestinatario, dto.CorreoDestinatario));
        message.Subject = dto.Asunto;

        var bodyBuilder = new BodyBuilder
        {
            HtmlBody = dto.ContenidoHTML

        };
        message.Body = bodyBuilder.ToMessageBody();

        using (var client = new MailKit.Net.Smtp.SmtpClient())
        {
            await client.ConnectAsync(_configuration["EmailSettings:SmtpServer"], int.Parse(_configuration["EmailSettings:SmtpPort"]), false);
            await client.AuthenticateAsync(_configuration["EmailSettings:Username"], _configuration["EmailSettings:Password"]);

            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}

